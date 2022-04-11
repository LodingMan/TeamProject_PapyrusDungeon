using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin
{
    public class UI_Training_TrainingHeroInfo : MonoBehaviour
    {
        Song.HeroManager heroManager;
        Shin.UI_TrainingManager trainingManager;
        Shin.HeroImageTable heroImageTable;
        public StatScript statScript;
        public SkillScript skillScript;
        public HeroScript_Current_State heroScript_Current_State;


        Button btn; // 자기자신버튼
        public Image heroIcon;
        public Text heroName;
        public int curWeek;

        void Start()
        {
            trainingManager = GameObject.Find("TrainingManager").GetComponent<Shin.UI_TrainingManager>();
            heroManager = trainingManager.heroManager;
            heroImageTable = trainingManager.heroImageTable;

            statScript = GetComponent<StatScript>();
            skillScript = GetComponent<SkillScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();

            btn = GetComponent<Button>();
            btn.onClick.AddListener(TrainingEnd);
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
            if ((trainingManager.townMgr.Week - curWeek >= 1))
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
                trainingManager.EmployedDestroy_UI();
                trainingManager.EmployedInit_UI();
                Destroy(gameObject);
            }
            else
            {
                trainingManager.tweenMgr.UI_TrainWarning_On();
                trainingManager.isWarning = true;
                StartCoroutine(WarningWait());                
            }
        }    

        IEnumerator WarningWait()
        {
            yield return new WaitForSeconds(1f);
            if (trainingManager.isWarning)
            {
                trainingManager.isWarning = false;
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
            trainingManager.EmployedDestroy_UI();
            trainingManager.EmployedInit_UI();
            trainingManager.tweenMgr.UI_TrainWarning_Off();
            trainingManager.isWarning = false;
            Destroy(gameObject);
        }
    }
}

