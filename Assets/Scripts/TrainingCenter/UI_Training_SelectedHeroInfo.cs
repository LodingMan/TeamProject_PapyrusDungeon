using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin
{
    public class UI_Training_SelectedHeroInfo : MonoBehaviour
    {
        Song.HeroManager heroManager;
        Shin.UI_TrainingManager uI_trainingManager;
        public Shin.SkillDetailTable skillDetailTable;
        Shin.HeroImageTable heroImageTable;

        UI_Tweening_Manager uI_Tweening_Manager;
        public StatScript statScript;
        public SkillScript skillScript;
        public EquipScript equipScript;
        public HeroScript_Current_State heroScript_Current_State;

        public Button training_Start;

        public Text heroName;
        public Text heroJob;
        public Image heroImage;

        public Image detail_Image;
        public Text detail_Text;
        public Text detail_Before;
        public Text detail_After;
        public Button[] Skill_Btn;

        private void Awake()
        {
            training_Start = GameObject.Find("Btn_Training_Start").GetComponent<Button>();
            uI_Tweening_Manager = GameObject.Find("TweeningManager").GetComponent<UI_Tweening_Manager>();
            training_Start.onClick.AddListener(TrainingStart);
            

            Skill_Btn[0].onClick.AddListener(Click_Btn_Skill00);
            Skill_Btn[1].onClick.AddListener(Click_Btn_Skill01);
            Skill_Btn[2].onClick.AddListener(Click_Btn_Skill02);
            // Skill_Btn().onClick.AddListener�� �̿��� ���� ��ư�� ���� ���� ����ĭ�� ��ų������ ����. // ��ų����� .
            // ��ų before,after��.
        }
        void Start()
        {
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            uI_trainingManager = GameObject.Find("TrainingManager").GetComponent<Shin.UI_TrainingManager>();
            heroImageTable = GameObject.Find("HeroImageManager").GetComponent<Shin.HeroImageTable>();
            statScript = GetComponent<StatScript>();
            skillScript = GetComponent<SkillScript>();
            equipScript = GetComponent<EquipScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();
            heroName = transform.GetChild(0).GetComponent<Text>();
            heroJob = transform.GetChild(1).GetComponent<Text>();
            heroImage = transform.GetChild(2).GetComponent<Image>();

            gameObject.SetActive(false);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameObject.activeSelf)
                {
                    gameObject.SetActive(false);
                }
            }
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
            heroJob.text = statScript.myStat.Job;

            IndexInit();
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
            uI_Tweening_Manager.UI_TrainingSecPanel_Off();
            uI_trainingManager.Destroy_UI();
            uI_trainingManager.Init_UI();
            gameObject.SetActive(false);
        }

        public void IndexInit()
        {
            for (int i = 0; i < Skill_Btn.Length; i++)
            {
                Skill_Btn[i].name = skillScript.mySkills[i].Index.ToString();
                Skill_Btn[i].image.sprite = skillDetailTable.sprite[skillScript.mySkills[i].Index];
            }
            switch (heroJob.text)
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

            Click_Btn_Skill00();
        }
    
        public void Click_Btn_Skill00()
        {
            detail_Image.sprite = Skill_Btn[0].image.sprite;
            for (int i = 0; i < skillDetailTable.skilldetails.Count; i++)
            {
                if (Skill_Btn[0].name == skillDetailTable.skilldetails[i].skillindex.ToString())
                {
                    detail_Text.text = skillDetailTable.skilldetails[i].skillindex.ToString();
                    detail_Before.text = skillDetailTable.skilldetails[i].skillname;
                    detail_After.text = skillDetailTable.skilldetails[i].skilldetail;
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
                    detail_Text.text = skillDetailTable.skilldetails[i].skillindex.ToString();
                    detail_Before.text = skillDetailTable.skilldetails[i].skillname;
                    detail_After.text = skillDetailTable.skilldetails[i].skilldetail;
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
                    detail_Text.text = skillDetailTable.skilldetails[i].skillindex.ToString();
                    detail_Before.text = skillDetailTable.skilldetails[i].skillname;
                    detail_After.text = skillDetailTable.skilldetails[i].skilldetail;
                }
            }
        }
    }

}

