using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSkills : MonoBehaviour
{
    public MonsterManager skillData;

    public int skillDmg;
    public int skillMp;
    public float curTime;

    public string skill;
    public bool isActive = false;

    void Awake()
    {
        skillData = GameObject.Find("GameMgr").GetComponent<MonsterManager>();
    }

    void Update()
    {
        if (isActive)
        {
            MonsterAttackMethod();
        }
    }

    public void MonsterAttackMethod()
    {
        if (gameObject.tag == "Goblin")
        {


        }
        else if (gameObject.tag == "Slime")
        {

        }
        else if (gameObject.tag == "Beetle")
        {

        }
        else if (gameObject.tag == "Skeleton")
        {

        }
        else if (gameObject.tag == "Mimic")
        {

        }
        else if (gameObject.tag == "Golem")
        {

        }

        isActive = false;
    }
}

