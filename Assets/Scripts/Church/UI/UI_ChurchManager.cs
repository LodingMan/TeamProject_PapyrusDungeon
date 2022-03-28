using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin {
    public class UI_ChurchManager : MonoBehaviour
    {
        public Song.HeroManager heroManager;
        public GameObject employer_List_UI_Content; // 스크롤뷰 content
        public GameObject healing_List_UI_Content; // 스크롤뷰 content

        public Button employedHero_UI_Prefab; // 생성될 프리팹
        public Button healingHero_UI_Prefab; // 생성될 프리팹

        public Button employedHero_UI;
        public Button healingHero_UI;
        
        public List<HeroSavingData> healingHeroDataList; // 회복중인 영웅 리스트
        public Button[] childList;
        void Start()
        {
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            healingHeroDataList = new List<HeroSavingData>(); // 초기화
            
        }

        public void Create_EmployedHero_UI()
        {
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isHealing == false)
                {
                    employedHero_UI = Instantiate(employedHero_UI_Prefab, employer_List_UI_Content.transform);
                    employedHero_UI.name = heroManager.CurrentHeroList[i].name;
                }
            }
            childList = employer_List_UI_Content.GetComponentsInChildren<Button>();
        }
        public void Destroy_EmployedHero_UI()
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
        
    }
}



