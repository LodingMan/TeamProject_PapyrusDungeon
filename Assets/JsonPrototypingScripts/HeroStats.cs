using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeroStats : MonoBehaviour
{
    public SaveAndLoadMgr heroStats;
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
        heroStats = GameObject.Find("GameMgr").GetComponent<SaveAndLoadMgr>();
        HeroCheck();

    }
    void HeroCheck()
    {
        if (gameObject.tag == "Barbarian")
        {
            int i = 0;

            lv = heroStats.lv[i];
            hp = heroStats.hp[i];
            mp = heroStats.mp[i];
            atk = heroStats.atk[i];
            def = heroStats.def[i];
            cri = heroStats.cri[i];
            acc = heroStats.acc[i];
            agi = heroStats.agi[i];
            weapon = heroStats.weapon[i];
            armor = heroStats.armor[i];



        }
        else if (gameObject.tag == "Archer")
        {
            int i = 1;

            lv = heroStats.lv[i];
            hp = heroStats.hp[i];
            mp = heroStats.mp[i];
            atk = heroStats.atk[i];
            def = heroStats.def[i];
            cri = heroStats.cri[i];
            acc = heroStats.acc[i];
            agi = heroStats.agi[i];
            weapon = heroStats.weapon[i];
            armor = heroStats.armor[i];


        }
        else if (gameObject.tag == "Knight")
        {

            int i = 2;

            lv = heroStats.lv[i];
            hp = heroStats.hp[i];
            mp = heroStats.mp[i];
            atk = heroStats.atk[i];
            def = heroStats.def[i];
            cri = heroStats.cri[i];
            acc = heroStats.acc[i];
            agi = heroStats.agi[i];
            weapon = heroStats.weapon[i];
            armor = heroStats.armor[i];



        }
        else if (gameObject.tag == "Barristan")
        {
            int i = 3;

            lv = heroStats.lv[i];
            hp = heroStats.hp[i];
            mp = heroStats.mp[i];
            atk = heroStats.atk[i];
            def = heroStats.def[i];
            cri = heroStats.cri[i];
            acc = heroStats.acc[i];
            agi = heroStats.agi[i];
            weapon = heroStats.weapon[i];
            armor = heroStats.armor[i];


        }
        else if (gameObject.tag == "Mage")
        {
            int i = 4;

            lv = heroStats.lv[i];
            hp = heroStats.hp[i];
            mp = heroStats.mp[i];
            atk = heroStats.atk[i];
            def = heroStats.def[i];
            cri = heroStats.cri[i];
            acc = heroStats.acc[i];
            agi = heroStats.agi[i];
            weapon = heroStats.weapon[i];
            armor = heroStats.armor[i];


        }
        else if (gameObject.tag == "Slave")
        {
            int i = 5;

            lv = heroStats.lv[i];
            hp = heroStats.hp[i];
            mp = heroStats.mp[i];
            atk = heroStats.atk[i];
            def = heroStats.def[i];
            cri = heroStats.cri[i];
            acc = heroStats.acc[i];
            agi = heroStats.agi[i];
            weapon = heroStats.weapon[i];
            armor = heroStats.armor[i];


        }
    }
}



