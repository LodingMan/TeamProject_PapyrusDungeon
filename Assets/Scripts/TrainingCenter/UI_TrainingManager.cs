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
        public GameObject employer_List_UI_Content; // 스크롤뷰 content

        public Button employedHero_UI_Prefab;
        public Button employedHero_UI;
        public RectTransform heroInfoPopup;
        public Button[] childList;
        void Start()
        {
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            heroInfoPopup = GameObject.Find("Training_HeroInfo").GetComponent<RectTransform>();
        }
        private void Update()
        {
            childList = employer_List_UI_Content.GetComponentsInChildren<Button>();
        }
        public void Create_EmployedHero_UI() // 훈련소 버튼 클릭 시 실행 // Onclick
        {
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isHealing 
                    || heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isTraining)
                    continue;
                employedHero_UI = Instantiate(employedHero_UI_Prefab, employer_List_UI_Content.transform);
                employedHero_UI.name = heroManager.CurrentHeroList[i].name;
            }
        }
        public void Destroy_EmployedHero_UI() // 교회 패널의 닫기 버튼 클릭 시 실행.
        {

            //employer_List_UI_Content의 child를 검색해서 전부 파괴.            
            if (childList != null)
            {
                for (int i = 0; i < childList.Length; i++)
                {
                    Destroy(childList[i].gameObject);
                }
            }
        }
        public void DoTweenLeftToRight()
        {
            heroInfoPopup.DOAnchorPos(new Vector2(0, 0), 0.5f);
        }
        public void DoTweenRightToLeft()
        {
            heroInfoPopup.DOAnchorPos(new Vector2(-1950, 0), 0.5f);
        }


        
    }
}

