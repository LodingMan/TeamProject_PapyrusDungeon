using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiredHeroStats : MonoBehaviour
{
    public HiredPrefabInfo hiredPrefabInfo;

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
        hiredPrefabInfo = GetComponent<HiredPrefabInfo>();
        InitStat();
    }

    public void InitStat()
    {
        index = hiredPrefabInfo.heroData.index;
        heroName = hiredPrefabInfo.heroData.stats.name;
        job = hiredPrefabInfo.heroData.stats.job;
        lv = hiredPrefabInfo.heroData.stats.lv;
        hp = hiredPrefabInfo.heroData.stats.hp;
        mp = hiredPrefabInfo.heroData.stats.mp;
        atk = hiredPrefabInfo.heroData.stats.atk;
        def = hiredPrefabInfo.heroData.stats.def;
        cri = hiredPrefabInfo.heroData.stats.cri;
        agi = hiredPrefabInfo.heroData.stats.agi;
    }
}
