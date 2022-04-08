using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Shin
{
    public class Tent_HeroStatusInit : MonoBehaviour
    {
        public ItemUseManager itemUseManager;
        public Button Btn_Info;
        UI_Tweening_Manager twMgr;
        public GameObject heroPrefab;
        public Sprite sprite;
        public Image heroIcon;
        public Text[] text_status;
        public Image[] Image_Skills;
        public Image[] Image_Equips;
        private void Awake()
        {
            itemUseManager = GameObject.Find("TentManager").GetComponent<ItemUseManager>();
            twMgr = GameObject.Find("TweeningManager").GetComponent<UI_Tweening_Manager>();
            text_status = new Text[9];
            for (int i = 0; i < text_status.Length; i++)
            {
                text_status[i] = transform.GetChild(i).GetComponent<Text>();
            }

            Btn_Info.onClick.AddListener(twMgr.UI_StatusPanel_Tent_On);
            Btn_Info.onClick.AddListener(StatusInit);
        }

        public void StatusInit()
        {
            heroIcon.sprite = sprite;
            text_status[0].text = heroPrefab.GetComponent<StatScript>().myStat.Name;
            text_status[1].text = "HP : " + heroPrefab.GetComponent<StatScript>().myStat.HP + " / " + heroPrefab.GetComponent<StatScript>().myStat.MAXHP;
            text_status[2].text = "MP : " + heroPrefab.GetComponent<StatScript>().myStat.MP + " / " + heroPrefab.GetComponent<StatScript>().myStat.MAXMP; ;
            text_status[3].text = "ATK : " + heroPrefab.GetComponent<StatScript>().myStat.Atk;
            text_status[4].text = "DEF : " + heroPrefab.GetComponent<StatScript>().myStat.Def;
            text_status[5].text = "CRI : " + heroPrefab.GetComponent<StatScript>().myStat.Cri;
            text_status[6].text = "ACC : " + heroPrefab.GetComponent<StatScript>().myStat.Acc;
            text_status[7].text = "AGI : " + heroPrefab.GetComponent<StatScript>().myStat.Agi;
            text_status[8].text = "SPD : " + heroPrefab.GetComponent<StatScript>().myStat.Speed;
            InitEquipSkill();
        }

        public void InitEquipSkill() // 04.03 Shin. image input function. tent일 때 스킬,장비가 바뀌면 이 함수 호출.
        {
            for (int i = 0; i < itemUseManager.equips.Length; i++)
            {
                Image_Equips[i].sprite = itemUseManager.equips_icon[i].sprite;
            }
            for (int i = 0; i < itemUseManager.mySkills.Length; i++) // 스킬 인덱스
            {
                Image_Skills[i].sprite = itemUseManager.skills_icon[i].sprite;
            }
        }
    }
}

