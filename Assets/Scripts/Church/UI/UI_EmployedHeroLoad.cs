using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin {
    public class UI_EmployedHeroLoad : MonoBehaviour
    {
        public Song.HeroManager heroManager;
        public GameObject employer_List_UI_Content; // 胶农费轰 content
        public GameObject healing_List_UI_Content; // 胶农费轰 content

        public Button employedHero_UI_Prefab; // 积己瞪 橇府普
        public Button healingHero_UI_Prefab; // 积己瞪 橇府普

        public Button[] employedHero_UI;
        public Button[] healingHero_UI;

        int heroCnt;
        
        void Start()
        {
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();

        }

        public void Create_EmployedHero_UI_Prefab()
        {
            heroCnt = heroManager.CurrentHeroList.Count;
            employedHero_UI = new Button[heroManager.CurrentHeroList.Count];
            healingHero_UI = new Button[heroManager.CurrentHeroList.Count];
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                employedHero_UI[i] = Instantiate(employedHero_UI_Prefab, employer_List_UI_Content.transform);
                employedHero_UI[i].name = heroManager.CurrentHeroList[i].name;
            }
        }

        
        
    }
}



