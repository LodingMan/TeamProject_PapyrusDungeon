using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace Song
{
    public class HeroManager : MonoBehaviour 
    {
        public Stat initStat; 

        public Item initItem;

        public SKillTable skillTable = new SKillTable(); 

        public List<GameObject> HeroPrefabs; 

        public GameObject CurrentCreateHero; 

        public List<GameObject> unemployedHeroList;   

        public List<GameObject> CurrentHeroList;

        //public HeroSavingData[] CurrentHeroDataList = new HeroSavingData[30]; 
        
        public List<HeroSavingData> CurrentHeroDataList = new List<HeroSavingData>();

        public Name_JobTable name_JobTable = new Name_JobTable(); 

        int JobSkillStartIndex; 
        public int HeroColor;
        string heroName = "BasicName";

        public GuildManager guildManager;

        public int NameCount = 0;

        public void RandomHeroCreate()
        {
            for (int i = 0; i < guildManager.oneDayCreateHeroCount; i++) 
            {
                string rndJob = name_JobTable.RandomJobTable[Random.Range(0, name_JobTable.RandomJobTable.Length)];
                int rndColor = Random.Range(0, 4);
                FirstHeroCreate(rndJob, rndColor);
                
            }
           
            name_JobTable.CurrentHeroName.RemoveRange(0, name_JobTable.CurrentHeroName.Count);
            for (int i = 0; i < CurrentHeroList.Count; i++)
            {
                name_JobTable.CurrentHeroName.Add(CurrentHeroList[i].name);
            }

            guildManager.UnemployedHero_UI_Prefabs_UpLoad(unemployedHeroList);

        }

        public void CheckOverName(string randomName)
        {
            bool isOver = false;

            if(name_JobTable.CurrentHeroName.Count != 0) 
            {
                for (int i = 0; i < name_JobTable.CurrentHeroName.Count; i++)
                {
                    if (randomName == name_JobTable.CurrentHeroName[i])
                    {
                        isOver = true;
                    }
                }

                if (!isOver) // 중복이 아니면, 여기서 CurrentHeroList를 검사해야함.
                {
                    bool isCur = false;
                    for (int i = 0; i < CurrentHeroList.Count; i++)
                    {
                        if (randomName == CurrentHeroList[i].name)
                        {
                            isCur = true;
                        }
                    }
                    if (isCur == false)
                    {
                        heroName = randomName;
                        name_JobTable.CurrentHeroName.Add(heroName);
                    }
                }
                else
                {
                    randomName = name_JobTable.RandomNameTable[Random.Range(0, name_JobTable.RandomNameTable.Length)]; // 랜덤으로 이름 받아옴.
                    CheckOverName(randomName);
                }
            }
        }

        public void FirstHeroCreate(string heroJob, int color)  //�������� �ʱⰪ�� HeroObject�� �����ϴ� �Լ�. 
        {
            string randomName = name_JobTable.RandomNameTable[Random.Range(0, name_JobTable.RandomNameTable.Length)]; // 랜덤으로 이름 받아옴.
            if (name_JobTable.CurrentHeroName.Count == 0) // 맨처음 중복처리 필요없을 때.
            {
                heroName = randomName;
                name_JobTable.CurrentHeroName.Add(heroName);
            }
            CheckOverName(randomName);

            // 중복처리 해야함.
            #region //������ �������� ���� �ο� ������Ʈ ����, ��ų �ε��� �ο�
            switch (heroJob)
            {
                case "Mage":

                    initStat = new Stat(0, heroName, "Mage", 25, 25, 50, 50, 7, 3, 0, 90, 10, 3); //기본스텟이 빈약하지만 스킬딜이 강력한 컨셉 
                    CurrentCreateHero = Instantiate(HeroPrefabs[color]) as GameObject; //������ ����
                    CurrentCreateHero.name = initStat.Name; // ������ ������Ʈ�� ���� �̸�

                    JobSkillStartIndex = 0; //��ų�� 0�� �ε�������4������ ���� (�ϴ� for��[cs:77] ����) 
                    break;
                case "Archer":

                    initStat = new Stat(1, heroName, "Archer", 28 , 28 , 20 , 20, 15, 5, 45, 90, 30, 10); //속도빠름, 회피높고 크리티컬 높음
                    CurrentCreateHero = Instantiate(HeroPrefabs[color+4]) as GameObject; //�ü� ����
                    CurrentCreateHero.name = initStat.Name; // ������ ������Ʈ�� ���� �̸�

                    JobSkillStartIndex = 5; //��ų�� 5�� �ε�������9������ ���� (�ϴ� for��[cs:77] ����) 
                    break;
                case "Babarian":

                    initStat = new Stat(2, heroName, "Babarian", 40, 40, 20, 20, 32, 7, 20, 95, 10, 7); //HP 준수 공격력 높음
                    CurrentCreateHero = Instantiate(HeroPrefabs[color+8]) as GameObject;
                    CurrentCreateHero.name = initStat.Name;

                    JobSkillStartIndex = 10;

                    break;
                case "Knight":

                    initStat = new Stat(3, heroName, "Knight", 53, 53 , 30 , 30 , 15, 10, 5, 100, 7, 4);
                    CurrentCreateHero = Instantiate(HeroPrefabs[color+12]) as GameObject;
                    CurrentCreateHero.name = initStat.Name;

                    JobSkillStartIndex = 15;
                    break;
                case "Barristan":

                    initStat = new Stat(4, heroName, "Barristan", 60 , 60 , 20, 20 , 12, 12, 5, 85, 5, 2);
                    CurrentCreateHero = Instantiate(HeroPrefabs[color+16]) as GameObject;
                    CurrentCreateHero.name = initStat.Name;

                    JobSkillStartIndex = 20;
                    break;
                case "Porter":

                    initStat = new Stat(5, heroName, "Porter", 33, 33 , 33, 33 , 3, 3, 33, 83, 23, 3);
                    CurrentCreateHero = Instantiate(HeroPrefabs[color+20]) as GameObject;
                    CurrentCreateHero.name = initStat.Name;

                    JobSkillStartIndex = 25;
                    break;

                default:
                    break;
            }
            #endregion

            //�ش� ������ �´� ������ �� StatScript�� ����
            CurrentCreateHero.GetComponent<StatScript>().myStat = initStat;
            CurrentCreateHero.GetComponent<StatScript>().myStat.Lv = 1;
            CurrentCreateHero.GetComponent<HeroScript_SaveAllDataParam>().heroSavingData.ColorType = color;

            //�ش� ������ �´� ��ų�� �� SkillScript�� ����
            for (int skillIndex = JobSkillStartIndex; skillIndex < JobSkillStartIndex + 5; skillIndex++)
            {
                CurrentCreateHero.GetComponent<SkillScript>().skills[skillIndex - JobSkillStartIndex] = skillTable.skillTable_Dictionary[skillIndex];
            }


            unemployedHeroList.Add(CurrentCreateHero); //��忡�� �ش� ����Ʈ�� �޾� ����� ���� ����Ʈ�� ����Ѵ�. 

        }


        public void LoadHeroCreate(HeroSavingData LodingHeroSavingData) // 03-26 Json�� ����Ǿ��ִ� HeroSavingData�� �ٽ� Object�� �����Ѵ�.  
        {
            switch (LodingHeroSavingData.stat.Job) //������ �������� ���� �˻� �� �˸��� ������Ʈ ����
            {
                case "Mage": //���� �´� HeroPrefabs�� �ɹ��� ���� ��.
                    CurrentCreateHero = Instantiate(HeroPrefabs[LodingHeroSavingData.ColorType]);
                    break;
                case "Archer":
                    CurrentCreateHero = Instantiate(HeroPrefabs[LodingHeroSavingData.ColorType+4]);
                    break;
                case "Babarian":
                    CurrentCreateHero = Instantiate(HeroPrefabs[LodingHeroSavingData.ColorType+8]);
                    break;
                case "Knight":
                    CurrentCreateHero = Instantiate(HeroPrefabs[LodingHeroSavingData.ColorType + 12]);
                    break;
                case "Barristan":
                    CurrentCreateHero = Instantiate(HeroPrefabs[LodingHeroSavingData.ColorType + 16]);
                    break;
                case "Porter":
                    CurrentCreateHero = Instantiate(HeroPrefabs[LodingHeroSavingData.ColorType + 20]);
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
            Debug.Log("sibal");
        }


        public void _Save()
        {
            for (int i = 0; i < CurrentHeroList.Count; i++)
            {
                if(CurrentHeroDataList != null)
                {
                    CurrentHeroDataList.Clear();
                }
                for (int j = 0; j < CurrentHeroList.Count; j++)
                {
                    CurrentHeroDataList.Add(CurrentHeroList[j].GetComponent<HeroScript_SaveAllDataParam>().heroSavingData);
                }
              
            }

            if (!Directory.Exists(Application.persistentDataPath + "/Resources"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/Resources");
            }

            string jdata = JsonConvert.SerializeObject(CurrentHeroDataList); // 암호화 Yoon
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
            string format = System.Convert.ToBase64String(bytes);

            File.WriteAllText(Application.persistentDataPath + "/Resources/Stat.Json", format);
        }

        public void _Load()
        {
            string jdata = File.ReadAllText(Application.persistentDataPath + "/Resources/Stat.Json");
            byte[] bytes = System.Convert.FromBase64String(jdata);
            string reformat = System.Text.Encoding.UTF8.GetString(bytes);
           // File.WriteAllText(Application.dataPath + "/Resources/Stat.Json", reformat);
            //Debug.Log(reformat);

            CurrentHeroDataList = JsonConvert.DeserializeObject<List<HeroSavingData>>(reformat); //�ҷ��� savingdata�� LoadHeroCreate�Լ��� ����� heroObject����

            for (int i = 0; i < CurrentHeroDataList.Count; i++) //CurrentHeroDataList�� ���̰� 30 �̹Ƿ� 30�� �ݺ���.
            {
                if (CurrentHeroDataList[i].stat.Name == "")
                {
                    break;
                }
                LoadHeroCreate(CurrentHeroDataList[i]);


            }
            guildManager.Load_Guild_UI_Prefabs();

            //Debug.Log(CurrentHeroDataList[0].stat.HP);
        }
    }


}

