using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin
{
    public class UI_TrainingManager : MonoBehaviour
    {
        public Song.HeroManager heroManager;
        public GameObject employer_List_UI_Content; // 스크롤뷰 content

        public Button employedHero_UI_Prefab;
        public Button employedHero_UI;
        void Start()
        {
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void Create_EmployedHero_UI() // 훈련소 버튼 클릭 시 실행 // Onclick
        {
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isTraining == false) // 훈련 중이 아니어야 프리팹 생성
                {
                    employedHero_UI = Instantiate(employedHero_UI_Prefab, employer_List_UI_Content.transform);
                    employedHero_UI.name = heroManager.CurrentHeroList[i].name;
                }
            }
        }
    }
}

