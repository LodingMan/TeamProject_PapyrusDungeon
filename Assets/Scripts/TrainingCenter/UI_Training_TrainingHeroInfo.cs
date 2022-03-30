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

        public Button btn; // 자기자신버튼
        private void Awake()
        {
            btn = GetComponent<Button>();
        }
        // Start is called before the first frame update
        void Start()
        {
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            uI_trainingManager = GameObject.Find("TrainingManager").GetComponent<Shin.UI_TrainingManager>();
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
                }
            }
        }
        //TrainingStart() 함수는 UI_Training_SelectedHeroInfo 스크립트에 있음.
        public void TrainingEnd()
        {
            // 예외조건 처리 필요. n주차 이상 지나야 가능하도록.
            heroScript_Current_State.isTraining = false;
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name)
                {
                    heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isTraining = heroScript_Current_State.isTraining;
                    // 스킬레벨업
                }
            }
            // 변경사항이 있으니 다시 UI 파괴&생성
            uI_trainingManager.Destroy_UI();
            uI_trainingManager.Init_UI();
        }
    }
}

