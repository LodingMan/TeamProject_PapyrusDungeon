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

        public StatScript statScript;
        public SkillScript skillScript;
        public EquipScript equipScript;
        public HeroScript_Current_State heroScript_Current_State;
        public Image heroInfo;
        public Text text_Name;
        public Text text_Job;
        public Text testText00;
        public Text testText01;

        public RectTransform heroInfoPopup;
        Button btn;

        private void Awake()
        {
            heroInfoPopup = GameObject.Find("Training_HeroInfo").GetComponent<RectTransform>();
            uI_trainingManager = GameObject.Find("TrainingManager").GetComponent<Shin.UI_TrainingManager>();
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            statScript = GetComponent<StatScript>();
            skillScript = GetComponent<SkillScript>();
            equipScript = GetComponent<EquipScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();

            heroInfo = heroInfoPopup.GetChild(0).GetComponent<Image>();
            testText00 = heroInfoPopup.GetChild(0).GetChild(0).GetComponent<Text>();
            testText01 = heroInfoPopup.GetChild(0).GetChild(1).GetComponent<Text>();
            btn = GetComponent<Button>();

            btn.onClick.AddListener(DoTweenLeftToRight); // ��ư�� ������
            btn.onClick.AddListener(ShowHeroDetail);
            btn.onClick.AddListener(uI_trainingManager.Destroy_UI);
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
                    equipScript.myEquip = heroManager.CurrentHeroList[i].GetComponent<EquipScript>().myEquip;
                    heroScript_Current_State.isTraining = heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isTraining;
                }
            }
            text_Name.text = "�̸� : " + statScript.myStat.Name;
            text_Job.text = "���� : " + statScript.myStat.Job;
        }
        void ShowHeroDetail()
        {
            testText00.text = statScript.myStat.Name;
            testText01.text = statScript.myStat.Job;
            heroInfo.name = testText00.text;
        }
        public void DoTweenLeftToRight()
        {
            heroInfoPopup.DOAnchorPos(new Vector2(0, 0), 0.5f);
        }

    }
}

