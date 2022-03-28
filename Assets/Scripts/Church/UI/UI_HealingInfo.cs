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

        public static int healingCnt; // 회복중인 영웅 리스트 순서에 사용할 static int
        private void Awake()
        {
            btn = GetComponent<Button>();
            btn.onClick.AddListener(Create_EmployedHero_UI_Prefab); // 버튼이 눌리면 함수 실행.

        }

        void Start()
        {
            uI_ChurchManager = GameObject.Find("ChurchManager").GetComponent<Shin.UI_ChurchManager>();
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            statScript = GetComponent<StatScript>();
            skillScript = GetComponent<SkillScript>();
            equipScript = GetComponent<EquipScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();
            //초기화

            for (int i = 0; i < uI_ChurchManager.healingHeroDataList.Count; i++) // 리스트 길이만큼.
            {
                if (gameObject.name == uI_ChurchManager.healingHeroDataList[i].stat.Name) // 회복중인영웅리스트에서 이름으로 비교해서 찾고
                {
                    statScript.myStat = uI_ChurchManager.healingHeroDataList[i].stat; // 대입.
                    skillScript.skills = uI_ChurchManager.healingHeroDataList[i].skills;
                    equipScript.myEquip = uI_ChurchManager.healingHeroDataList[i].equips;
                    heroScript_Current_State.isHealing = true; // 회복 중!
                }
            }

            text_Name.text = "이름 : " + statScript.myStat.Name;
            text_Job.text = "직업 : " + statScript.myStat.Job;

        }

        public void Create_EmployedHero_UI_Prefab()
        {
            // UI 프리팹 생성.
            /*uI_ChurchManager.employedHero_UI = Instantiate(uI_ChurchManager.employedHero_UI_Prefab, uI_ChurchManager.employer_List_UI_Content.transform); // 오브젝트 생성.
            uI_ChurchManager.employedHero_UI.name = gameObject.name; // 이름 변경.*/

            employedHeroData.stat = statScript.myStat;
            employedHeroData.skills = skillScript.skills;
            employedHeroData.equips = equipScript.myEquip;
            // 값 대입.


            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++) // search
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // name search
                {
                    //교회에서 나올때 회복해야하니까 여기에 작성.
                    heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat.HP = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat.MAXHP; // hp회복
                    heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat.MP = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat.MAXMP; // mp회복
                    
                    heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isHealing = false; // heromanager에 있는 CurrentHeroList의 ishealing = false 

                }
            }

            for (int i = 0; i < uI_ChurchManager.healingHeroDataList.Count; i++) // search
            {
                if (gameObject.name == uI_ChurchManager.healingHeroDataList[i].stat.Name) //name search
                {
                    uI_ChurchManager.healingHeroDataList.RemoveAt(i); // healingHeroDataList removeat
                }
            }
            //Debug.Log(uI_ChurchManager.healingHeroDataList.Count); // 회복 리스트에 몇 개 들어가 있는지 확인용
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }

    }

}