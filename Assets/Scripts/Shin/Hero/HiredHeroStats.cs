using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiredHeroStats : MonoBehaviour
{
    public UI_HiredPrefabInfo UI_hiredPrefabInfo;

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
        UI_hiredPrefabInfo = GetComponent<UI_HiredPrefabInfo>();
        InitStat();
    }

    public void InitStat()
    {
        index = UI_hiredPrefabInfo.heroData.index;
        heroName = UI_hiredPrefabInfo.heroData.stats.name;
        job = UI_hiredPrefabInfo.heroData.stats.job;
        lv = UI_hiredPrefabInfo.heroData.stats.lv;
        hp = UI_hiredPrefabInfo.heroData.stats.hp;
        mp = UI_hiredPrefabInfo.heroData.stats.mp;
        atk = UI_hiredPrefabInfo.heroData.stats.atk;
        def = UI_hiredPrefabInfo.heroData.stats.def;
        cri = UI_hiredPrefabInfo.heroData.stats.cri;
        agi = UI_hiredPrefabInfo.heroData.stats.agi;
    }
}
