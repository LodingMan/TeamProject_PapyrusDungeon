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
        public Text text_Name;
        public Text text_Job;

        public RectTransform heroInfoPopup;
        Button btn;
        public Button btn_Training_Start;

        // Start is called before the first frame update
        private void Awake()
        {
            heroInfoPopup = GameObject.Find("Training_HeroInfo").GetComponent<RectTransform>();
            btn = GetComponent<Button>();
            btn_Training_Start = GameObject.Find("Btn_Training_Start").GetComponent<Button>();

            btn.onClick.AddListener(DoTweenLeftToRight); // 버튼이 눌리면
        }
        void Start()
        {
            uI_trainingManager = GameObject.Find("TrainingManager").GetComponent<Shin.UI_TrainingManager>();
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            statScript = GetComponent<StatScript>();
            skillScript = GetComponent<SkillScript>();
            equipScript = GetComponent<EquipScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();

            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // 이름으로 비교해서 찾고
                {
                    statScript.myStat = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat; // 대입.
                    skillScript.skills = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().skills;
                    equipScript.myEquip = heroManager.CurrentHeroList[i].GetComponent<EquipScript>().myEquip;
                    heroScript_Current_State = heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>();
                }
            }
            text_Name.text = "이름 : " + statScript.myStat.Name;
            text_Job.text = "직업 : " + statScript.myStat.Job;
        }
        public void DoTweenLeftToRight()
        {
            heroInfoPopup.DOAnchorPos(new Vector2(0, 0), 0.5f);
        }

    }
}

