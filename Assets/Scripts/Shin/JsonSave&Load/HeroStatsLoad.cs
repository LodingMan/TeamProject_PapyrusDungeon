using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStatsLoad : MonoBehaviour
{
    public TotalHeroMgr hero;
    public UI_RndHeroPrefabInfo UI_rndHeroPrefabInfo;

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

    private void Start()
    {
        hero = GameObject.Find("GameMgr").GetComponent<TotalHeroMgr>();
        UI_rndHeroPrefabInfo = GetComponent<UI_RndHeroPrefabInfo>();
        //int rnd = Random.Range(0, heroStats.dataLength); // 랜덤 돌려서 index에 맞는걸 찾음.
        InitStat(UI_rndHeroPrefabInfo.index);
    }
    
    public void InitStat(int cnt)
    {
        gameObject.name = hero.heroData[cnt].stats.name;
        index = hero.heroData[cnt].index;
        heroName = hero.heroData[cnt].stats.name;
        job = hero.heroData[cnt].stats.job;
        lv = hero.heroData[cnt].stats.lv;
        hp = hero.heroData[cnt].stats.hp;
        mp = hero.heroData[cnt].stats.mp;
        atk = hero.heroData[cnt].stats.atk;
        def = hero.heroData[cnt].stats.def;
        cri = hero.heroData[cnt].stats.cri;
        acc = hero.heroData[cnt].stats.acc;
        agi = hero.heroData[cnt].stats.agi;


    }

}
