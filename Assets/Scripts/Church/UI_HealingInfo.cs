using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin
{
    public class UI_HealingInfo : MonoBehaviour
    {
        public HeroSavingData employedHeroData = new HeroSavingData();
        Shin.UI_ChurchManager uI_ChurchManager;
        Song.HeroManager heroManager;
        public StatScript statScript;
        public SkillScript skillScript;
        public EquipScript equipScript;
        public HeroScript_Current_State heroScript_Current_State;
        public Text text_Name;
        public Text text_Job;
        public Button btn;

        public static int healingCnt; // ȸ������ ���� ����Ʈ ������ ����� static int
        private void Awake()
        {
            btn = GetComponent<Button>();
            btn.onClick.AddListener(Create_EmployedHero_UI_Prefab); // ��ư�� ������ �Լ� ����.

        }

        void Start()
        {
            uI_ChurchManager = GameObject.Find("ChurchManager").GetComponent<Shin.UI_ChurchManager>();
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            statScript = GetComponent<StatScript>();
            skillScript = GetComponent<SkillScript>();
            equipScript = GetComponent<EquipScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();
            //�ʱ�ȭ

            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++) // ����Ʈ ���̸�ŭ.
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // ȸ�����ο�������Ʈ���� �̸����� ���ؼ� ã��
                {
                    statScript = heroManager.CurrentHeroList[i].GetComponent<StatScript>(); // ����.
                    skillScript= heroManager.CurrentHeroList[i].GetComponent<SkillScript>();
                    equipScript = heroManager.CurrentHeroList[i].GetComponent<EquipScript>();
                    heroScript_Current_State = heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>();
                }
            }

            text_Name.text = "�̸� : " + statScript.myStat.Name;
            text_Job.text = "���� : " + statScript.myStat.Job;

        }

        public void Create_EmployedHero_UI_Prefab()
        {
            // UI ������ ����.
            uI_ChurchManager.employedHero_UI = Instantiate(uI_ChurchManager.employedHero_UI_Prefab, uI_ChurchManager.employer_List_UI_Content.transform); // ������Ʈ ����.
            uI_ChurchManager.employedHero_UI.name = gameObject.name; // �̸� ����.

            employedHeroData.stat = statScript.myStat;
            employedHeroData.skills = skillScript.skills;
            employedHeroData.equips = equipScript.myEquip;
            // �� ����.

            gameObject.SetActive(false);
            Destroy(gameObject);
        }

    }

}