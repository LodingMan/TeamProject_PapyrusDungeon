using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CurrentHeroStats : MonoBehaviour
{
    public HeroClass heroClass;
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
        hiredHeroMgr = GameObject.Find("HiredHeroMgr").GetComponent<HiredHeroMgr>();
        InitStat();
    }
    public void InitStat()
    {
        if (UI_CurrentHeroPrefabs.j >= hiredHeroMgr.HiredheroData.Count) return;
        heroClass = hiredHeroMgr.HiredheroData[UI_CurrentHeroPrefabs.j++];
        index = heroClass.index;
        heroName = heroClass.stats.name;
        job = heroClass.stats.job;
        lv = heroClass.stats.lv;
        hp = heroClass.stats.hp;
        mp = heroClass.stats.mp;
        atk = heroClass.stats.atk;
        def = heroClass.stats.def;
        cri = heroClass.stats.cri;
        agi = heroClass.stats.agi;
    }
}
