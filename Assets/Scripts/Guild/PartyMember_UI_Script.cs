using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PartyMember_UI_Script : MonoBehaviour//, IDropHandler
{
    public GameObject This_Prefab_Object;
    Transform root;
    public UI_Central uI_Central;
    Current_Hero_UI_Script current_Hero_UI;
    public bool isParty_Hero_In = false;


    private void Start()
    {
        uI_Central = GameObject.Find("Canvas").GetComponent<UI_Central>();
        root = transform.root;
    }

    public void Pointer_Up()
    {
        Debug.Log("UP");
        if(This_Prefab_Object == null && uI_Central.Catch_Hero_Object != null)
        {
            if(uI_Central.Catch_Hero_Object.GetComponent<HeroScript_Current_State>().isParty == false)
            {
                This_Prefab_Object = uI_Central.Catch_Hero_Object;
                This_Prefab_Object.GetComponent<HeroScript_Current_State>().isParty = true;
                isParty_Hero_In = true;
                gameObject.transform.GetChild(0).GetComponent<Text>().text = "Name : " + This_Prefab_Object.GetComponent<StatScript>().myStat.Name;
                gameObject.transform.GetChild(1).GetComponent<Text>().text = "Class : " + This_Prefab_Object.GetComponent<StatScript>().myStat.Job;
                gameObject.transform.GetChild(2).GetComponent<Text>().text = "HP : " + This_Prefab_Object.GetComponent<StatScript>().myStat.HP;


            }

        }
        // root.BroadcastMessage("EnterPartySlot", transform, SendMessageOptions.DontRequireReceiver);
    }

    //public void OnDrop(PointerEventData eventData)
    //{
    //    Debug.Log("Test2");
    //}
}
