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
    public bool isMove; // 이동중이면 true , 대기중이면 false
    public float curTime, coolTime;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        rnd_zen = Random.Range(0, point.Length);
        rnd_target = Random.Range(0, point.Length);
        gameObject.transform.position = point[rnd_zen].position; // 시작위치 point배열 중에서 랜덤 설정.
        target = point[rnd_target];
    }

    
    void Update()
    {
        dist = Vector3.Distance(transform.position, target.position); // 타겟과의 거리.
        if (dist > 1.1f)
        {
            isMove = true;
            agent.SetDestination(target.position);
            coolTime = Random.Range(1.5f, 2.5f); // 이동하는 동안 멈췄을 때 대기시간을 설정. // 랜덤으로 계속 값이 변하는 중
        }
        else
        {
            isMove = false;
            curTime += Time.deltaTime;
            if (curTime > coolTime)
            {
                curTime = 0;
                rnd_target = Random.Range(0, point.Length); // 랜덤변수 다시 설정.
                target = point[rnd_target]; // 타겟 위치 변경.
            }
        }

    }


    // 원래 코루틴으로 했었는데 랜덤타겟설정부분에서 자꾸 에러나서 curTime,coolTime방식으로 수정.
    /*IEnumerator OneSecondDelay(float delayTime)
    {
        yield return new WaitForSecondsRealtime(delayTime);

        rnd_target = Random.Range(0, point.Length); // 랜덤변수 다시 설정.
        target = point[rnd_target]; // 타겟 위치 변경.
        

    }*/
}
