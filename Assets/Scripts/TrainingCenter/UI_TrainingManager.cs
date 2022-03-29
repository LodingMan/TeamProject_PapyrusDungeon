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
        public GameObject employer_List_UI_Content; // ��ũ�Ѻ� content

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
        public void Create_EmployedHero_UI() // �Ʒü� ��ư Ŭ�� �� ���� // Onclick
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
        public void Destroy_EmployedHero_UI() // ��ȸ �г��� �ݱ� ��ư Ŭ�� �� ����.
        {

            //employer_List_UI_Content�� child�� �˻��ؼ� ���� �ı�.            
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

