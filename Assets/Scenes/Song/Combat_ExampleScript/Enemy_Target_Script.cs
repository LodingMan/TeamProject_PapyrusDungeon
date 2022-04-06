using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Enemy_Target_Script : MonoBehaviour, IPointerClickHandler
{
    public GameObject This_TargetObject;
    public e_CombatManager combatManager;
    public Target_Panal_Script target_Panal_Script;

    public void OnPointerClick(PointerEventData eventData)
    {

        gameObject.GetComponent<DOTweenAnimation>().DORestart();
        
        StartCoroutine(combatManager.HeroAttackDlay(This_TargetObject));

    }




}
