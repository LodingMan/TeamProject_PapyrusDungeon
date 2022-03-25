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
        switch (gameObject.tag)
        {
            case "Goblin":
                if (gameObject.tag == "Goblin")
                {
                    int rnd = Random.Range(0, 10);
                    if (rnd > 5)
                    {
                        Debug.Log("�Ϲݰ���");
                        //�Ϲ� ����
                        isActive = false;
                    }
                    else
                    {
                        skillDmg = skillData.MonsterSkills[0].dmg;
                        skillMp = skillData.MonsterSkills[0].mp;
                        Debug.Log("��ų����");
                        //��ų ����
                        MonsterSkillMethod();
                        isActive = false;
                    }
                }
                break;
            case "Slime":
                if (gameObject.tag == "Slime")
                {
                    int rnd = Random.Range(0, 10);
                    if (rnd > 5)
                    {
                        //�Ϲ� ����
                        isActive = false;
                    }
                    else
                    {
                        //��ų ����
                        MonsterSkillMethod();
                        isActive = false;
                    }
                }
                break;
            case "Beetle":
                if (gameObject.tag == "Beetle")
                {
                    int rnd = Random.Range(0, 10);
                    if (rnd > 5)
                    {
                        //�Ϲ� ����
                        isActive = false;
                    }
                    else
                    {
                        //��ų ����
                        MonsterSkillMethod();
                        isActive = false;
                    }
                }

                break;
            case "Skeleton":
                if (gameObject.tag == "Skeleton")
                {
                    int rnd = Random.Range(0, 10);
                    if (rnd > 5)
                    {
                        //�Ϲ� ����
                        isActive = false;
                    }
                    else
                    {
                        //��ų ����
                        MonsterSkillMethod();
                        isActive = false;
                    }
                }

                break;
            case "Mimic":
                if (gameObject.tag == "Mimic")
                {
                    int rnd = Random.Range(0, 10);
                    if (rnd > 5)
                    {
                        //�Ϲ� ����
                        isActive = false;
                    }
                    else
                    {
                        //��ų ����
                        MonsterSkillMethod();
                        isActive = false;
                    }
                }

                break;
            case "Golem":
                if (gameObject.tag == "Golem")
                {
                    int rnd = Random.Range(0, 10);
                    if (rnd > 5)
                    {
                        //�Ϲ� ����
                        isActive = false;
                    }
                    else
                    {
                        //��ų ����
                        MonsterSkillMethod();
                        isActive = false;
                    }
                }

                break;
            default:
                break;
        }

    }

    public void MonsterSkillMethod()
    {
        switch (gameObject.tag)
        {
            case "Goblin":

                break;
            case "Slime":

                break;
            case "Beetle":

                break;
            case "Skeleton":

                break;
            case "Mimic":

                break;
            case "Golem":

                break;
            default:
                break;
        }
    }
}

