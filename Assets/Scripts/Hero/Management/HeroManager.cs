
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;


namespace Song
{
    public class HeroManager : MonoBehaviour //����ġ ���� �´� ���ο� Hero ���� , ������ ����� �����͸� �����ؼ� ����ߴ� Hero�����
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
                    initStat = new Stat(0, "ani", "Mage", 9, 9, 5, 5, 2, 2, 3); //�ʱ� �������� ����
                    CurrentCreateHero = Instantiate(HeroPrefabs[0]) as GameObject; //������ ����
                    JobSkillStartIndex = 0; //��ų�� 0�� �ε�������5������ ���� (�ϴ� for�� ����) 


                    break;
                case "Achor":
                    break;

                default:

                    break;
            }
            #region //�� ���� 
            CurrentCreateHero.GetComponent<StatScript>().Index = initStat.Index; //������ ����� ������Ʈ�� StatScript�� ����
            CurrentCreateHero.GetComponent<StatScript>().Name = initStat.Name;
            CurrentCreateHero.GetComponent<StatScript>().HP = initStat.HP;
            CurrentCreateHero.GetComponent<StatScript>().MP = initStat.MP;
            CurrentCreateHero.GetComponent<StatScript>().Atk = initStat.Atk;
            CurrentCreateHero.GetComponent<StatScript>().Def = initStat.Def;
            CurrentCreateHero.GetComponent<StatScript>().Cri = initStat.Cri;
            CurrentCreateHero.GetComponent<StatScript>().Acc = initStat.Acc;
            CurrentCreateHero.GetComponent<StatScript>().Agi = initStat.Agi;
            #endregion

            //�ش� ������ �´� ��ų�� �� SkillScript�� ����
            for (int skillIndex = JobSkillStartIndex; skillIndex < JobSkillStartIndex + 5; skillIndex++)
            {
                CurrentCreateHero.GetComponent<SkillScript>().skills[skillIndex] = skillTable.initSkill[skillIndex];
            }
            
            //���� ���ӿ� ������Ʈ�� ������ Hero������Ʈ ����Ʈ
            CurrentHeroList.Add(CurrentCreateHero);

        }

        public void LoadHeroCreate(HeroSavingData djnks)
        {


        }


        public void _Save()
        {
            CurrentHeroDataList[0] = CurrentHeroList[0].GetComponent<HeroScript_SaveAllDataParam>().heroSavingData; // �� hero�� savingdata����

            string jdata = JsonConvert.SerializeObject(CurrentHeroDataList);
            File.WriteAllText(Application.dataPath + "/Stat.Json", jdata);
        }
        public void _Load()
        {
            string jdata = File.ReadAllText(Application.dataPath + "/Stat.Json");
            CurrentHeroDataList = JsonConvert.DeserializeObject<HeroSavingData[]>(jdata); //�ҷ��� savingdata�� LoadHeroCreate�Լ��� ����� heroObject����
        // �׽�Ʈ������ ����ѰŶ� List�� �����ʰ� �迭�� ���빰 �ϳ��� ������. 
            Debug.Log(CurrentHeroDataList[0].HP);

        }



    }



}

