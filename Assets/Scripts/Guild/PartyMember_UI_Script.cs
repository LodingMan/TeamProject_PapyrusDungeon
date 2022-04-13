using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace Song
{


    public class PartyMember_UI_Script : MonoBehaviour//, IDropHandler
    {
        public ManagerTable MgrTable;
        public GameObject This_Prefab_Object;
        public Song.GuildManager guildManager;
        Transform root;
        public UI_Central uI_Central;
        Song.Current_Hero_UI_Script current_Hero_UI;
        public Shin.HeroImageTable heroImageTable; // Shin
        public Image heroIcon;
        public Text HP;
        public Text MP;
        public bool isParty_Hero_In = false;
        public bool isPointerDown = false;
        public float downTime;


        private void Start()
        {
            MgrTable = GameObject.Find("ManagerTable").GetComponent<ManagerTable>();
            guildManager = MgrTable.guildManager;
            heroImageTable = MgrTable.heroImageTable;
            uI_Central = GameObject.Find("Canvas").GetComponent<UI_Central>();
            
            root = transform.root;
        }

        public void PointerDown()
        {
            isPointerDown = true;
            SlotClear();

        }
        public void SlotClear()
        {

            if(isParty_Hero_In == true)
            {
                This_Prefab_Object.GetComponent<HeroScript_Current_State>().isParty = false;
                isParty_Hero_In = false;
                gameObject.transform.GetChild(0).GetComponent<Text>().text = "";
                gameObject.transform.GetChild(1).GetComponent<Text>().text = "";
                gameObject.transform.GetChild(3).GetComponent<Text>().text = "";
                gameObject.transform.GetChild(4).GetComponent<Text>().text = "";
                gameObject.transform.GetChild(2).GetComponent<Image>().sprite = heroImageTable.sprite[6];

                for (int i = 0; i < guildManager.Party_Hero_Member.Length; i++)
                {

                    if (guildManager.Party_Hero_Member[i] == This_Prefab_Object)
                    {
                        guildManager.Party_Hero_Member[i] = null;
                    }

                }

                This_Prefab_Object = null;
                MgrTable.soundMgr.PlayClipMenu();
            }

        }

        public void Pointer_Drop()
        {
            //Debug.Log("UP");
            if (This_Prefab_Object == null && uI_Central.Catch_Hero_Object != null)
            {
                if (uI_Central.Catch_Hero_Object.GetComponent<HeroScript_Current_State>().isTraining == false
                    && uI_Central.Catch_Hero_Object.GetComponent<HeroScript_Current_State>().isHealing == false)
                {
                    if (uI_Central.Catch_Hero_Object.GetComponent<HeroScript_Current_State>().isParty == false)
                    {
                        This_Prefab_Object = uI_Central.Catch_Hero_Object;
                        This_Prefab_Object.GetComponent<HeroScript_Current_State>().isParty = true;
                        isParty_Hero_In = true;
                        gameObject.transform.GetChild(0).GetComponent<Text>().text = This_Prefab_Object.GetComponent<StatScript>().myStat.Name;
                        HP.text = "HP : " + This_Prefab_Object.GetComponent<StatScript>().myStat.HP + " / " + This_Prefab_Object.GetComponent<StatScript>().myStat.MAXHP;
                        MP.text = "MP : " + This_Prefab_Object.GetComponent<StatScript>().myStat.MP + " / " + This_Prefab_Object.GetComponent<StatScript>().myStat.MAXMP;
                        guildManager.Party_Hero_Member[int.Parse(gameObject.name)] = This_Prefab_Object;
                        switch (This_Prefab_Object.GetComponent<StatScript>().myStat.Job)
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
                    else
                    {
                        Debug.Log("이미 맴버에 포함되어있음");
                    }
                }
                else
                {
                    Debug.Log("회복 / 훈련중");
                }

            }
        }


    }
}
