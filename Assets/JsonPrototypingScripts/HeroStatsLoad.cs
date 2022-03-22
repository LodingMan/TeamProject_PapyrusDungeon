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
    public string weapon;
    public string armor;
    
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
            weapon = heroStats.weapon[0];
            armor = heroStats.armor[0];
        }
        else if (gameObject.name == "Magician")
        {
            lv = heroStats.lv[1];
            hp = heroStats.hp[1];
            mp = heroStats.mp[1];
            atk = heroStats.atk[1];
            def = heroStats.def[1];
            cri = heroStats.cri[1];
            acc = heroStats.acc[1];
            agi = heroStats.agi[1];
            weapon = heroStats.weapon[1];
            armor = heroStats.armor[1];
        }
        else if (gameObject.name == "Porter")
        {
            lv = heroStats.lv[2];
            hp = heroStats.hp[2];
            mp = heroStats.mp[2];
            atk = heroStats.atk[2];
            def = heroStats.def[2];
            cri = heroStats.cri[2];
            acc = heroStats.acc[2];
            agi = heroStats.agi[2];
            weapon = heroStats.weapon[2];
            armor = heroStats.armor[2];
        }
    }

}
