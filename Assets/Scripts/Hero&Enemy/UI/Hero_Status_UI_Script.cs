using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Song
{
    public class Hero_Status_UI_Script : MonoBehaviour
    {
        public UI_Tweening_Manager uI_Tweening_Manger;
        public Song.GuildManager guildManager;
        public Text[] Status_Texts = new Text[10];
        public Image[] Skills_Icon = new Image[3]; // Shin
        public Image[] Equips_Icon = new Image[2]; // Shin
        public GameObject This_Prefab_Object;
        public HeroManager heroManager;
        public Shin.SkillDetailTable skillDetailTable;
        public Shin.EquipDetailTable equipDetailTable;
        Shin.HeroImageTable heroImageTable;
        public Image heroIcon;

        private void Start()
        {
            uI_Tweening_Manger = GameObject.Find("TweeningManager").GetComponent<UI_Tweening_Manager>();
            heroImageTable = GameObject.Find("HeroImageManager").GetComponent<Shin.HeroImageTable>();
            for (int i = 0; i < Status_Texts.Length; i++)
            {
                Status_Texts[i] = gameObject.transform.GetChild(i).GetComponent<Text>();
            }
            // Shin

        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (uI_Tweening_Manger.UI_isStatusPanel_On)
                {
                    uI_Tweening_Manger.UI_StatusPanel_On();
                }
            }
        }

        public void Open_Status_UI(GameObject Target_Hero)
        {
            Debug.Log("UIOpen");
            uI_Tweening_Manger.UI_StatusPanel_On();
            This_Prefab_Object = Target_Hero;

            Status_Texts[0].text = Target_Hero.GetComponent<StatScript>().myStat.Name;
            Status_Texts[1].text = "HP : " + Target_Hero.GetComponent<StatScript>().myStat.HP + "/" + Target_Hero.GetComponent<StatScript>().myStat.MAXHP;
            Status_Texts[2].text = "MP : " + Target_Hero.GetComponent<StatScript>().myStat.MP + "/" + Target_Hero.GetComponent<StatScript>().myStat.MAXMP;
            Status_Texts[3].text = "ATK : " + Target_Hero.GetComponent<StatScript>().myStat.Atk;
            Status_Texts[4].text = "DEF : " + Target_Hero.GetComponent<StatScript>().myStat.Def;
            Status_Texts[5].text = "CRI : " + Target_Hero.GetComponent<StatScript>().myStat.Cri;
            Status_Texts[6].text = "ACC : " + Target_Hero.GetComponent<StatScript>().myStat.Acc;
            Status_Texts[7].text = "AGI : " + Target_Hero.GetComponent<StatScript>().myStat.Agi;
            Status_Texts[8].text = "SPEED : " + Target_Hero.GetComponent<StatScript>().myStat.Speed;
            // Shin

            for (int i = 0; i < Skills_Icon.Length; i++)
            {
                Skills_Icon[i].sprite = skillDetailTable.sprite[Target_Hero.GetComponent<SkillScript>().mySkills[i].Index];
            }
            for(int i=0; i < Equips_Icon.Length; i++)
            {
                Equips_Icon[i].sprite = equipDetailTable.sprite[Target_Hero.GetComponent<EquipScript>().myEquip[i].Index];
            }
            switch (Target_Hero.GetComponent<StatScript>().myStat.Job)
            {
                case "Babarian":
                    heroIcon.sprite = heroImageTable.sprite[0];
                    break;
                case "Archer":
                    heroIcon.sprite = heroImageTable.sprite[1];
                    break;
                case "Knight":
                    heroIcon.sprite = heroImageTable.sprite[2];
                    break;
                case "Barristan":
                    heroIcon.sprite = heroImageTable.sprite[3];
                    break;
                case "Mage":
                    heroIcon.sprite = heroImageTable.sprite[4];
                    break;
                case "Porter":
                    heroIcon.sprite = heroImageTable.sprite[5];
                    break;
                default:
                    break;
            }
            

        }

        public void FireFunc()     
        {
            guildManager.UpdateMember(This_Prefab_Object);
        }
    }
}
