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

        public HeroSavingData healingHeroData = new HeroSavingData();
        public StatScript statScript;
        public SkillScript skillScript;
        public EquipScript equipScript;
        public HeroScript_Current_State heroScript_Current_State;
        public Text text_Name;
        public Text text_Job;

        
        public Button btn; // �ڱ� �ڽ��� ��ư.
        int num;
        static public int EmployedCnt = 0;

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
            skillScript = GetComponent<SkillScript>();
            equipScript = GetComponent<EquipScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();
            // �ʱ�ȭ

            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // �̸����� ���ؼ� ã��
                {
                    statScript.myStat = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat; // ����.
                    skillScript.skills = heroManager.CurrentHeroList[i].GetComponent<SkillScript>().skills;
                    equipScript.myEquip = heroManager.CurrentHeroList[i].GetComponent<EquipScript>().myEquip;
                }
            }

            text_Name.text = "�̸� : " + statScript.myStat.Name;
            text_Job.text = "���� : " + statScript.myStat.Job;

        }

        public void Create_HealingHero_UI_Prefab() // ��ư Ŭ���� ����.
        {
            uI_ChurchManager.healingHero_UI = Instantiate(uI_ChurchManager.healingHero_UI_Prefab, uI_ChurchManager.healing_List_UI_Content.transform); // UI ����.
            uI_ChurchManager.healingHero_UI.name = gameObject.name; // UI ���̹�.

            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++) // ��ġ
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // �̸� ������ ��ġ
                {
                    heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isHealing = true;
                    // heromanager�� �ִ� CurrentHeroList�� ishealing = true
                }
            }
            
            // parameter input
            healingHeroData.stat = statScript.myStat;
            healingHeroData.skills = skillScript.skills;
            healingHeroData.equips = equipScript.myEquip;

            uI_ChurchManager.healingHeroDataList.Add(healingHeroData); // healingHeroDataList ����Ʈ�� ADD
            //Debug.Log(uI_ChurchManager.healingHeroDataList.Count); // ȸ�� ����Ʈ�� �� �� �� �ִ��� Ȯ�ο�

            EmployedCnt++; // healingHeroDataList[����]�� ����� static ����.
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}