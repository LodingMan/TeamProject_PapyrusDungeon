using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrnetHeroStats : MonoBehaviour
{
    CreateHiredPrefabs createHiredPrefabs;
    public HeroClass heroData;

    public int index;
    public string heroName;
    public string job;
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
    public string skill01;
    public string skill02;
    public string skill03;
    public string skill04;
    public string skill05;

    void Start()
    {
        createHiredPrefabs = GameObject.Find("HiredHireList").GetComponent<CreateHiredPrefabs>();
        heroData = createHiredPrefabs.heroData;

        heroData.index = 0;
        heroData.name = "아무개"; // 얘 자체를 건드려도 되고
        InitStat();
    }

    public void InitStat()
    {
        index = heroData.index;
        heroName = heroData.name;
        job = heroData.job;
        lv = heroData.lv;
        hp = heroData.hp;
        mp = heroData.mp;
        atk = heroData.atk;
        def = heroData.def;
        cri = heroData.cri;
        agi = heroData.agi;
        weapon = heroData.weapon;
        armor = heroData.armor;
        skill01 = heroData.skill01;
        skill02 = heroData.skill02;
        skill03 = heroData.skill03;
        skill04 = heroData.skill04;
        skill05 = heroData.skill05;
    }

}
