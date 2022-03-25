using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentHeroStats02 : MonoBehaviour
{
    public CurrentHeroPrefabs currentHeroPrefabs;
    public HeroClass heroData;
    public HiredHeroMgr hiredHeroMgr;
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

    
    void Start()
    {
        currentHeroPrefabs = transform.parent.GetComponent<CurrentHeroPrefabs>();
        hiredHeroMgr = GameObject.Find("HiredHeroMgr").GetComponent<HiredHeroMgr>();
        InitStat();

    }
    public void InitStat()
    {
        if (CurrentHeroPrefabs.j >= hiredHeroMgr.HiredheroData.Count) return;
        heroData = hiredHeroMgr.HiredheroData[CurrentHeroPrefabs.j++];
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
