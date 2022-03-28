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

            for (int i = 0; i < uI_ChurchManager.healingHeroDataList.Count; i++) // ����Ʈ ���̸�ŭ.
            {
                if (gameObject.name == uI_ChurchManager.healingHeroDataList[i].stat.Name) // ȸ�����ο�������Ʈ���� �̸����� ���ؼ� ã��
                {
                    statScript.myStat = uI_ChurchManager.healingHeroDataList[i].stat; // ����.
                    skillScript.skills = uI_ChurchManager.healingHeroDataList[i].skills;
                    equipScript.myEquip = uI_ChurchManager.healingHeroDataList[i].equips;
                    heroScript_Current_State.isHealing = true; // ȸ�� ��!
                }
            }

            text_Name.text = "�̸� : " + statScript.myStat.Name;
            text_Job.text = "���� : " + statScript.myStat.Job;

        }

        public void Create_EmployedHero_UI_Prefab()
        {
            // UI ������ ����.
            /*uI_ChurchManager.employedHero_UI = Instantiate(uI_ChurchManager.employedHero_UI_Prefab, uI_ChurchManager.employer_List_UI_Content.transform); // ������Ʈ ����.
            uI_ChurchManager.employedHero_UI.name = gameObject.name; // �̸� ����.*/

            employedHeroData.stat = statScript.myStat;
            employedHeroData.skills = skillScript.skills;
            employedHeroData.equips = equipScript.myEquip;
            // �� ����.


            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++) // search
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // name search
                {
                    //��ȸ���� ���ö� ȸ���ؾ��ϴϱ� ���⿡ �ۼ�.
                    heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat.HP = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat.MAXHP; // hpȸ��
                    heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat.MP = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat.MAXMP; // mpȸ��
                    
                    heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isHealing = false; // heromanager�� �ִ� CurrentHeroList�� ishealing = false 

                }
            }

            for (int i = 0; i < uI_ChurchManager.healingHeroDataList.Count; i++) // search
            {
                if (gameObject.name == uI_ChurchManager.healingHeroDataList[i].stat.Name) //name search
                {
                    uI_ChurchManager.healingHeroDataList.RemoveAt(i); // healingHeroDataList removeat
                }
            }
            //Debug.Log(uI_ChurchManager.healingHeroDataList.Count); // ȸ�� ����Ʈ�� �� �� �� �ִ��� Ȯ�ο�
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }

    }

}