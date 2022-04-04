using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin
{
    // ������� ���� ��ư Ŭ���� �޷� ����.
    public class UI_Church_EmployedInfo : MonoBehaviour
    {
        Song.HeroManager heroManager;
        Shin.UI_ChurchManager uI_ChurchManager;

        //public HeroSavingData healingHeroData = new HeroSavingData();

        public StatScript statScript;
        public HeroScript_Current_State heroScript_Current_State;
        public Text text_Name;
        public Text text_Job;

        
        public Button btn; // �ڱ� �ڽ��� ��ư.
        int num;
        //static public int EmployedCnt = 0;

        private void Awake()
        {
            btn = GetComponent<Button>();
            btn.onClick.AddListener(Create_HealingHero_UI_Prefab); // ��ư�� ������

        }
        private void Start()
        {
            uI_ChurchManager = GameObject.Find("ChurchManager").GetComponent<Shin.UI_ChurchManager>();
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            statScript = GetComponent<StatScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();
            // �ʱ�ȭ

            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // �̸����� ���ؼ� ã��
                {
                    statScript.myStat = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat; // ����.
                }
            }

            text_Name.text = "�̸� : " + statScript.myStat.Name;
            text_Job.text = "���� : " + statScript.myStat.Job;

        }

        public void Create_HealingHero_UI_Prefab() // ��ư Ŭ���� ����.
        {
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name)
                { heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isHealing = true; }
            }
            uI_ChurchManager.Destroy_UI();
            uI_ChurchManager.Init_UI();
            
            Destroy(gameObject);
        }
    }
}