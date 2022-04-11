using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Shin
{
    public class UI_HealingInfo : MonoBehaviour
    {
        Shin.UI_ChurchManager uI_ChurchManager;
        Song.HeroManager heroManager;
        HeroImageTable heroImageTable;
        public TownManager townManager;
        public StatScript statScript;
        public HeroScript_Current_State heroScript_Current_State;
        public Text text_Name;
        public Text text_Job;
        public Button btn; // 자기 자신
        public Image heroIcon;
        
        public int curWeek;
        public static int healingCnt; // 회복중인 영웅 리스트 순서에 사용할 static int
        //public Button btn_ReturnChurch;

        void Start()
        {
            uI_ChurchManager = GameObject.Find("ChurchManager").GetComponent<Shin.UI_ChurchManager>();
            heroManager = uI_ChurchManager.heroManager;
            townManager = uI_ChurchManager.townMgr;
            heroImageTable = uI_ChurchManager.heroImageTable;

            statScript = GetComponent<StatScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();

            btn = GetComponent<Button>();//초기화
            btn.onClick.AddListener(HealingEnd);
            //btn.onClick.AddListener(uI_ChurchManager.soundMgr.PlayClipOption);
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++) // 리스트 길이만큼.
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // 이름 비교해서
                {
                    statScript.myStat = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat; // 값 넣기.
                    heroScript_Current_State.isHealing = heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isHealing;
                }
            }

            text_Name.text = statScript.myStat.Name;
            text_Job.text = statScript.myStat.Job;
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

        public void HealingEnd() // Btn_HealEnd 온클릭
        {
            // **예외조건으로 1주 이상이 지나야 회복조건이 발동되도록 수정해야함.
            // 자기 자신만 되도록 변경.
            if((townManager.Week - curWeek >= 1)) {
                uI_ChurchManager.soundMgr.PlayClipOption();
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
                uI_ChurchManager.soundMgr.FailClipDungeonSelect();
                uI_ChurchManager.isWarning = true;
                uI_ChurchManager.tweenMgr.UI_ChurchWarning_On();
                StartCoroutine(WarningPanelOff());
            }
        }

        IEnumerator WarningPanelOff()
        {
            yield return new WaitForSeconds(1f);
            if (uI_ChurchManager.isWarning)
            {
                uI_ChurchManager.isWarning = false;
            }
            
        }
    }

}