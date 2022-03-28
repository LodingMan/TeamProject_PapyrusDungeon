using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navi_Hero_In_Town : MonoBehaviour
{
    public Transform target;
    public Transform[] point;
    NavMeshAgent agent;
    public float dist;
    int rnd_zen, rnd_target; 
    public bool isMove; // �̵����̸� true , ������̸� false
    public float curTime, coolTime;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        rnd_zen = Random.Range(0, point.Length);
        rnd_target = Random.Range(0, point.Length);
        gameObject.transform.position = point[rnd_zen].position; // ������ġ point�迭 �߿��� ���� ����.
        target = point[rnd_target];
    }

    
    void Update()
    {
        dist = Vector3.Distance(transform.position, target.position); // Ÿ�ٰ��� �Ÿ�.
        if (dist > 1.1f)
        {
            isMove = true;
            agent.SetDestination(target.position);
            coolTime = Random.Range(1.5f, 2.5f); // �̵��ϴ� ���� ������ �� ���ð��� ����. // �������� ��� ���� ���ϴ� ��
        }
        else
        {
            isMove = false;
            curTime += Time.deltaTime;
            if (curTime > coolTime)
            {
                curTime = 0;
                rnd_target = Random.Range(0, point.Length); // �������� �ٽ� ����.
                target = point[rnd_target]; // Ÿ�� ��ġ ����.
            }
        }

    }


    // ���� �ڷ�ƾ���� �߾��µ� ����Ÿ�ټ����κп��� �ڲ� �������� curTime,coolTime������� ����.
    /*IEnumerator OneSecondDelay(float delayTime)
    {
        yield return new WaitForSecondsRealtime(delayTime);

        rnd_target = Random.Range(0, point.Length); // �������� �ٽ� ����.
        target = point[rnd_target]; // Ÿ�� ��ġ ����.
        

    }*/
}
