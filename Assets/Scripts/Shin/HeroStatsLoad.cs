using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStatsLoad : MonoBehaviour
{
    public TotalHeroMgr hero;
    public HeroPrefabInfo heroPrefabInfo;

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
        heroPrefabInfo = GetComponent<HeroPrefabInfo>();
        //int rnd = Random.Range(0, heroStats.dataLength); // 랜덤 돌려서 index에 맞는걸 찾음.
        InitStat(heroPrefabInfo.index);
    }
    
    public void InitStat(int cnt)
    {
        gameObject.name = hero.heroData[index].stats.name;
        
        
    }

}
