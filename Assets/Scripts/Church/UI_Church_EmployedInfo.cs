using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin
{
    // 고용중인 영웅 버튼 클릭에 달려 있음.
    public class UI_Church_EmployedInfo : MonoBehaviour
    {
        Song.HeroManager heroManager;
        Shin.UI_ChurchManager uI_ChurchManager;

        public HeroSavingData healingHeroData = new HeroSavingData();
        public StatScript statScript;
        public SkillScript skillScript;
        public EquipScript equipScript;
        public HeroScript_Current_State heroScript_Current_State;
        public Text text_Name;
        public Text text_Job;

        
        public Button btn; // 자기 자신의 버튼.
        int num;
        static public int EmployedCnt = 0;

        private void Awake()
        {
            btn = GetComponent<Button>();
            btn.onClick.AddListener(Create_HealingHero_UI_Prefab); // 버튼이 눌리면

        }
        private void Start()
        {
            uI_ChurchManager = GameObject.Find("ChurchManager").GetComponent<Shin.UI_ChurchManager>();
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            statScript = GetComponent<StatScript>();
            skillScript = GetComponent<SkillScript>();
            equipScript = GetComponent<EquipScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();
            // 초기화

            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // 이름으로 비교해서 찾고
                {
                    statScript.myStat = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat; // 대입.
                    skillScript.skills = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().skills;
                    equipScript.myEquip = heroManager.CurrentHeroList[i].GetComponent<EquipScript>().myEquip;
                }
            }

            text_Name.text = "이름 : " + statScript.myStat.Name;
            text_Job.text = "직업 : " + statScript.myStat.Job;

        }

        public void Create_HealingHero_UI_Prefab() // 버튼 클릭시 실행.
        {
            uI_ChurchManager.healingHero_UI = Instantiate(uI_ChurchManager.healingHero_UI_Prefab, uI_ChurchManager.healing_List_UI_Content.transform); // UI 생성.
            uI_ChurchManager.healingHero_UI.name = gameObject.name; // UI 네이밍.

            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++) // 서치
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // 이름 같은거 서치
                {
                    heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isHealing = true;
                    // heromanager에 있는 CurrentHeroList의 ishealing = true
                }
            }
            
            // parameter input
            healingHeroData.stat = statScript.myStat;
            healingHeroData.skills = skillScript.skills;
            healingHeroData.equips = equipScript.myEquip;

            uI_ChurchManager.healingHeroDataList.Add(healingHeroData); // healingHeroDataList 리스트에 ADD
            //Debug.Log(uI_ChurchManager.healingHeroDataList.Count); // 회복 리스트에 몇 개 들어가 있는지 확인용

            EmployedCnt++; // healingHeroDataList[순서]에 사용할 static 변수.
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}