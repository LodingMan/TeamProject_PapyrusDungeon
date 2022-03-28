using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Central : MonoBehaviour
{

    public Transform NoneIndex; // CurrentHero_UI_Prefab을 드래그하면 NoneIndex가 원래 프리팹이 있던 자리를 대신 차지하게 된다. 


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
        Debug.Log("BeginDrag: " + card.name);
        SwapIndexInHierarchy(NoneIndex, card);
    }
    void Drag(Transform card)
    {
        Debug.Log("Drag: " + card.name);
    }
    void EndDrag(Transform card)
    {
        Debug.Log("EndDrag: " + card.name);
        SwapIndexInHierarchy(NoneIndex, card);

    }

}
