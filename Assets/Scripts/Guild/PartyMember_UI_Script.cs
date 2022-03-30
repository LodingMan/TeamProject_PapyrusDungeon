using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace Song
{


    public class PartyMember_UI_Script : MonoBehaviour//, IDropHandler
    {
        public GameObject This_Prefab_Object;
        Transform root;
        public UI_Central uI_Central;
        Song.Current_Hero_UI_Script current_Hero_UI;
        Song.GuildManager guildManager;
        public bool isParty_Hero_In = false;
        public bool isPointerDown = false;
        public float downTime;


        private void Start()
        {
            uI_Central = GameObject.Find("Canvas").GetComponent<UI_Central>();
            root = transform.root;
        }
        private void Update()
        {
            if(isPointerDown)
            {
                downTime += Time.deltaTime;
            }
            else
            {
                downTime = 0;
            }

            if(downTime > 2)
            {
                SlotClear();
                downTime = 0;
                isPointerDown = false;
            }

            
        }

        public void PointerDown()
        {
            isPointerDown = true;
        }
        public void PointerUp()
        {
            isPointerDown = false;
        }

        public void SlotClear()
        {

            This_Prefab_Object.GetComponent<HeroScript_Current_State>().isParty = false;
            isParty_Hero_In = false;
            gameObject.transform.GetChild(0).GetComponent<Text>().text = "";
            gameObject.transform.GetChild(1).GetComponent<Text>().text = "";
            gameObject.transform.GetChild(2).GetComponent<Text>().text = "";


            This_Prefab_Object = null;
        }

        public void Pointer_Drop()
        {
            Debug.Log("UP");
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
                        gameObject.transform.GetChild(0).GetComponent<Text>().text = "Name : " + This_Prefab_Object.GetComponent<StatScript>().myStat.Name;
                        gameObject.transform.GetChild(1).GetComponent<Text>().text = "Class : " + This_Prefab_Object.GetComponent<StatScript>().myStat.Job;
                        gameObject.transform.GetChild(2).GetComponent<Text>().text = "HP : " + This_Prefab_Object.GetComponent<StatScript>().myStat.HP;




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

        public void FireFunc() //해고
        {
            guildManager.UpdateMember(This_Prefab_Object);
        }

    }
}
