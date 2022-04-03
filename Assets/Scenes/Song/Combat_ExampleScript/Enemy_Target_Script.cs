using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Enemy_Target_Script : MonoBehaviour, IPointerClickHandler
{
    public GameObject This_TargetObject;
    public e_CombatManager combatManager;
    public Target_Panal_Script target_Panal_Script;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(This_TargetObject + "를 대상으로" + combatManager.SaveSkill.Name + "스킬 사용");
        combatManager.SkillResultInit(This_TargetObject);
        target_Panal_Script.TargetAllOff();

    }
}
