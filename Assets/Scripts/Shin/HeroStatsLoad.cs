using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStatsLoad : MonoBehaviour  //GameMgr에 존재하는 HeroStat을 가져와 HeroStat의 모든 값의 index를 활용해 
{                                           //InitStat함수로 HeroStat의 값을 가져올 수 있다. 
    public HeroStats heroStats;             //이 스크립트를 달고 있는 오브젝트는 이후에 고용한 영웅의 HeroClass안의 값을 넣어주기 위해
    public HeroPrefabInfo heroPrefabInfo;   // 변수로 HeroClass 내부 변수와 같은 형태의 변수들이 선언되어있다. 
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

    private void Start()
    {
        heroStats = GameObject.Find("GameMgr").GetComponent<HeroStats>();
       heroPrefabInfo = GetComponent<HeroPrefabInfo>();
        //int rnd = Random.Range(0, heroStats.dataLength); // 랜덤 돌려서 index에 맞는걸 찾음.
        InitStat(heroPrefabInfo.index);
    }
    
    public void InitStat(int cnt)
    {
        gameObject.name = heroStats.heroName[cnt];
        index = heroStats.index[cnt];
        heroName = heroStats.heroName[cnt];
        job = heroStats.job[cnt];
        lv = heroStats.lv[cnt];
        hp = heroStats.hp[cnt];
        mp = heroStats.mp[cnt];
        atk = heroStats.atk[cnt];
        def = heroStats.def[cnt];
        cri = heroStats.cri[cnt];
        agi = heroStats.agi[cnt];
        weapon = heroStats.weapon[cnt];
        armor = heroStats.armor[cnt];
        skill01 = heroStats.skill01[cnt];
        skill02 = heroStats.skill02[cnt];
        skill03 = heroStats.skill03[cnt];
        skill04 = heroStats.skill04[cnt];
        skill05 = heroStats.skill05[cnt];
    }

}
