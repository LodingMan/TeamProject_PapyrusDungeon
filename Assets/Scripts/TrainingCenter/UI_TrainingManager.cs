using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Shin
{
    public class UI_TrainingManager : MonoBehaviour
    {
        public Song.HeroManager heroManager;
        public TownManager twMgr;
        public UI_Tweening_Manager tweenMgr;

        public GameObject employer_List_UI_Content; // 스크롤뷰 content
        public GameObject training_List_UI_Content;

        public Button employedHero_UI_Prefab;
        public Button trainingHero_UI_Prefab;
        public Button employedHero_UI;
        public Button trainingHero_UI;

        public GameObject heroInfo;
        public Button[] employedList;
        public Button[] trainingList;

        public Button TrainButton;
        public bool isWarning = false;

        private void Awake()
        {
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            twMgr = GameObject.Find("TownManager").GetComponent<TownManager>();
            tweenMgr = GameObject.Find("TweeningManager").GetComponent<UI_Tweening_Manager>();

            TrainButton.onClick.AddListener(EmployedInit_UI);
        }
        private void Update()
        {
            employedList = employer_List_UI_Content.GetComponentsInChildren<Button>();
            trainingList = training_List_UI_Content.GetComponentsInChildren<Button>();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (tweenMgr.isTrain)
                {
                    if (tweenMgr.isTrainDetail)
                    {
                        if (heroInfo.activeSelf)
                        {
                            heroInfo.SetActive(false);
                        }
                        EmployedDestroy_UI();
                        EmployedInit_UI();
                    }
                    else
                    {
                        isWarning = false;
                        EmployedDestroy_UI();
                    }  
                }
            }
            if (!isWarning)
            {
                tweenMgr.UI_TrainWarning_Off();
            }
        }
        public void EmployedInit_UI() // 훈련소 버튼 클릭 시 실행.
        {
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isHealing
                    || heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isTraining
                    || heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isParty)
                {
                    continue;
                }
                employedHero_UI = Instantiate(employedHero_UI_Prefab, employer_List_UI_Content.transform);
                employedHero_UI.name = heroManager.CurrentHeroList[i].name;
            }

        }
        public void EmployedDestroy_UI() // 훈련소 패널의 닫기 버튼 클릭 시 실행.
        {
            //employer_List_UI_Content의 child를 검색해서 전부 파괴.            
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

