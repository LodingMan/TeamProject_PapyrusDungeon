using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin
{
    public class UI_Training_SelectedHeroInfo : MonoBehaviour
    {
        Shin.UI_TrainingManager trainingManager;
        Song.HeroManager heroManager;
        public Shin.SkillDetailTable skillDetailTable;
        Shin.HeroImageTable heroImageTable;

        UI_Tweening_Manager TweenMgr;
        public StatScript statScript;
        public SkillScript skillScript;
        public EquipScript equipScript;
        public HeroScript_Current_State heroScript_Current_State;

        public Button training_Start;

        public Text heroName;
        public Image heroImage;

        public Image detail_Image;
        public Text detail_Name;
        public Text detail_Detail;
        public Button[] Skill_Btn;

        public Button KorBtn;
        public Button EngBtn;

        public int curWeek;

        void Start()
        {
            trainingManager = GameObject.Find("TrainingManager").GetComponent<Shin.UI_TrainingManager>();
            heroManager = trainingManager.heroManager;
            heroImageTable = trainingManager.heroImageTable;
            TweenMgr = trainingManager.tweenMgr;

            statScript = GetComponent<StatScript>();
            skillScript = GetComponent<SkillScript>();
            equipScript = GetComponent<EquipScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();
            heroName = transform.GetChild(0).GetComponent<Text>();
            heroImage = transform.GetChild(1).GetComponent<Image>();

            training_Start = GameObject.Find("Btn_Training_Start").GetComponent<Button>();
            training_Start.onClick.AddListener(TrainingStart);

            Skill_Btn[0].onClick.AddListener(Click_Btn_Skill00);
            Skill_Btn[1].onClick.AddListener(Click_Btn_Skill01);
            Skill_Btn[2].onClick.AddListener(Click_Btn_Skill02);

            gameObject.SetActive(false);
            
        }

        public void InitHeroInfo()
        {
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // �̸����� ���ؼ� ã��
                {
                    statScript.myStat = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat; // �� �ֱ�.
                    skillScript.skills = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().skills;
                    skillScript.SkillIndex = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().SkillIndex;
                    skillScript.mySkills = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().mySkills;
                    equipScript.myEquip = heroManager.CurrentHeroList[i].GetComponent<EquipScript>().myEquip;
                    heroScript_Current_State.isHealing = heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isTraining;
                }
            }
            heroName.text = statScript.myStat.Name;

            IndexInit();
            Click_Btn_Skill00();
        }

        public void TrainingStart()
        {
            heroScript_Current_State.isTraining = true; // �Ʒ� ���� on
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name)
                {
                    heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isTraining = heroScript_Current_State.isTraining;
                }
            }
            trainingManager.trainingHero_UI = Instantiate(trainingManager.trainingHero_UI_Prefab, trainingManager.training_List_UI_Content.transform);
            trainingManager.trainingHero_UI.name = gameObject.name;
            trainingManager.trainingHero_UI.GetComponent<UI_Training_TrainingHeroInfo>().curWeek = curWeek;

            TweenMgr.option_Btn.SetActive(true);
            TweenMgr.UI_TrainingSecPanel_Off();
            trainingManager.EmployedDestroy_UI();
            trainingManager.EmployedInit_UI();

            gameObject.SetActive(false);
        }

        public void IndexInit()
        {
            for (int i = 0; i < Skill_Btn.Length; i++)
            {
                Skill_Btn[i].name = skillScript.mySkills[i].Index.ToString();
                Skill_Btn[i].image.sprite = skillDetailTable.sprite[skillScript.mySkills[i].Index];
            }
            switch (statScript.myStat.Job)
            {
                case "Babarian":
                    heroImage.sprite = heroImageTable.sprite[0];
                    break;
                case "Archer":
                    heroImage.sprite = heroImageTable.sprite[1];
                    break;
                case "Knight":
                    heroImage.sprite = heroImageTable.sprite[2];
                    break;
                case "Barristan":
                    heroImage.sprite = heroImageTable.sprite[3];
                    break;
                case "Mage":
                    heroImage.sprite = heroImageTable.sprite[4];
                    break;
                case "Porter":
                    heroImage.sprite = heroImageTable.sprite[5];
                    break;
                default:
                    break;
            }
        }
    
        public void Click_Btn_Skill00()
        {
            detail_Image.sprite = Skill_Btn[0].image.sprite;
            for (int i = 0; i < skillDetailTable.skilldetails.Count; i++)
            {
                if (Skill_Btn[0].name == skillDetailTable.skilldetails[i].skillindex.ToString())
                {
                    detail_Name.text = skillDetailTable.skilldetails[i].skillname;
                    detail_Detail.text = skillDetailTable.skilldetails[i].skilldetail;
                }
            }
        }
        public void Click_Btn_Skill01()
        {
            detail_Image.sprite = Skill_Btn[1].image.sprite;
            for (int i = 0; i < skillDetailTable.skilldetails.Count; i++)
            {
                if (Skill_Btn[1].name == skillDetailTable.skilldetails[i].skillindex.ToString())
                {
                    detail_Name.text = skillDetailTable.skilldetails[i].skillname;
                    detail_Detail.text = skillDetailTable.skilldetails[i].skilldetail;
                }
            }
        }
        public void Click_Btn_Skill02()
        {
            detail_Image.sprite = Skill_Btn[2].image.sprite;
            for (int i = 0; i < skillDetailTable.skilldetails.Count; i++)
            {
                if (Skill_Btn[2].name == skillDetailTable.skilldetails[i].skillindex.ToString())
                {
                    detail_Name.text = skillDetailTable.skilldetails[i].skillname;
                    detail_Detail.text = skillDetailTable.skilldetails[i].skilldetail;
                }
            }
        }

        public void ChangeLanguage()
        { 
        }
    }

}

