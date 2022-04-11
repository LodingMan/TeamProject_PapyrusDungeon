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
        TownManager townMgr;
        HeroImageTable heroImageTable;

        public StatScript statScript;
        public HeroScript_Current_State heroScript_Current_State;
        public Text text_Name;
        public Text text_Job;
        public Image heroIcon;
        public Text HP;
        public Text MP;

        public Button btn; // 자기 자신의 버튼.
        int num;
        public int curWeek;

        private void Start()
        {
            uI_ChurchManager = GameObject.Find("ChurchManager").GetComponent<Shin.UI_ChurchManager>();
            heroManager = uI_ChurchManager.heroManager;
            townMgr = uI_ChurchManager.townMgr;
            heroImageTable = uI_ChurchManager.heroImageTable;
            statScript = GetComponent<StatScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();

            btn = GetComponent<Button>();
            btn.onClick.AddListener(Create_HealingHero_UI_Prefab); // 버튼이 눌리면
            btn.onClick.AddListener(uI_ChurchManager.soundMgr.PlayClipOption);

            // 초기화
            curWeek = townMgr.Week;

            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // 이름으로 비교해서 찾고
                {
                    statScript.myStat = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat; // 대입.
                }
            }

            text_Name.text = statScript.myStat.Name;
            text_Job.text = statScript.myStat.Job;
            HP.text = "HP : " + statScript.myStat.HP + " / " + statScript.myStat.MAXHP;
            MP.text = "MP : " + statScript.myStat.MP + " / " + statScript.myStat.MAXMP;
            switch (statScript.myStat.Job)
            {
                case "Babarian":
                    heroIcon.sprite = heroImageTable.sprite[0];
                    break;
                case "Archer":
                    heroIcon.sprite = heroImageTable.sprite[1];
                    break;
                case "Knight":
                    heroIcon.sprite = heroImageTable.sprite[2];
                    break;
                case "Barristan":
                    heroIcon.sprite = heroImageTable.sprite[3];
                    break;
                case "Mage":
                    heroIcon.sprite = heroImageTable.sprite[4];
                    break;
                case "Porter":
                    heroIcon.sprite = heroImageTable.sprite[5];
                    break;
                default:
                    break;
            }
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