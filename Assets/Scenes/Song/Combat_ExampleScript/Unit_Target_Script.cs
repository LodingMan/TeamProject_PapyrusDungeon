using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Unit_Target_Script : MonoBehaviour
{
    public e_CombatManager combatManager;
    public GameObject This_TargetObject;

    public void TargetSelectFunc()
    {
        combatManager.Target_Coroutine_StartFunc(This_TargetObject);
    }

}
