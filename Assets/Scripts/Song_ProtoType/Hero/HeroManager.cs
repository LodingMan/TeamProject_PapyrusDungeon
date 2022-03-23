
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;


public class HeroManager : MonoBehaviour
{
    public Stat initStat;
    
    public Item initItem;

    public SKillTable skillTable;

    public List<GameObject> HeroPrefabs;

    public GameObject CurrentCreateHero;

    public List<GameObject> CurrentHeroList;

    [SerializeField]
    public HeroSavingData[] CurrentHeroDataList = new HeroSavingData[3];


    int JobSkillStartIndex;

    void Start()
    {
    }

    public void MageCreate()
    {
        FirstHeroCreate("Mage");

    }


    public void FirstHeroCreate(string HeroJobName)
    {
        switch (HeroJobName)
        {
            case "Mage":
                initStat = new Stat(0, "ani", "Mage", 10, 20, 5, 5, 2, 2, 3);
                CurrentCreateHero = Instantiate(HeroPrefabs[0]) as GameObject;
                JobSkillStartIndex = 0;


                break;
            case "Achor":
                break;

            default:

                break;
        }
        #region //°ª ´ëÀÔ
        CurrentCreateHero.GetComponent<StatScript>().Index = initStat.Index;
        CurrentCreateHero.GetComponent<StatScript>().Name = initStat.Name;
        CurrentCreateHero.GetComponent<StatScript>().Atk = initStat.Atk;
        CurrentCreateHero.GetComponent<StatScript>().Def = initStat.Def;
        CurrentCreateHero.GetComponent<StatScript>().Cri = initStat.Cri;
        CurrentCreateHero.GetComponent<StatScript>().Acc = initStat.Acc;
        CurrentCreateHero.GetComponent<StatScript>().Agi = initStat.Agi;
        #endregion


        for (int skillIndex = JobSkillStartIndex; skillIndex < JobSkillStartIndex + 5; skillIndex++)
        {
            CurrentCreateHero.GetComponent<SkillScript>().skills[skillIndex] = skillTable.initSkill[skillIndex];
        }

        CurrentHeroList.Add(CurrentCreateHero);

    }

    public void LoadHeroCreate()
    {

    }


    public void _Save()
    {
       CurrentHeroDataList[0] = CurrentHeroList[0].GetComponent<HeroScript>().heroSavingData;

        string jdata = JsonConvert.SerializeObject(CurrentHeroDataList);
        File.WriteAllText(Application.dataPath + "/Stat.Json", jdata);
    }
    public void _Load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/Stat.Json");
        CurrentHeroDataList = JsonConvert.DeserializeObject<HeroSavingData[]>(jdata);

        Debug.Log(CurrentHeroDataList[0]);

    }



}



