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
        public GameObject training_List_UI_Content;

        public Button employedHero_UI_Prefab;
        public Button trainingHero_UI_Prefab;
        public Button employedHero_UI;
        public Button trainingHero_UI;

        public RectTransform heroInfoPopup;
        public Button[] employedList;
        public Button[] trainingList;

        void Start()
        {
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            heroInfoPopup = GameObject.Find("Training_HeroInfo").GetComponent<RectTransform>();
        }
        private void Update()
        {
            employedList = employer_List_UI_Content.GetComponentsInChildren<Button>();
            trainingList = training_List_UI_Content.GetComponentsInChildren<Button>();
        }
        public void Init_UI() // �Ʒü� ��ư Ŭ�� �� ����.
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

            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isTraining == true)
                {
                    trainingHero_UI = Instantiate(trainingHero_UI_Prefab, training_List_UI_Content.transform);
                    trainingHero_UI.name = heroManager.CurrentHeroList[i].name;
                }
            }

        }
        public void Destroy_UI() // �Ʒü� �г��� �ݱ� ��ư Ŭ�� �� ����.
        {
            //employer_List_UI_Content�� child�� �˻��ؼ� ���� �ı�.            
            if (employedList != null)
            {
                for (int i = 0; i < employedList.Length; i++)
                {
                    Destroy(employedList[i].gameObject);
                }
            }
            if (trainingList != null)
            {
                for (int i = 0; i < trainingList.Length; i++)
                {
                    Destroy(trainingList[i].gameObject);
                }
            }
        }
    }
}

