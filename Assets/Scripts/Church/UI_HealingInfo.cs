using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin
{
    public class UI_HealingInfo : MonoBehaviour
    {
        // public HeroSavingData employedHeroData = new HeroSavingData();
        Shin.UI_ChurchManager uI_ChurchManager;
        Song.HeroManager heroManager;
        public StatScript statScript;
        public HeroScript_Current_State heroScript_Current_State;
        public Text text_Name;
        public Text text_Job;
        public Button btn; // 자기 자신

        public static int healingCnt; // 회복중인 영웅 리스트 순서에 사용할 static int
        private void Awake()
        {
            btn = GetComponent<Button>();
            btn.onClick.AddListener(Create_EmployedHero_UI_Prefab); // 자기자신의 버튼이 눌리면 함수 실행.

        }

        void Start()
        {
            uI_ChurchManager = GameObject.Find("ChurchManager").GetComponent<Shin.UI_ChurchManager>();
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            statScript = GetComponent<StatScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();
            //초기화

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

        public void Create_EmployedHero_UI_Prefab()
        {
            // UI 프리팹 생성.
            uI_ChurchManager.employedHero_UI = Instantiate(uI_ChurchManager.employedHero_UI_Prefab, uI_ChurchManager.employer_List_UI_Content.transform); // 오브젝트 생성.
            uI_ChurchManager.employedHero_UI.name = gameObject.name; // 이름 변경.

            gameObject.SetActive(false);
            Destroy(gameObject);
        }

    }

}