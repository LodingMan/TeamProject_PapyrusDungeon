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

        InitStat();
    }

    public void InitStat()
    {
        index = heroData.index;
        heroName = heroData.stats.name;
        job = heroData.stats.job;
        lv = heroData.stats.lv;
        hp = heroData.stats.hp;
        mp = heroData.stats.mp;
        atk = heroData.stats.atk;
        def = heroData.stats.def;
        cri = heroData.stats.cri;
        agi = heroData.stats.agi;
    }

}
