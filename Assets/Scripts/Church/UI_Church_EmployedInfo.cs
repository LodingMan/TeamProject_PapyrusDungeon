using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin
{
    // ������� ���� ��ư Ŭ���� �޷� ����.
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

        public Button btn; // �ڱ� �ڽ��� ��ư.
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
            btn.onClick.AddListener(Create_HealingHero_UI_Prefab); // ��ư�� ������
            btn.onClick.AddListener(ChurchManager.MgrTable.soundMgr.PlayClipContent);

            // �ʱ�ȭ
            curWeek = townMgr.Week;

            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // �̸����� ���ؼ� ã��
                {
                    statScript.myStat = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat; // ����.
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

        public void Create_HealingHero_UI_Prefab() // ��ư Ŭ���� ����.
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