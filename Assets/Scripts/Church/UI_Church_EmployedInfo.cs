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
        TownManager twMgr;
        //public HeroSavingData healingHeroData = new HeroSavingData();

        public StatScript statScript;
        public HeroScript_Current_State heroScript_Current_State;
        public Text text_Name;
        public Text text_Job;
        public Slider HP_Bar;
        public Slider MP_Bar;

        public Button btn; // 자기 자신의 버튼.
        int num;
        public int curWeek;
        //static public int EmployedCnt = 0;

        private void Awake()
        {
            btn = GetComponent<Button>();
            btn.onClick.AddListener(Create_HealingHero_UI_Prefab); // 버튼이 눌리면
        }
        private void Start()
        {
            uI_ChurchManager = GameObject.Find("ChurchManager").GetComponent<Shin.UI_ChurchManager>();
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            twMgr = GameObject.Find("TownManager").GetComponent<TownManager>();
            statScript = GetComponent<StatScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();
            // 초기화
            curWeek = twMgr.Week;

            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // 이름으로 비교해서 찾고
                {
                    statScript.myStat = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat; // 대입.
                }
            }

            text_Name.text = statScript.myStat.Name;
            text_Job.text = statScript.myStat.Job;

        }

        public void Create_HealingHero_UI_Prefab() // 버튼 클릭시 실행.
        {
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name)
                { heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isHealing = true; }
            }

            uI_ChurchManager.healingHero_UI = Instantiate(uI_ChurchManager.healingHero_UI_Prefab, uI_ChurchManager.healing_List_UI_Content.transform);
            uI_ChurchManager.healingHero_UI.name = gameObject.name;
            uI_ChurchManager.healingHero_UI.GetComponent<UI_HealingInfo>().curWeek = curWeek;

            uI_ChurchManager.EmployedDestroy_UI();
            uI_ChurchManager.EmployedInit_UI();
        }
    }
}