using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrnetHeroStats : MonoBehaviour // 영입 버튼을 누를 때 생성되는 3D오브젝트에 달려있는 컴포넌트.
{
    UI_CreateHiredPrefabs UI_createHiredPrefabs;
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


    void Start()
    {
        UI_createHiredPrefabs = GameObject.Find("HiredHireList").GetComponent<UI_CreateHiredPrefabs>();
        heroData = UI_createHiredPrefabs.heroData;

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
