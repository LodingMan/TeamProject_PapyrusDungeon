using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAnimationScript : MonoBehaviour
{
    public e_CombatManager combatMgr;


    public void HeroRun()
    {
        for (int i = 0; i < combatMgr.myParty.Count; i++)
        {
            combatMgr.myParty[i].transform.GetChild(0).GetComponent<Animator>().SetInteger("herostate", 1001);
        }
    }

    public void HeroIdle()
    {
        for (int i = 0; i < combatMgr.myParty.Count; i++)
        {
            combatMgr.myParty[i].transform.GetChild(0).GetComponent<Animator>().SetInteger("herostate", 998);
        }
    }

}
