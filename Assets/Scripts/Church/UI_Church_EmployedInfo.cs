using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin
{
    // 고용중인 영웅 버튼 클릭에 달려 있음.
    public class UI_Church_EmployedInfo : MonoBehaviour
    {
        Shin.UI_ChurchManager ChurchManager;
        Song.HeroManager heroManager;
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
            ChurchManager = GameObject.Find("ChurchManager").GetComponent<Shin.UI_ChurchManager>();
            heroManager = ChurchManager.heroManager;
            townMgr = ChurchManager.townMgr;
            heroImageTable = ChurchManager.heroImageTable;
            statScript = GetComponent<StatScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();

            btn = GetComponent<Button>();
            btn.onClick.AddListener(Create_HealingHero_UI_Prefab); // 버튼이 눌리면
            btn.onClick.AddListener(ChurchManager.MgrTable.soundMgr.PlayClipContent);

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

            ChurchManager.healingHero_UI = Instantiate(ChurchManager.healingHero_UI_Prefab, ChurchManager.healing_List_UI_Content.transform);
            ChurchManager.healingHero_UI.name = gameObject.name;
            ChurchManager.healingHero_UI.GetComponent<UI_HealingInfo>().curWeek = curWeek;
            

            ChurchManager.EmployedDestroy_UI();
            ChurchManager.EmployedInit_UI();
            
        }
    }
}