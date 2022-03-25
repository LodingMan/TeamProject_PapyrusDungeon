
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;


namespace Song
{
    public class HeroManager : MonoBehaviour //스위치 문에 맞는 새로운 Hero 생성 , 저장한 히어로 데이터를 참조해서 사용했던 Hero재생성
    {
        public Stat initStat;

        public Item initItem;

        public SKillTable skillTable;

        public List<GameObject> HeroPrefabs;

        public GameObject CurrentCreateHero;

        public List<GameObject> CurrentHeroList;

        [SerializeField]
        public HeroSavingData[] CurrentHeroDataList = new HeroSavingData[3];


        int JobSkillStartIndex; // 0이면 0~4번 인덱스 , 5라면 5번부터 9번까지의 인덱스를 for문으로 돌려서 스킬값을 대입함, 하단 for문 참조

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
                    initStat = new Stat(0, "ani", "Mage", 9, 9, 5, 5, 2, 2, 3,5); //초기 마법사의 스텟
                    CurrentCreateHero = Instantiate(HeroPrefabs[0]) as GameObject; //마법사 생성
                    JobSkillStartIndex = 0; //스킬의 0번 인덱스부터5번까지 대입 (하단 for문 참조) 


                    break;
                case "Achor":
                    break;

                default:

                    break;
            }
            #region //값 대입 
            CurrentCreateHero.GetComponent<StatScript>().Index = initStat.Index; //생성한 히어로 오브젝트의 StatScript의 스텟
            CurrentCreateHero.GetComponent<StatScript>().Name = initStat.Name;
            CurrentCreateHero.GetComponent<StatScript>().Job = initStat.Job;
            CurrentCreateHero.GetComponent<StatScript>().HP = initStat.HP;
            CurrentCreateHero.GetComponent<StatScript>().MP = initStat.MP;
            CurrentCreateHero.GetComponent<StatScript>().Atk = initStat.Atk;
            CurrentCreateHero.GetComponent<StatScript>().Def = initStat.Def;
            CurrentCreateHero.GetComponent<StatScript>().Cri = initStat.Cri;
            CurrentCreateHero.GetComponent<StatScript>().Acc = initStat.Acc;
            CurrentCreateHero.GetComponent<StatScript>().Agi = initStat.Agi;
            CurrentCreateHero.GetComponent<StatScript>().Speed = initStat.Speed;
            #endregion

            //해당 직업에 맞는 스킬을 각 SkillScript에 대입
            for (int skillIndex = JobSkillStartIndex; skillIndex < JobSkillStartIndex + 5; skillIndex++)
            {
                CurrentCreateHero.GetComponent<SkillScript>().skills[skillIndex] = skillTable.initSkill[skillIndex];
            }
            
            //현재 게임에 오브젝트로 등장한 Hero오브젝트 리스트
            CurrentHeroList.Add(CurrentCreateHero); // 이 리스트를 기준으로 UI생성및 히어로 컨트롤 


        }

        public void LoadHeroCreate(HeroSavingData djnks)
        {


        }


        public void _Save()
        {
            CurrentHeroDataList[0] = CurrentHeroList[0].GetComponent<HeroScript_SaveAllDataParam>().heroSavingData; // 각 hero의 savingdata저장

            string jdata = JsonConvert.SerializeObject(CurrentHeroDataList);
            File.WriteAllText(Application.dataPath + "/Stat.Json", jdata);
        }
        public void _Load()
        {
            string jdata = File.ReadAllText(Application.dataPath + "/Stat.Json");
            CurrentHeroDataList = JsonConvert.DeserializeObject<HeroSavingData[]>(jdata); //불러온 savingdata를 LoadHeroCreate함수를 사용해 heroObject생성
        // 테스트용으로 사용한거라 List를 넣지않고 배열의 내용물 하나만 대입함. 
            Debug.Log(CurrentHeroDataList[0].HP);

        }

    }

}

