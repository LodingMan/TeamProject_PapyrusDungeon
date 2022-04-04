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
        public Button ChurchButton;
        
        public bool isWarning = false;
        private void Awake()
        {
            ChurchButton.onClick.AddListener(EmployedInit_UI);
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
                    EmployedDestroy_UI();
                    EmployedInit_UI();
                    isWarning = false;
                }
                else
                {
                    EmployedDestroy_UI();
                }
            }
        }
        public void EmployedInit_UI() // ��ȸ ��ư Ŭ�� �� ����.
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

        }
        public void EmployedDestroy_UI() // ��ȸ �г��� �ݱ� ��ư Ŭ�� �� ����.
        {
            //employer_List_UI_Content�� child�� �˻��ؼ� ���� �ı�.            
            if (employedList != null)
            {
                for (int i = 0; i < employedList.Length; i++)
                {
                    Destroy(employedList[i].gameObject);
                }
            }
        }
        public void HealingInit_UI()
        {
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isHealing)
                {
                    healingHero_UI = Instantiate(employedHero_UI_Prefab, employer_List_UI_Content.transform);
                    healingHero_UI.name = heroManager.CurrentHeroList[i].name;
                }
            }
        }
        public void HealingDestroy_UI()
        {
            if (healingList != null)
            {
                for (int i = 0; i < healingList.Length; i++)
                {
                    Destroy(healingList[i].gameObject);
                }
            }
        }
        

        
    }
}



