using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Shin
{
    public class UI_HealingInfo : MonoBehaviour
    {
        // public HeroSavingData employedHeroData = new HeroSavingData();
        Shin.UI_ChurchManager uI_ChurchManager;
        Song.HeroManager heroManager;
        public TownManager townManager;
        public StatScript statScript;
        public HeroScript_Current_State heroScript_Current_State;
        public Text text_Name;
        public Text text_Job;
        public Button btn; // 자기 자신
        public int curWeek;
        public static int healingCnt; // 회복중인 영웅 리스트 순서에 사용할 static int
        public Button btn_ReturnChurch;
        private void Awake()
        {
            uI_ChurchManager = GameObject.Find("ChurchManager").GetComponent<Shin.UI_ChurchManager>();
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            townManager = GameObject.Find("TownManager").GetComponent<TownManager>();
            btn_ReturnChurch = GameObject.Find("Btn_ReturnChurch").GetComponent<Button>();
            statScript = GetComponent<StatScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();
            btn = GetComponent<Button>();//초기화
            //btn.onClick.AddListener(Create_EmployedHero_UI_Prefab); // 자기자신의 버튼이 눌리면 함수 실행.
            btn.onClick.AddListener(HealingEnd);
        }

        void Start()
        {
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++) // 리스트 길이만큼.
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // 이름 비교해서
                {
                    statScript.myStat = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat; // 값 넣기.
                    heroScript_Current_State.isHealing = heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isHealing;
                }
            }

            text_Name.text = "이름 : " + statScript.myStat.Name;
            text_Job.text = "직업 : " + statScript.myStat.Job;

        }

        public void HealingEnd() // Btn_HealEnd 온클릭
        {
            // **예외조건으로 1주 이상이 지나야 회복조건이 발동되도록 수정해야함.
            // 자기 자신만 되도록 변경.
            if((townManager.Week - curWeek >= 1)) {
                for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
                {
                    if (gameObject.name == heroManager.CurrentHeroList[i].name)
                    {
                        heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isHealing = false;
                        // 회복이 종료될 때 회복되도록.
                        heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat.HP = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat.MAXHP; // hp회복
                        heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat.MP = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat.MAXMP; // mp회복
                    }
                }
                uI_ChurchManager.EmployedDestroy_UI();
                uI_ChurchManager.EmployedInit_UI();
                Destroy(gameObject);
            }
            else
            {
                uI_ChurchManager.tweenMgr.UI_ChurchWarningPanel_On();
                uI_ChurchManager.isWarning = true;
                Debug.Log("아직 1주가 지나지 않음");
            }
            
        }

    }

}