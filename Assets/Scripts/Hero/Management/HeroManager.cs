using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace Song
{
    public class HeroManager : MonoBehaviour //����ġ ���� �´� ���ο� Hero ���� , ������ ����� �����͸� �����ؼ� ����ߴ� Hero�����
    {
        public Stat initStat; //������ ������Ʈ�� ������ �ӽ÷� �����ϱ����� Ŭ����

        public Item initItem; //���� �̻��

        public SKillTable skillTable = new SKillTable(); // ��� ��ų ����

        public List<GameObject> HeroPrefabs; //HeroManager���� ���� �� ���ִ� HeroObject���

        public GameObject CurrentCreateHero; //�� ������ ����� ������Ʈ�� ���� �����ϱ� ���� ����.

        public List<GameObject> unemployedHeroList; //������ ������ �̰�� ������ ���� ����Ʈ. ����ϸ� �ش� ����Ʈ���� CurrentHeroList�� �Ű�����.  

        public List<GameObject> CurrentHeroList; // ���� ������ �����

        public HeroSavingData[] CurrentHeroDataList = new HeroSavingData[30]; //������ HeroObject�� SavingData�� �ѹ��� ��Ƽ� Save�ϱ� ����
                                                                              // Save�ÿ� List�� �����ϰ� �;����� ������, ������ �ƽðų� �˰Եǽź��� ����������... -> ���ϴ� 03/26


        public Name_JobTable name_JobTable = new Name_JobTable(); //������ �����̸� �迭�� , �����̸� �迭�� ����ִ� Ŭ����

        int JobSkillStartIndex; // 0�̸� 0~4�� �ε��� , 5��� 5������ 9�������� �ε����� for������ ������ ��ų���� ������, �ϴ� for�� ����


        public GuildManager guildManager;

        public NaviMeshMgr naviMeshMgr;
        private void Start()
        {
            naviMeshMgr = GameObject.Find("NaviMeshMgr").GetComponent<NaviMeshMgr>();
        }

        public void RandomHeroCreate()
        {
            for (int i = 0; i < guildManager.oneDayCreateHeroCount; i++) // ���� ��尡 ����ϴ� ���� ����ŭ ��������
            {
                string rndJob = name_JobTable.RandomJobTable[Random.Range(0, name_JobTable.RandomJobTable.Length)]; //������ ���� �̸� ������
                FirstHeroCreate(rndJob);
            }

            guildManager.UnemployedHero_UI_Prefabs_UpLoad(unemployedHeroList);

        }


        public void FirstHeroCreate(string HeroJobName)  //�������� �ʱⰪ�� HeroObject�� �����ϴ� �Լ�. 
        {
            string RandomName = name_JobTable.RandomNameTable[Random.Range(0, name_JobTable.RandomNameTable.Length)]; //������ ������Ʈ�� ������ �̸� �����

            #region //������ �������� ���� �ο� ������Ʈ ����, ��ų �ε��� �ο�
            switch (HeroJobName)
            {
                case "Mage":

                    initStat = new Stat(0, RandomName, "Mage", 9, 9, 9, 9, 5, 5, 2, 2, 3, 5); //�ʱ� �������� ����
                    CurrentCreateHero = Instantiate(HeroPrefabs[0]) as GameObject; //������ ����
                    CurrentCreateHero.name = initStat.Name; // ������ ������Ʈ�� ���� �̸�

                    JobSkillStartIndex = 0; //��ų�� 0�� �ε�������4������ ���� (�ϴ� for��[cs:77] ����) 
                    break;
                case "Archer":

                    initStat = new Stat(1, RandomName, "Archer", 10 , 10 , 10 , 10, 10, 3, 9, 7, 6, 10); //�ʱ� �ü��� ����
                    CurrentCreateHero = Instantiate(HeroPrefabs[0]) as GameObject; //�ü� ����
                    CurrentCreateHero.name = initStat.Name; // ������ ������Ʈ�� ���� �̸�

                    JobSkillStartIndex = 5; //��ų�� 5�� �ε�������9������ ���� (�ϴ� for��[cs:77] ����) 
                    break;
                case "Babarian":

                    initStat = new Stat(2, RandomName, "Babarian", 9, 9, 9, 9, 5, 5, 2, 2, 3, 5);
                    CurrentCreateHero = Instantiate(HeroPrefabs[0]) as GameObject;
                    CurrentCreateHero.name = initStat.Name;

                    JobSkillStartIndex = 10;

                    break;
                case "Knight":

                    initStat = new Stat(3, RandomName, "Knight", 9, 9 , 5 , 5 , 5, 5, 2, 2, 3, 5);
                    CurrentCreateHero = Instantiate(HeroPrefabs[0]) as GameObject;
                    CurrentCreateHero.name = initStat.Name;

                    JobSkillStartIndex = 15;
                    break;
                case "Barristan":

                    initStat = new Stat(4, RandomName, "Barristan", 9 , 9 , 9, 9 , 5, 5, 2, 2, 3, 5);
                    CurrentCreateHero = Instantiate(HeroPrefabs[0]) as GameObject;
                    CurrentCreateHero.name = initStat.Name;

                    JobSkillStartIndex = 20;
                    break;
                case "Porter":

                    initStat = new Stat(5, RandomName, "Porter", 9, 9 , 9, 9 , 5, 5, 2, 2, 3, 5);
                    CurrentCreateHero = Instantiate(HeroPrefabs[0]) as GameObject;
                    CurrentCreateHero.name = initStat.Name;

                    JobSkillStartIndex = 25;
                    break;

                default:
                    break;
            }
            #endregion

            //�ش� ������ �´� ������ �� StatScript�� ����
            CurrentCreateHero.GetComponent<StatScript>().myStat = initStat;

            //�ش� ������ �´� ��ų�� �� SkillScript�� ����
            for (int skillIndex = JobSkillStartIndex; skillIndex < JobSkillStartIndex + 5; skillIndex++)
            {
                CurrentCreateHero.GetComponent<SkillScript>().skills[skillIndex - JobSkillStartIndex] = skillTable.skillTable_Dictionary[skillIndex];
            }

            //Equip�� ���� ó�� �����ɶ� ������� �����Ѵ� �����ϰ� ���� ����. 
            //�� Hero������Ʈ�� EquipScript�� Equip�� ���� �Ǿ������� ���� ������� ����.



            unemployedHeroList.Add(CurrentCreateHero); //��忡�� �ش� ����Ʈ�� �޾� ����� ���� ����Ʈ�� ����Ѵ�. 

            //���� ���ӿ� ������Ʈ�� ������ Hero������Ʈ ����Ʈ
            //CurrentHeroList.Add(CurrentCreateHero); // �� ����Ʈ�� �������� UI������ ����� ��Ʈ�� 
                                                    // ����� �������ڸ��� CurrentCreateHero����Ʈ�� ���� ������ 
                                                    // ���� ���� �帧�� ������ ����� �Ŀ��� CurrentHeroList�� ���� �ϱ� ������
                                                    // �ϴ� ������ ������Ʈ�� '�����' ���� ����Ʈ�� �־�ΰ� UI�� ��� ��,
                                                    // ����ϸ� '�����' ���� ����Ʈ�� �Ű� �� �� UI������Ʈ�ϴ� ����� �ִٰ� ������  -> ���ϴ�
                                                    //03-27 ����. CurrentHeroList�� HeroManager�� ����Ǿ������� ����Ʈ�� �ɹ��� �߰��ϴ� ������ ��忡�� ������. 
                                                    //CurrentHeroList�� ����Ǵ°��� ������ HeroManager�� �����Ƿ� ����ϴµ� ������ ����. 

        }


        public void LoadHeroCreate(HeroSavingData LodingHeroSavingData) // 03-26 Json�� ����Ǿ��ִ� HeroSavingData�� �ٽ� Object�� �����Ѵ�.  
        {
            switch (LodingHeroSavingData.stat.Job) //������ �������� ���� �˻� �� �˸��� ������Ʈ ����
            {
                case "Mage": //���� �´� HeroPrefabs�� �ɹ��� ���� ��.
                    CurrentCreateHero = Instantiate(HeroPrefabs[0]);
                    break;
                case "Archer":
                    CurrentCreateHero = Instantiate(HeroPrefabs[0]);
                    break;
                case "Babarian":
                    CurrentCreateHero = Instantiate(HeroPrefabs[0]);
                    break;
                case "Knight":
                    CurrentCreateHero = Instantiate(HeroPrefabs[0]);
                    break;
                case "Barristan":
                    CurrentCreateHero = Instantiate(HeroPrefabs[0]);
                    break;
                case "Porter":
                    CurrentCreateHero = Instantiate(HeroPrefabs[0]);
                    break;
                default:
                    break;
            }

            //LoadingHeroSavingData���� ������ ������Ʈ�� �� ����
            CurrentCreateHero.name = LodingHeroSavingData.stat.Name;
            CurrentCreateHero.GetComponent<StatScript>().myStat = LodingHeroSavingData.stat;
            CurrentCreateHero.GetComponent<SkillScript>().skills = LodingHeroSavingData.skills;

            if (LodingHeroSavingData.equips != null) // �ҷ����� Hero�� �Ǽ��� ��쿡�� if�� ���� ������ �������� ����
            {
                CurrentCreateHero.GetComponent<EquipScript>().myEquip = LodingHeroSavingData.equips;
            }

            CurrentHeroList.Add(CurrentCreateHero); // �� ����Ʈ�� �������� UI������ ����� ��Ʈ�� 
            naviMeshMgr.CurrentHero[NaviMeshMgr.num++] = CurrentCreateHero;
        }


        public void _Save()
        {
            for (int i = 0; i < CurrentHeroList.Count; i++)
            {
                CurrentHeroDataList[i] = CurrentHeroList[i].GetComponent<HeroScript_SaveAllDataParam>().heroSavingData; // �� hero�� savingdata����
            }

            string jdata = JsonConvert.SerializeObject(CurrentHeroDataList);
            File.WriteAllText(Application.dataPath + "/Stat.Json", jdata);
        }
        public void _Load()
        {
            string jdata = File.ReadAllText(Application.dataPath + "/Stat.Json");
            CurrentHeroDataList = JsonConvert.DeserializeObject<HeroSavingData[]>(jdata); //�ҷ��� savingdata�� LoadHeroCreate�Լ��� ����� heroObject����

            naviMeshMgr.CurrentHero = new GameObject[CurrentHeroDataList.Length];
            for (int i = 0; i < CurrentHeroDataList.Length; i++) //CurrentHeroDataList�� ���̰� 30 �̹Ƿ� 30�� �ݺ���.
            {
                if (CurrentHeroDataList[i] == null)  //�迭�̶� ���������� null�� �Ǿ�����Ƿ� null�� ������ for���� ����
                {
                    break;
                }
                LoadHeroCreate(CurrentHeroDataList[i]);
            }
            Debug.Log(CurrentHeroDataList[0].stat.HP);
        }
    }


}

