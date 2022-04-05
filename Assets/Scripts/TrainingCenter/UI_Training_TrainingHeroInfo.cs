using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin
{
    public class UI_Training_TrainingHeroInfo : MonoBehaviour
    {
        Song.HeroManager heroManager;
        Shin.UI_TrainingManager uI_trainingManager;
        public StatScript statScript;
        public SkillScript skillScript;
        public HeroScript_Current_State heroScript_Current_State;
        Shin.HeroImageTable heroImageTable;

        Button btn; // 자기자신버튼
        public Button btn_ReturnTrain;
        public Image heroIcon;
        public Text heroName;
        public int curWeek;
        private void Awake()
        {
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            uI_trainingManager = GameObject.Find("TrainingManager").GetComponent<Shin.UI_TrainingManager>();
            heroImageTable = GameObject.Find("HeroImageManager").GetComponent<Shin.HeroImageTable>();

            btn = GetComponent<Button>();
            btn_ReturnTrain = GameObject.Find("Btn_ReturnTrain").GetComponent<Button>();
            btn.onClick.AddListener(TrainingEnd);
            btn_ReturnTrain.onClick.AddListener(ForceReturn);
        }
        // Start is called before the first frame update
        void Start()
        {

            statScript = GetComponent<StatScript>();
            skillScript = GetComponent<SkillScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();
        }

        private void Update()
        {
            InitHeroInfo();
        }
        public void InitHeroInfo()
        {
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // 이름으로 비교해서 찾고
                {
                    statScript.myStat = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat; // 값 넣기.
                    skillScript.skills = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().skills;
                    skillScript.SkillIndex = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().SkillIndex;
                    skillScript.mySkills = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().mySkills;
                    heroScript_Current_State.isHealing = heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isTraining;
                    heroName.text = statScript.myStat.Name;
                    switch (statScript.myStat.Job)
                    {
                        case "Babarian":
                            heroIcon.sprite = heroImageTable.sprite[0];
                            break;
                        case "Archer":
                            heroIcon.sprite = heroImageTable.sprite[1];
                            break;
                        case "Knight":
                            heroIcon.sprite = heroImageTable.sprite[2];
                            break;
                        case "Barristan":
                            heroIcon.sprite = heroImageTable.sprite[3];
                            break;
                        case "Mage":
                            heroIcon.sprite = heroImageTable.sprite[4];
                            break;
                        case "Porter":
                            heroIcon.sprite = heroImageTable.sprite[5];
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        //TrainingStart() 함수는 UI_Training_SelectedHeroInfo 스크립트에 있음.
        public void TrainingEnd()
        {
            if ((uI_trainingManager.twMgr.Week - curWeek >= 1))
            {
                heroScript_Current_State.isTraining = false;
                for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
                {
                    if (gameObject.name == heroManager.CurrentHeroList[i].name)
                    {
                        heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isTraining = heroScript_Current_State.isTraining;
                        // 스킬레벨업
                    }
                }
                uI_trainingManager.EmployedDestroy_UI();
                uI_trainingManager.EmployedInit_UI();
                Destroy(gameObject);
            }
            else
            {
                uI_trainingManager.tweenMgr.UI_TrainWarningPanel_On();
                uI_trainingManager.isWarning = true;
                Debug.Log("아직 1주 안지났어요");
            }
        }

        public void ForceReturn()
        {
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name)
                {
                    heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isTraining = false;
                }
            }
            uI_trainingManager.EmployedDestroy_UI();
            uI_trainingManager.EmployedInit_UI();
            uI_trainingManager.tweenMgr.UI_TrainWarningPanel_Off();
            uI_trainingManager.isWarning = false;
            Destroy(gameObject);
        }
    }
}

