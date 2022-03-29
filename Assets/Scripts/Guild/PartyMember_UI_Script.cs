using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMember_UI_Script : MonoBehaviour
{
    public GameObject This_Prefab_Object;
    Transform root;
    public UI_Central uI_Central;
    public bool isParty_Hero_In = false;


    private void Start()
    {
        uI_Central = GameObject.Find("Canvas").GetComponent<UI_Central>();
        root = transform.root;
    }

    public void Pointer_Enter()
    {
        Debug.Log("Enter");
        
        if(This_Prefab_Object == null)
        {
            This_Prefab_Object = uI_Central.Catch_Hero_Object;
        }
        // root.BroadcastMessage("EnterPartySlot", transform, SendMessageOptions.DontRequireReceiver);
    }
    public void Pointer_UP()
    {

    }




}
