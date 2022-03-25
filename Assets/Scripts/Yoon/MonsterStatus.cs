using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    public MonsterManager MonsterStats;
    public int lv;
    public int hp;
    public int mp;
    public int atk;
    public int def;
    public int cri;
    public int acc;
    public int agi;

    void Start()
    {
        MonsterStats = GameObject.Find("GameMgr").GetComponent<MonsterManager>();
        MonsterCheck();

    }

    public void MonsterCheck()
    {
        switch (gameObject.tag)
        {
            case "Goblin":
                int i = 0;

                lv = MonsterStats.lv[i];
                hp = MonsterStats.hp[i];
                mp = MonsterStats.mp[i];
                atk = MonsterStats.atk[i];
                def = MonsterStats.def[i];
                cri = MonsterStats.cri[i];
                acc = MonsterStats.acc[i];
                agi = MonsterStats.agi[i];
                break;
            case "Slime":
                int j = 1;

                lv = MonsterStats.lv[j];
                hp = MonsterStats.hp[j];
                mp = MonsterStats.mp[j];
                atk = MonsterStats.atk[j];
                def = MonsterStats.def[j];
                cri = MonsterStats.cri[j];
                acc = MonsterStats.acc[j];
                agi = MonsterStats.agi[j];
                break;
            case "Beetle":
                int t = 2;

                lv = MonsterStats.lv[t];
                hp = MonsterStats.hp[t];
                mp = MonsterStats.mp[t];
                atk = MonsterStats.atk[t];
                def = MonsterStats.def[t];
                cri = MonsterStats.cri[t];
                acc = MonsterStats.acc[t];
                agi = MonsterStats.agi[t];
                break;
            case "Skeleton":
                int u = 3;

                lv = MonsterStats.lv[u];
                hp = MonsterStats.hp[u];
                mp = MonsterStats.mp[u];
                atk = MonsterStats.atk[u];
                def = MonsterStats.def[u];
                cri = MonsterStats.cri[u];
                acc = MonsterStats.acc[u];
                agi = MonsterStats.agi[u];
                break;
            case "Mimic":
                int f = 4;

                lv = MonsterStats.lv[f];
                hp = MonsterStats.hp[f];
                mp = MonsterStats.mp[f];
                atk = MonsterStats.atk[f];
                def = MonsterStats.def[f];
                cri = MonsterStats.cri[f];
                acc = MonsterStats.acc[f];
                agi = MonsterStats.agi[f];
                break;
            case "Golem":
                int r = 5;

                lv = MonsterStats.lv[r];
                hp = MonsterStats.hp[r];
                mp = MonsterStats.mp[r];
                atk = MonsterStats.atk[r];
                def = MonsterStats.def[r];
                cri = MonsterStats.cri[r];
                acc = MonsterStats.acc[r];
                agi = MonsterStats.agi[r];
                break;

            default:
                break;
        }
    }

}
