using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Enemy_Target_Script : MonoBehaviour, IPointerClickHandler
{
    public GameObject This_TargetObject;
    public e_CombatManager combatManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        combatManager.SkillResultInit(This_TargetObject);
    }
}
