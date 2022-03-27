using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin
{
    // ������� ���� ��ư Ŭ���� �޷� ����.
    public class UI_EmployedInfo : MonoBehaviour
    {
        public HeroSavingData healingHeroData = new HeroSavingData();
        public StatScript statScript;
        public SkillScript skillScript;
        public EquipScript equipScript;
        public Text text_Name;
        public Text text_Job;


        Shin.UI_ChurchManager uI_ChurchManager;
        Song.HeroManager heroManager;
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
            uI_ChurchManager = GameObject.Find("UI_ChurchManager").GetComponent<Shin.UI_ChurchManager>();
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            statScript = GetComponent<StatScript>();
            skillScript = GetComponent<SkillScript>();
            equipScript = GetComponent<EquipScript>();

            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                if (gameObject.name == heroManager.CurrentHeroDataList[i].stat.Name) // �̸����� ���ؼ� ã��
                {
                    statScript.myStat = heroManager.CurrentHeroDataList[i].stat; // ����.
                    skillScript.skills = heroManager.CurrentHeroDataList[i].skills;
                    equipScript.myEquip = heroManager.CurrentHeroDataList[i].equips;
                }
            }

            text_Name.text = "�̸� : " + statScript.myStat.Name;
            text_Job.text = "���� : " + statScript.myStat.Job;

        }

        public void Create_HealingHero_UI_Prefab() // ��ư Ŭ���� ����.
        {
            gameObject.SetActive(false);
            Destroy(gameObject);

            uI_ChurchManager.healingHero_UI = Instantiate(uI_ChurchManager.healingHero_UI_Prefab, uI_ChurchManager.healing_List_UI_Content.transform); // UI ����.
            uI_ChurchManager.healingHero_UI.name = gameObject.name; // UI ���̹�.


            healingHeroData.stat = statScript.myStat;
            healingHeroData.skills = skillScript.skills;
            healingHeroData.equips = equipScript.myEquip;

            uI_ChurchManager.healingHeroDataList.Add(healingHeroData);

            Debug.Log(uI_ChurchManager.healingHeroDataList[EmployedCnt].stat.Name);

            EmployedCnt++;
        }
    }
}