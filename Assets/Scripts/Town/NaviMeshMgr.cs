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
                    //coolTime[i] = Random.Range(1.5f, 2.5f); // 이동하는 동안 멈췄을 때 대기시간을 설정. // 랜덤으로 계속 값이 변하는 중
                    coolTime[i] = 2f;
                }
                else
                {
                    curTime[i] += Time.deltaTime;
                    if (curTime[i] > coolTime[i])
                    {
                        curTime[i] = 0;
                        rnd_target[i] = Random.Range(0, point.Length); // 랜덤변수 다시 설정.
                        target[i] = point[rnd_target[i]]; // 타겟 위치 변경.
                    }
                }
            }

        }
        public void InitAgent(int cnt) // HeroManager의 _Load함수에서 실행. // Load로 데이터를 불러온 다음에 Init이 진행되어야 하기 때문에.
        {
            //배열 초기화
            agent = new NavMeshAgent[cnt];
            dist = new float[cnt];
            target = new Transform[cnt];
            rnd_zen = rnd_target = new int[cnt];
            curTime = new float[cnt];
            coolTime = new float[cnt];
            

            for (int i = 0; i < cnt; i++)
            {
                agent[i] = CurrentHero[i].GetComponent<NavMeshAgent>(); //agent 각각 배정.
                rnd_zen[i] = Random.Range(0, point.Length); // 젠 포인트 랜덤
                rnd_target[i] = Random.Range(0, point.Length); // 타겟 랜덤.
                CurrentHero[i].transform.position = point[rnd_zen[i]].position; // 생성되는 현재 고용된 영웅 오브젝트의 젠 위치 설정.
                target[i] = point[rnd_target[i]]; // 타겟 설정.
            }
        }
    }
}

