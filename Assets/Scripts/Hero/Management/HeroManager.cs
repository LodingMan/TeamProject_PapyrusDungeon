using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace Song
{
    public class HeroManager : MonoBehaviour //스위치 문에 맞는 새로운 Hero 생성 , 저장한 히어로 데이터를 참조해서 사용했던 Hero재생성
    {
        public Stat initStat; //생성할 오브젝트의 스텟을 임시로 저장하기위한 클래스

        public Item initItem; //아직 미사용

        public SKillTable skillTable = new SKillTable(); // 모든 스킬 정보

        public List<GameObject> HeroPrefabs; //HeroManager에서 생성 할 수있는 HeroObject목록

        public GameObject CurrentCreateHero; //막 생성된 히어로 오브젝트에 값을 대입하기 위해 선언.

        public List<GameObject> unemployedHeroList; //생성은 됐지만 미고용 상태인 영웅 리스트. 고용하면 해당 리스트에서 CurrentHeroList로 옮겨진다.  

        public List<GameObject> CurrentHeroList; // 현재 생성된 히어로

        public HeroSavingData[] CurrentHeroDataList = new HeroSavingData[30]; //생성된 HeroObject의 SavingData를 한번에 담아서 Save하기 위함
                                                                              // Save시에 List로 저장하고 싶었으나 에러남, 이유를 아시거나 알게되신분은 정보공유좀... -> 송하늘 03/26


        public Name_JobTable name_JobTable = new Name_JobTable(); //랜덤한 영어이름 배열과 , 직업이름 배열이 들어있는 클래스

        int JobSkillStartIndex; // 0이면 0~4번 인덱스 , 5라면 5번부터 9번까지의 인덱스를 for문으로 돌려서 스킬값을 대입함, 하단 for문 참조
        public int HeroColor;


        public GuildManager guildManager;

        public void RandomHeroCreate()
        {
            for (int i = 0; i < guildManager.oneDayCreateHeroCount; i++) // 현재 길드가 허용하는 생성 수만큼 랜덤생성
            {
                string rndJob = name_JobTable.RandomJobTable[Random.Range(0, name_JobTable.RandomJobTable.Length)]; //랜덤한 직업 이름 가져옴
                int rndColor = Random.Range(0, 4);
                FirstHeroCreate(rndJob, rndColor);
            }

            guildManager.UnemployedHero_UI_Prefabs_UpLoad(unemployedHeroList);

        }


        public void FirstHeroCreate(string HeroJobName, int color)  //랜덤으로 초기값의 HeroObject를 생성하는 함수. 
        {
            string RandomName = name_JobTable.RandomNameTable[Random.Range(0, name_JobTable.RandomNameTable.Length)]; //생성할 오브젝트의 랜덤한 이름 만들기

            #region //직업의 종류별로 스탯 부여 오브젝트 생성, 스킬 인덱스 부여
            switch (HeroJobName)
            {
                case "Mage":

                    initStat = new Stat(0, RandomName, "Mage", 9, 9, 9, 9, 5, 5, 2, 2, 3, 5); //초기 마법사의 스텟
                    CurrentCreateHero = Instantiate(HeroPrefabs[color]) as GameObject; //마법사 생성
                    CurrentCreateHero.name = initStat.Name; // 생성될 오브젝트의 고유 이름

                    JobSkillStartIndex = 0; //스킬의 0번 인덱스부터4번까지 대입 (하단 for문[cs:77] 참조) 
                    break;
                case "Archer":

                    initStat = new Stat(1, RandomName, "Archer", 10 , 10 , 10 , 10, 10, 3, 9, 7, 6, 10); //초기 궁수의 스텟
                    CurrentCreateHero = Instantiate(HeroPrefabs[color+4]) as GameObject; //궁수 생성
                    CurrentCreateHero.name = initStat.Name; // 생성될 오브젝트의 고유 이름

                    JobSkillStartIndex = 5; //스킬의 5번 인덱스부터9번까지 대입 (하단 for문[cs:77] 참조) 
                    break;
                case "Babarian":

                    initStat = new Stat(2, RandomName, "Babarian", 9, 9, 9, 9, 5, 5, 2, 2, 3, 5);
                    CurrentCreateHero = Instantiate(HeroPrefabs[color+8]) as GameObject;
                    CurrentCreateHero.name = initStat.Name;

                    JobSkillStartIndex = 10;

                    break;
                case "Knight":

                    initStat = new Stat(3, RandomName, "Knight", 9, 9 , 5 , 5 , 5, 5, 2, 2, 3, 5);
                    CurrentCreateHero = Instantiate(HeroPrefabs[color+12]) as GameObject;
                    CurrentCreateHero.name = initStat.Name;

                    JobSkillStartIndex = 15;
                    break;
                case "Barristan":

                    initStat = new Stat(4, RandomName, "Barristan", 9 , 9 , 9, 9 , 5, 5, 2, 2, 3, 5);
                    CurrentCreateHero = Instantiate(HeroPrefabs[color+16]) as GameObject;
                    CurrentCreateHero.name = initStat.Name;

                    JobSkillStartIndex = 20;
                    break;
                case "Porter":

                    initStat = new Stat(5, RandomName, "Porter", 9, 9 , 9, 9 , 5, 5, 2, 2, 3, 5);
                    CurrentCreateHero = Instantiate(HeroPrefabs[color+20]) as GameObject;
                    CurrentCreateHero.name = initStat.Name;

                    JobSkillStartIndex = 25;
                    break;

                default:
                    break;
            }
            #endregion

            //해당 직업에 맞는 스텟을 각 StatScript에 대입
            CurrentCreateHero.GetComponent<StatScript>().myStat = initStat;
            CurrentCreateHero.GetComponent<HeroScript_SaveAllDataParam>().heroSavingData.ColorType = color;

            //해당 직업에 맞는 스킬을 각 SkillScript에 대입
            for (int skillIndex = JobSkillStartIndex; skillIndex < JobSkillStartIndex + 5; skillIndex++)
            {
                CurrentCreateHero.GetComponent<SkillScript>().skills[skillIndex - JobSkillStartIndex] = skillTable.skillTable_Dictionary[skillIndex];
            }

            //Equip의 경우는 처음 생성될때 빈손으로 시작한다 가정하고 넣지 않음. 
            //각 Hero오브젝트의 EquipScript의 Equip는 선언만 되어있을뿐 값이 들어있지 않음.



            unemployedHeroList.Add(CurrentCreateHero); //길드에서 해당 리스트를 받아 고용할 영웅 리스트를 출력한다. 

            //현재 게임에 오브젝트로 등장한 Hero오브젝트 리스트
            //CurrentHeroList.Add(CurrentCreateHero); // 이 리스트를 기준으로 UI생성및 히어로 컨트롤 
                                                    // 현재는 생성하자마나 CurrentCreateHero리스트에 들어가게 되지만 
                                                    // 게임 진행 흐름상 영웅을 고용한 후에야 CurrentHeroList에 들어가야 하기 때문에
                                                    // 일단 생성한 오브젝트를 '고용할' 영웅 리스트에 넣어두고 UI를 출력 후,
                                                    // 고용하면 '고용한' 영웅 리스트에 옮겨 준 후 UI업데이트하는 방법이 있다고 생각함  -> 송하늘
                                                    //03-27 수정. CurrentHeroList는 HeroManager에 선언되어있지만 리스트의 맴버를 추가하는 역할은 길드에서 진행함. 
                                                    //CurrentHeroList가 선언되는곳은 여전히 HeroManager에 있으므로 사용하는데 변함은 없다. 
        }


        public void LoadHeroCreate(HeroSavingData LodingHeroSavingData) // 03-26 Json에 저장되어있는 HeroSavingData를 다시 Object로 생성한다.  
        {
            switch (LodingHeroSavingData.stat.Job) //가져온 데이터의 직업 검사 후 알맞은 오브젝트 생성
            {
                case "Mage": //각자 맞는 HeroPrefabs의 맴버가 들어가갸 함.
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

            //LoadingHeroSavingData에서 생성한 오브젝트에 값 대입
            CurrentCreateHero.name = LodingHeroSavingData.stat.Name;
            CurrentCreateHero.GetComponent<StatScript>().myStat = LodingHeroSavingData.stat;
            CurrentCreateHero.GetComponent<SkillScript>().skills = LodingHeroSavingData.skills;

            if (LodingHeroSavingData.equips != null) // 불러오는 Hero가 맨손일 경우에는 if문 안의 문장을 실행하지 않음
            {
                CurrentCreateHero.GetComponent<EquipScript>().myEquip = LodingHeroSavingData.equips;
            }

            CurrentHeroList.Add(CurrentCreateHero); // 이 리스트를 기준으로 UI생성및 히어로 컨트롤 
        }


        public void _Save()
        {
            for (int i = 0; i < CurrentHeroList.Count; i++)
            {
                CurrentHeroDataList[i] = CurrentHeroList[i].GetComponent<HeroScript_SaveAllDataParam>().heroSavingData; // 각 hero의 savingdata저장
            }

            if (!Directory.Exists(Application.persistentDataPath + "/Resources"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/Resources");
            }

            string jdata = JsonConvert.SerializeObject(CurrentHeroDataList);
            File.WriteAllText(Application.persistentDataPath + "/Resources/Stat.Json", jdata);
        }

        public void _Load()
        {
            string jdata = File.ReadAllText(Application.persistentDataPath + "/Resources/Stat.Json");
            CurrentHeroDataList = JsonConvert.DeserializeObject<HeroSavingData[]>(jdata); //불러온 savingdata를 LoadHeroCreate함수를 사용해 heroObject생성

            for (int i = 0; i < CurrentHeroDataList.Length; i++) //CurrentHeroDataList의 길이가 30 이므로 30번 반복됨.
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

