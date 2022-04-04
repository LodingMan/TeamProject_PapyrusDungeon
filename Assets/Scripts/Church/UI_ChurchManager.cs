using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin {
    public class UI_ChurchManager : MonoBehaviour
    {
        public Song.HeroManager heroManager;
        public TownManager twMgr;
        public UI_Tweening_Manager tweenMgr;
        public GameObject employer_List_UI_Content; // ��ũ�Ѻ� content
        public GameObject healing_List_UI_Content; // ��ũ�Ѻ� content

        public Button employedHero_UI_Prefab; // ������ ������
        public Button healingHero_UI_Prefab; // ������ ������

        public Button employedHero_UI;
        public Button healingHero_UI;

        //public List<HeroSavingData> healingHeroDataList; // ȸ������ ���� ����Ʈ
        public Button[] employedList;
        public Button[] healingList;
        public Button btn_HealEnd;
        public int curWeek;
        public bool isWarning = false;

        private void Awake()
        {
            btn_HealEnd.onClick.AddListener(HealingEnd);
        }
        void Start()
        {
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            twMgr = GameObject.Find("TownManager").GetComponent<TownManager>();
            tweenMgr = GameObject.Find("TweeningManager").GetComponent<UI_Tweening_Manager>();
        }
        private void Update()
        {
            employedList = employer_List_UI_Content.GetComponentsInChildren<Button>();
            healingList = healing_List_UI_Content.GetComponentsInChildren<Button>();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isWarning)
                {
                    Destroy_UI();
                    Init_UI();
                    isWarning = false;
                }
                else
                {
                    Destroy_UI();
                }
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

        public void HealingEnd() // Btn_HealEnd ��Ŭ�� // ���Ͱ����� �ο� ��ü ����
        {
            int check = 0; // ���� �ο�üũ�� int.
            for (int i = 0; i < healingList.Length; i++)
            {
                for (int j = 0; j < heroManager.CurrentHeroList.Count; j++)
                {
                    if (healingList[i].name == heroManager.CurrentHeroList[j].name)
                    {
                        if ((twMgr.Week - healingList[i].GetComponent<UI_HealingInfo>().curWeek) >= 1)
                        {
                            check++;
                            healingList[i].GetComponent<HeroScript_Current_State>().isHealing = false;
                            heroManager.CurrentHeroList[j].GetComponent<HeroScript_Current_State>().isHealing = false;
                            // ȸ���� ����� �� ȸ���ǵ���.
                            heroManager.CurrentHeroList[j].GetComponent<StatScript>().myStat.HP = heroManager.CurrentHeroList[j].GetComponent<StatScript>().myStat.MAXHP; // hpȸ��
                            heroManager.CurrentHeroList[j].GetComponent<StatScript>().myStat.MP = heroManager.CurrentHeroList[j].GetComponent<StatScript>().myStat.MAXMP; // mpȸ��
                        }
                    }
                }
            }
            if (check == 0) // ���Ͱ����� �ο��� 1�� ������.
            {
                tweenMgr.UI_ChurchWarningPanel_On();
                isWarning = true;
            }
            else
            {
                Destroy_UI();
                Init_UI();
            }
            
        }
    }
}



