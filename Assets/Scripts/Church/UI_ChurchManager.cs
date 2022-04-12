using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Song;

namespace Shin {
    public class UI_ChurchManager : MonoBehaviour
    {
        public ManagerTable MgrTable;
        public Song.HeroManager heroManager;
        public TownManager townMgr;
        public UI_Tweening_Manager tweenMgr;
        public UI_SoundMgr soundMgr;
        public HeroImageTable heroImageTable;

        public GameObject employer_List_UI_Content; // ��ũ�Ѻ� content
        public GameObject healing_List_UI_Content; // ��ũ�Ѻ� content

        public Button employedHero_UI_Prefab; // ������ ������
        public Button healingHero_UI_Prefab; // ������ ������

        public Button employedHero_UI;
        public Button healingHero_UI;

        public Button[] employedList;
        public Button[] healingList;
        public Button ChurchButton;
        
        public bool isWarning = false;
        void Start()
        {
            MgrTable = GameObject.Find("ManagerTable").GetComponent<ManagerTable>();
            heroManager = MgrTable.heroManager;
            townMgr = MgrTable.townManager;
            tweenMgr = MgrTable.tweenManager;
            soundMgr = MgrTable.soundMgr;
            heroImageTable = MgrTable.heroImageTable;

            ChurchButton.onClick.AddListener(EmployedInit_UI);
        }
        private void Update()
        {
            employedList = employer_List_UI_Content.GetComponentsInChildren<Button>();
            healingList = healing_List_UI_Content.GetComponentsInChildren<Button>();
            
            if (!isWarning)
            {
                tweenMgr.UI_ChurchWarning_Off();
            }
            if (MgrTable.townManager.Week == 2 && healingList.Length >= 1)
            {
                MgrTable.TutorialMgr.ChurchTuto01Off();
                MgrTable.TutorialMgr.ChurchTuto02On();
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
    }
}



