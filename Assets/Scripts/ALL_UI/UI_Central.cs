using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//========================================================//
//UI의 Drag & Drop를 동시에 컨트롤 하기 위해 만들었습니다.   //
//Canvers의 컴포넌트로서 사용됩니다.                       //
//=======================================================//
public class UI_Central : MonoBehaviour
{

    public Transform NoneIndex; // CurrentHero_UI_Prefab을 드래그하면 NoneIndex가 원래 프리팹이 있던 자리를 대신 차지하게 된다. 
    public GameObject Catch_Hero_Object;


    void SwapIndexInHierarchy(Transform sour, Transform dest) 
    {
        Transform sourParent = sour.parent;
        Transform destParent = dest.parent;

        int sourIndex = sour.GetSiblingIndex();
        int destIndex = dest.GetSiblingIndex();

        sour.SetParent(destParent);
        sour.SetSiblingIndex(destIndex);

        dest.SetParent(sourParent);
        dest.SetSiblingIndex(sourIndex);
    }


    void BeginDrag(Transform card)
    {
        //Debug.Log("BeginDrag: " + card.name);
        SwapIndexInHierarchy(NoneIndex, card);
    }
    void Drag(Transform card)
    {
        //Debug.Log("Drag: " + card.name);
    }
    void EndDrag(Transform card)
    {
        //Debug.Log("EndDrag: " + card.name);
        SwapIndexInHierarchy(NoneIndex, card);

    }

}
