using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaviMeshHero : MonoBehaviour
{
    public Transform target;
    public Transform[] point;
    NavMeshAgent agent;
    public float dist;
    int rnd_zen, rnd_target;
    public bool isMove;
    public float curTime, coolTime;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // Hierarchy에서 NaviPoint0@을 찾아서 그 수만큼 point 배정.

        rnd_zen = Random.Range(0, point.Length);
        rnd_target = Random.Range(0, point.Length);
        gameObject.transform.position = point[rnd_zen].position;
        target = point[rnd_target];
    }


    void Update()
    {
        dist = Vector3.Distance(transform.position, target.position);
        if (dist > 1.1f)
        {
            isMove = true;
            agent.SetDestination(target.position);
            coolTime = Random.Range(1.5f, 2.5f);
        }
        else
        {
            isMove = false;
            curTime += Time.deltaTime;
            if (curTime > coolTime)
            {
                curTime = 0;
                rnd_target = Random.Range(0, point.Length);
                target = point[rnd_target];
            }
        }

    }

}
