using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin
{
    public class UI_TrainingManager : MonoBehaviour
    {
        public Song.HeroManager heroManager;
        public GameObject employer_List_UI_Content; // ��ũ�Ѻ� content

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
        public void Create_EmployedHero_UI() // �Ʒü� ��ư Ŭ�� �� ���� // Onclick
        {
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isTraining == false) // �Ʒ� ���� �ƴϾ�� ������ ����
                {
                    employedHero_UI = Instantiate(employedHero_UI_Prefab, employer_List_UI_Content.transform);
                    employedHero_UI.name = heroManager.CurrentHeroList[i].name;
                }
            }
        }
    }
}

