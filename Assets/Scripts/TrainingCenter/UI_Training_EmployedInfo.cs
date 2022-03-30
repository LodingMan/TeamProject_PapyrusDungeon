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
        public HeroScript_Current_State heroScript_Current_State;
        public Image heroInfo;
        public Text text_Name;
        public Text text_Job;

        public RectTransform heroInfoPopup;
        Button btn;

        private void Awake()
        {
            heroInfoPopup = GameObject.Find("Training_HeroInfo").GetComponent<RectTransform>();
            uI_trainingManager = GameObject.Find("TrainingManager").GetComponent<Shin.UI_TrainingManager>();
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            statScript = GetComponent<StatScript>();
            skillScript = GetComponent<SkillScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();

            heroInfo = heroInfoPopup.GetChild(0).GetComponent<Image>();
            btn = GetComponent<Button>();

            btn.onClick.AddListener(DoTweenLeftToRight); // 버튼이 눌리면
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
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // 이름으로 비교해서 찾고
                {
                    statScript.myStat = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat; // 대입.
                    skillScript.skills = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().skills;
                    skillScript.SkillIndex = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().SkillIndex;
                    skillScript.mySkills = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().mySkills;
                    heroScript_Current_State.isTraining = heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isTraining;
                }
            }
            text_Name.text = "이름 : " + statScript.myStat.Name;
            text_Job.text = "직업 : " + statScript.myStat.Job;
        }
        void ShowHeroDetail()
        {
            heroInfo.GetComponent<StatScript>().myStat.Name = statScript.myStat.Name;
            heroInfo.GetComponent<UI_Training_SelectedHeroInfo>().InitHeroInfo();
        }
        public void DoTweenLeftToRight()
        {
            heroInfoPopup.DOAnchorPos(new Vector2(0, 0), 0.5f);
        }

    }
}

