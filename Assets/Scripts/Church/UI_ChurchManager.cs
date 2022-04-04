using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin {
    public class UI_ChurchManager : MonoBehaviour
    {
        public Song.HeroManager heroManager;
        public TownManager townManager;
        public GameObject employer_List_UI_Content; // ��ũ�Ѻ� content
        public GameObject healing_List_UI_Content; // ��ũ�Ѻ� content

        public Button employedHero_UI_Prefab; // ������ ������
        public Button healingHero_UI_Prefab; // ������ ������

        public Button employedHero_UI;
        public Button healingHero_UI;

        //public List<HeroSavingData> healingHeroDataList; // ȸ������ ���� ����Ʈ
        public Button[] employedList;
        public Button[] healingList;
        public Button btn_HealStart; // ȸ�� ��ư. ���� ���̾��Ű���� �־���.
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
        public void Init_UI() // ��ȸ ��ư Ŭ�� �� ����.
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
        public void Destroy_UI() // ��ȸ �г��� �ݱ� ��ư Ŭ�� �� ����.
        {

            //employer_List_UI_Content�� child�� �˻��ؼ� ���� �ı�.            
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

        public void HealingStart() // ȸ�� ��ư ������ ����.
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

        public void HealingEnd() // Btn_HealEnd ��Ŭ��
        {
            // **������������ 1�� �̻��� ������ ȸ�������� �ߵ��ǵ��� �����ؾ���.
            
            for (int i = 0; i < healingList.Length; i++)
            {
                for (int j = 0; j < heroManager.CurrentHeroList.Count; j++)
                {
                    if (healingList[i].name == heroManager.CurrentHeroList[j].name)
                    {
                        heroManager.CurrentHeroList[j].GetComponent<HeroScript_Current_State>().isHealing = false;
                        // ȸ���� ����� �� ȸ���ǵ���.
                        heroManager.CurrentHeroList[j].GetComponent<StatScript>().myStat.HP = heroManager.CurrentHeroList[j].GetComponent<StatScript>().myStat.MAXHP; // hpȸ��
                        heroManager.CurrentHeroList[j].GetComponent<StatScript>().myStat.MP = heroManager.CurrentHeroList[j].GetComponent<StatScript>().myStat.MAXMP; // mpȸ��
                    }
                }
            }
            Destroy_UI();
            Init_UI();
        }
    }
}



