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
        public StatScript statScript;
        public SkillScript skillScript;
        public EquipScript equipScript;
        public HeroScript_Current_State heroScript_Current_State;

        public Button training_Start;

        private void Awake()
        {
            training_Start = GameObject.Find("Btn_Training_Start").GetComponent<Button>();
            training_Start.onClick.AddListener(TrainingStart);
            
        }
        void Start()
        {
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            uI_trainingManager = GameObject.Find("TrainingManager").GetComponent<Shin.UI_TrainingManager>();
            statScript = GetComponent<StatScript>();
            skillScript = GetComponent<SkillScript>();
            equipScript = GetComponent<EquipScript>();
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
                    statScript.myStat = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat; // 대입.
                    skillScript.skills = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().skills;
                    equipScript.myEquip = heroManager.CurrentHeroList[i].GetComponent<EquipScript>().myEquip;
                    heroScript_Current_State.isTraining = heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isTraining;
                }
            }
        }

        public void TrainingStart()
        {
            heroScript_Current_State.isTraining = true;
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name)
                {
                    heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isTraining = heroScript_Current_State.isTraining;
                }
            }
            uI_trainingManager.Destroy_UI();
            uI_trainingManager.Init_UI();
        }
    }
}

