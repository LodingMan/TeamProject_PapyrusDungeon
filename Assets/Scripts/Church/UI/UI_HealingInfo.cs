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
        public Text text_Name;
        public Text text_Job;
        public Button btn;

        public static int healingCnt;
        private void Awake()
        {
            btn = GetComponent<Button>();
            btn.onClick.AddListener(Create_EmployedHero_UI_Prefab); // 버튼이 눌리면

        }

        void Start()
        {
            uI_ChurchManager = GameObject.Find("UI_ChurchManager").GetComponent<Shin.UI_ChurchManager>();
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            statScript = GetComponent<StatScript>();
            skillScript = GetComponent<SkillScript>();
            equipScript = GetComponent<EquipScript>();

            for (int i = 0; i < uI_ChurchManager.healingHeroDataList.Count; i++) // 리스트 길이만큼.
            {
                if (gameObject.name == uI_ChurchManager.healingHeroDataList[i].stat.Name) // 회복중인영웅리스트에서 이름으로 비교해서 찾고
                {
                    statScript.myStat = uI_ChurchManager.healingHeroDataList[i].stat; // 대입.
                    skillScript.skills = uI_ChurchManager.healingHeroDataList[i].skills;
                    equipScript.myEquip = uI_ChurchManager.healingHeroDataList[i].equips;
                }
            }

            text_Name.text = "이름 : " + statScript.myStat.Name;
            text_Job.text = "직업 : " + statScript.myStat.Job;
        }

        public void Create_EmployedHero_UI_Prefab()
        {
            gameObject.SetActive(false);
            Destroy(gameObject);

            uI_ChurchManager.employedHero_UI = Instantiate(uI_ChurchManager.employedHero_UI_Prefab, uI_ChurchManager.employer_List_UI_Content.transform);
            uI_ChurchManager.employedHero_UI.name = gameObject.name;

            employedHeroData.stat = statScript.myStat;
            employedHeroData.skills = skillScript.skills;
            employedHeroData.equips = equipScript.myEquip;


        }

    }

}