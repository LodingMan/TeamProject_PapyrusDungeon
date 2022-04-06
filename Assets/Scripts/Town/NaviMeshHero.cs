using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Shin
{
    public class NaviMeshHero : MonoBehaviour
    {
        public Transform target;
        public Transform[] point;
        NavMeshAgent agent;
        public float dist;
        int rnd_zen, rnd_target;
        public float curTime, coolTime;
        string nodeName;
        public int pointCnt;

        public Animator anim;
        public enum HEROSTATE
        {
            IDLE = 998,
            WALK
        }public HEROSTATE herostate = HEROSTATE.IDLE;
        void Start()
        {
            anim = transform.GetChild(0).GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
            point = new Transform[pointCnt = 11];

            InitNaviPoint(); // hierarchy에 있는 NaviPoint를 point에 배정하는 함수.
            
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
                herostate = HEROSTATE.WALK;
                agent.SetDestination(target.position);
                coolTime = Random.Range(1.5f, 2.5f);
            }
            else
            {
                herostate = HEROSTATE.IDLE;
                
                curTime += Time.deltaTime;
                if (curTime > coolTime)
                {
                    curTime = 0;
                    rnd_target = Random.Range(0, point.Length);
                    target = point[rnd_target];
                }
            }
            anim.SetInteger("herostate", (int)herostate);
        }

        public void InitNaviPoint() // Hierarchy에서 NaviPoint검색해서 point에 할당.
        {
            for (int i = 0; i < pointCnt; i++)
            {
                if ((GameObject.Find("NaviPoint" + i).GetComponent<Transform>() == true))
                {
                    point[i] = GameObject.Find("NaviPoint" + i).GetComponent<Transform>();
                }
            }
        }
    }
}

