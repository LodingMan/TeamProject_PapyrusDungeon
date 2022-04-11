using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Song;

namespace Shin
{
    public class UI_Training_EmployedInfo : MonoBehaviour
    {
        UI_TrainingManager trainingManager;
        Song.HeroManager heroManager;
        UI_Tweening_Manager tweenMgr;
        TownManager townMgr;
        public HeroImageTable heroImageTable;

        public StatScript statScript;
        public SkillScript skillScript;
        public HeroScript_Current_State heroScript_Current_State;
        public Image heroInfo;
        public Image heroIcon;
        public Text text_Name;
        public Text text_Job;
        public Text HP;
        public Text MP;

        public int curWeek;
        Button btn;

        private void Start()
        {
            trainingManager = GameObject.Find("TrainingManager").GetComponent<Shin.UI_TrainingManager>();
            heroManager = trainingManager.heroManager;
            tweenMgr = trainingManager.tweenMgr;
            heroImageTable = trainingManager.heroImageTable;
            townMgr = trainingManager.townMgr;

            statScript = GetComponent<StatScript>();
            skillScript = GetComponent<SkillScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();


            heroInfo = GameObject.Find("Training_HeroInfo").transform.GetChild(0).GetComponent<Image>();
            btn = GetComponent<Button>();

            btn.onClick.AddListener(tweenMgr.UI_TrainingSecPanel_On); // 버튼이 눌리면
            btn.onClick.AddListener(ShowHeroDetail);
            btn.onClick.AddListener(trainingManager.MgrTable.soundMgr.PlayClipBtn);
        }
        private void Update()
        {
            Init_UI();
        }

        public void Init_UI()
        {
            curWeek = townMgr.Week;
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // 이름으로 비교해서 찾고
                {
                    statScript.myStat = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat; // 대입.
                    skillScript.skills = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().skills;
                    skillScript.SkillIndex = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().SkillIndex;
                    skillScript.mySkills = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().mySkills;
                    heroScript_Current_State.isTraining = heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isTraining;
                }
            }
            text_Name.text = statScript.myStat.Name;
            text_Job.text = statScript.myStat.Job;
            HP.text = "HP : " + statScript.myStat.HP + " / " + statScript.myStat.MAXHP;
            MP.text = "MP : " + statScript.myStat.MP + " / " + statScript.myStat.MAXMP;
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
        void ShowHeroDetail()
        {
            if (heroInfo.gameObject.activeSelf == false)
            {
                heroInfo.gameObject.SetActive(true);
            }
            
            heroInfo.name = statScript.myStat.Name;
            heroInfo.GetComponent<UI_Training_SelectedHeroInfo>().curWeek = curWeek;
            heroInfo.GetComponent<UI_Training_SelectedHeroInfo>().InitHeroInfo();
        }

    }
}

