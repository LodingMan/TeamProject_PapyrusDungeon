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
        heroName = hiredPrefabInfo.heroData.name;
        job = hiredPrefabInfo.heroData.job;
        lv = hiredPrefabInfo.heroData.lv;
        hp = hiredPrefabInfo.heroData.hp;
        mp = hiredPrefabInfo.heroData.mp;
        atk = hiredPrefabInfo.heroData.atk;
        def = hiredPrefabInfo.heroData.def;
        cri = hiredPrefabInfo.heroData.cri;
        agi = hiredPrefabInfo.heroData.agi;
        weapon = hiredPrefabInfo.heroData.weapon;
        armor = hiredPrefabInfo.heroData.armor;
        skill01 = hiredPrefabInfo.heroData.skill01;
        skill02 = hiredPrefabInfo.heroData.skill02;
        skill03 = hiredPrefabInfo.heroData.skill03;
        skill04 = hiredPrefabInfo.heroData.skill04;
        skill05 = hiredPrefabInfo.heroData.skill05;
    }
}
