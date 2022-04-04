using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin {
    public class UI_ChurchManager : MonoBehaviour
    {
        public Song.HeroManager heroManager;
        public TownManager townManager;
        public GameObject employer_List_UI_Content; // 스크롤뷰 content
        public GameObject healing_List_UI_Content; // 스크롤뷰 content

        public Button employedHero_UI_Prefab; // 생성될 프리팹
        public Button healingHero_UI_Prefab; // 생성될 프리팹

        public Button employedHero_UI;
        public Button healingHero_UI;

        //public List<HeroSavingData> healingHeroDataList; // 회복중인 영웅 리스트
        public Button[] employedList;
        public Button[] healingList;
        public Button btn_HealStart; // 회복 버튼. 직접 하이어라키에서 넣어줌.
        public Button btn_HealEnd;
        public int curWeek;
        public GameObject churchWarning;

        private void Awake()
        {
            btn_HealStart.onClick.AddListener(HealingStart);
            btn_HealEnd.onClick.AddListener(HealingEnd);
        }

        void Start()
        {
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            townManager = GameObject.Find("TownManager").GetComponent<TownManager>();
            churchWarning.SetActive(false);
        }
        private void Update()
        {
            employedList = employer_List_UI_Content.GetComponentsInChildren<Button>();
            healingList = healing_List_UI_Content.GetComponentsInChildren<Button>();
            curWeek = townManager.Week;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Destroy_UI();
            }
        }
        public void Init_UI() // 교회 버튼 클릭 시 실행.
        {
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isHealing
                    || heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isTraining
                    || heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isParty)
                    continue;
                employedHero_UI = Instantiate(employedHero_UI_Prefab, employer_List_UI_Content.transform);
                employedHero_UI.name = heroManager.CurrentHeroList[i].name;
            }

            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isHealing)
                {
                    healingHero_UI = Instantiate(healingHero_UI_Prefab, healing_List_UI_Content.transform);
                    healingHero_UI.name = heroManager.CurrentHeroList[i].name;
                }
            }
        }
        public void Destroy_UI() // 교회 패널의 닫기 버튼 클릭 시 실행.
        {

            //employer_List_UI_Content의 child를 검색해서 전부 파괴.            
            if (employedList != null)
            {
                for (int i = 0; i < employedList.Length; i++)
                {
                    Destroy(employedList[i].gameObject);
                }
            }
            if (healingList != null)
            {
                for (int i = 0; i < healingList.Length; i++)
                {
                    Destroy(healingList[i].gameObject);
                }
            }
        }

        public void HealingStart() // 회복 버튼 누르면 실행.
        {
            for (int i = 0; i < healingList.Length; i++)
            {
                for (int j = 0; j < heroManager.CurrentHeroList.Count; j++)
                {
                    if (healingList[i].name == heroManager.CurrentHeroList[j].name)
                    { heroManager.CurrentHeroList[j].GetComponent<HeroScript_Current_State>().isHealing = true; }
                }
            }
            Destroy_UI();
            Init_UI();
        }

        public void HealingEnd() // Btn_HealEnd 온클릭
        {
            // **예외조건으로 1주 이상이 지나야 회복조건이 발동되도록 수정해야함.
            
            for (int i = 0; i < healingList.Length; i++)
            {
                for (int j = 0; j < heroManager.CurrentHeroList.Count; j++)
                {
                    if (healingList[i].name == heroManager.CurrentHeroList[j].name)
                    {
                        heroManager.CurrentHeroList[j].GetComponent<HeroScript_Current_State>().isHealing = false;
                        // 회복이 종료될 때 회복되도록.
                        heroManager.CurrentHeroList[j].GetComponent<StatScript>().myStat.HP = heroManager.CurrentHeroList[j].GetComponent<StatScript>().myStat.MAXHP; // hp회복
                        heroManager.CurrentHeroList[j].GetComponent<StatScript>().myStat.MP = heroManager.CurrentHeroList[j].GetComponent<StatScript>().myStat.MAXMP; // mp회복
                    }
                }
            }
            Destroy_UI();
            Init_UI();
        }
    }
}



