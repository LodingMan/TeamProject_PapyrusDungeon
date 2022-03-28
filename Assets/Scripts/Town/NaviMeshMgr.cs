using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Shin
{
    public class NaviMeshMgr : MonoBehaviour
    {
        public Transform[] point;
        public Transform[] target;
        public GameObject[] CurrentHero;
        public static int num = 0;
        public NavMeshAgent[] agent;
        public float[] dist;
        int[] rnd_zen, rnd_target;
        public float[] curTime, coolTime;

        void Update()
        {
            for (int i = 0; i < num; i++)
            {
                dist[i] = Vector3.Distance(CurrentHero[i].transform.position, target[i].position);
                if (dist[i] > 1.1f)
                {
                    agent[i].SetDestination(target[i].position);
                    //coolTime[i] = Random.Range(1.5f, 2.5f); // �̵��ϴ� ���� ������ �� ���ð��� ����. // �������� ��� ���� ���ϴ� ��
                    coolTime[i] = 2f;
                }
                else
                {
                    curTime[i] += Time.deltaTime;
                    if (curTime[i] > coolTime[i])
                    {
                        curTime[i] = 0;
                        rnd_target[i] = Random.Range(0, point.Length); // �������� �ٽ� ����.
                        target[i] = point[rnd_target[i]]; // Ÿ�� ��ġ ����.
                    }
                }
            }

        }
        public void InitAgent(int cnt) // HeroManager�� _Load�Լ����� ����. // Load�� �����͸� �ҷ��� ������ Init�� ����Ǿ�� �ϱ� ������.
        {
            //�迭 �ʱ�ȭ
            agent = new NavMeshAgent[cnt];
            dist = new float[cnt];
            target = new Transform[cnt];
            rnd_zen = rnd_target = new int[cnt];
            curTime = new float[cnt];
            coolTime = new float[cnt];
            

            for (int i = 0; i < cnt; i++)
            {
                agent[i] = CurrentHero[i].GetComponent<NavMeshAgent>(); //agent ���� ����.
                rnd_zen[i] = Random.Range(0, point.Length); // �� ����Ʈ ����
                rnd_target[i] = Random.Range(0, point.Length); // Ÿ�� ����.
                CurrentHero[i].transform.position = point[rnd_zen[i]].position; // �����Ǵ� ���� ���� ���� ������Ʈ�� �� ��ġ ����.
                target[i] = point[rnd_target[i]]; // Ÿ�� ����.
            }
        }
    }
}

