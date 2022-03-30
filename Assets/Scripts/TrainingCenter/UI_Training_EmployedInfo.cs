using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Shin
{
    public class UI_Training_EmployedInfo : MonoBehaviour
    {
        Song.HeroManager heroManager;
        Shin.UI_TrainingManager uI_trainingManager;
        UI_Tweening_Manager uI_Tweening_Manager;
        public StatScript statScript;
        public SkillScript skillScript;
        public HeroScript_Current_State heroScript_Current_State;
        public Image heroInfo;
        public Text text_Name;
        public Text text_Job;

        
        Button btn;

        private void Awake()
        {
            uI_trainingManager = GameObject.Find("TrainingManager").GetComponent<Shin.UI_TrainingManager>();
            uI_Tweening_Manager = GameObject.Find("TweeningManager").GetComponent<UI_Tweening_Manager>();
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            statScript = GetComponent<StatScript>();
            skillScript = GetComponent<SkillScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();

            heroInfo = GameObject.Find("Training_HeroInfo").transform.GetChild(0).GetComponent<Image>();
            btn = GetComponent<Button>();

            btn.onClick.AddListener(uI_Tweening_Manager.UI_TrainingSecPanel_On); // ��ư�� ������
            btn.onClick.AddListener(ShowHeroDetail);
        }
        private void Update()
        {
            Init_UI();
        }

        public void Init_UI()
        {
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // �̸����� ���ؼ� ã��
                {
                    statScript.myStat = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat; // ����.
                    skillScript.skills = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().skills;
                    skillScript.SkillIndex = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().SkillIndex;
                    skillScript.mySkills = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().mySkills;
                    heroScript_Current_State.isTraining = heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isTraining;
                }
            }
            text_Name.text = "�̸� : " + statScript.myStat.Name;
            text_Job.text = "���� : " + statScript.myStat.Job;
        }
        void ShowHeroDetail()
        {
            heroInfo.name = statScript.myStat.Name;
            heroInfo.GetComponent<UI_Training_SelectedHeroInfo>().InitHeroInfo();
        }

    }
}

