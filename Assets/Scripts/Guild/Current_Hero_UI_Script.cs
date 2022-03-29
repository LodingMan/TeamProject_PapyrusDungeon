using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Current_Hero_UI_Script : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    Transform root;
    bool isPointerDown = false;
    float PointerDonwTime;
    public GameObject This_Prefab_Object;

    private void Start()
    {
        root = transform.root;
    }
    private void Update()
    {
        if(isPointerDown)
        {
            PointerDonwTime += Time.deltaTime;
            Debug.Log(PointerDonwTime);
        }
        else
        {
            PointerDonwTime = 0;
        }

        if(PointerDonwTime > 2.5f)
        {
            Debug.Log("스테이터스창 출력");
            PointerDonwTime = 0;
            isPointerDown = false;
        }

    }

    public void Test_Pointer_Down()
    {
        Debug.Log("PointerDown");
        isPointerDown = true;
    }

    public void Test_Pointer_UP()
    {
        isPointerDown = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = eventData.position;
        root.BroadcastMessage("Drag", transform, SendMessageOptions.DontRequireReceiver);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        root.BroadcastMessage("BeginDrag", transform, SendMessageOptions.DontRequireReceiver);
        isPointerDown = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        root.BroadcastMessage("EndDrag", transform, SendMessageOptions.DontRequireReceiver);
    }

    public void OnDrop(PointerEventData eventData)
    {

    }
}
