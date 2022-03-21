using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStatsLoad : MonoBehaviour
{
    public HeroStats heroStats;
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
        heroStats = GameObject.Find("GameMgr").GetComponent<HeroStats>();

        if (gameObject.name == "Knight")
        {
            lv = heroStats.lv[0];
            hp = heroStats.hp[0];
            mp = heroStats.mp[0];
            atk = heroStats.atk[0];
            def = heroStats.def[0];
            cri = heroStats.cri[0];
            acc = heroStats.acc[0];
            agi = heroStats.agi[0];
        }
    }

}
