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

    void Awake()
    {
        MonsterStats = GameObject.Find("GameMgr").GetComponent<MonsterManager>();

        if (gameObject.tag == "Goblin")
        {
            int i = 0;

            lv = MonsterStats.lv[i];
            hp = MonsterStats.hp[i];
            mp = MonsterStats.mp[i];
            atk = MonsterStats.atk[i];
            def = MonsterStats.def[i];
            cri = MonsterStats.cri[i];
            acc = MonsterStats.acc[i];
            agi = MonsterStats.agi[i];

        }
        else if(gameObject.tag == "Slime")
        {
            int i = 1;

            lv = MonsterStats.lv[i];
            hp = MonsterStats.hp[i];
            mp = MonsterStats.mp[i];
            atk = MonsterStats.atk[i];
            def = MonsterStats.def[i];
            cri = MonsterStats.cri[i];
            acc = MonsterStats.acc[i];
            agi = MonsterStats.agi[i];
        }
        else if (gameObject.tag == "Beetle")
        {
            int i = 2;

            lv = MonsterStats.lv[i];
            hp = MonsterStats.hp[i];
            mp = MonsterStats.mp[i];
            atk = MonsterStats.atk[i];
            def = MonsterStats.def[i];
            cri = MonsterStats.cri[i];
            acc = MonsterStats.acc[i];
            agi = MonsterStats.agi[i];
        }
        else if (gameObject.tag == "Skeleton")
        {
            int i = 3;

            lv = MonsterStats.lv[i];
            hp = MonsterStats.hp[i];
            mp = MonsterStats.mp[i];
            atk = MonsterStats.atk[i];
            def = MonsterStats.def[i];
            cri = MonsterStats.cri[i];
            acc = MonsterStats.acc[i];
            agi = MonsterStats.agi[i];
        }
        else if (gameObject.tag == "Mimic")
        {
            int i = 4;

            lv = MonsterStats.lv[i];
            hp = MonsterStats.hp[i];
            mp = MonsterStats.mp[i];
            atk = MonsterStats.atk[i];
            def = MonsterStats.def[i];
            cri = MonsterStats.cri[i];
            acc = MonsterStats.acc[i];
            agi = MonsterStats.agi[i];
        }
        else if (gameObject.tag == "Golem")
        {
            int i = 5;

            lv = MonsterStats.lv[i];
            hp = MonsterStats.hp[i];
            mp = MonsterStats.mp[i];
            atk = MonsterStats.atk[i];
            def = MonsterStats.def[i];
            cri = MonsterStats.cri[i];
            acc = MonsterStats.acc[i];
            agi = MonsterStats.agi[i];
        }
    }

}
