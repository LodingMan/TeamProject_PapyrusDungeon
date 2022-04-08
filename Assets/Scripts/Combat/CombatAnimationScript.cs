using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAnimationScript : MonoBehaviour
{
    public e_CombatManager combatMgr;


    public void HeroRun()
    {
        combatMgr.myParty[0].transform.GetChild(0).GetComponent<Animator>().SetInteger("herostate", 1001);
        combatMgr.myParty[1].transform.GetChild(0).GetComponent<Animator>().SetInteger("herostate", 1001);
        combatMgr.myParty[2].transform.GetChild(0).GetComponent<Animator>().SetInteger("herostate", 1001);
    }

    public void HeroIdle()
    {
        combatMgr.myParty[0].transform.GetChild(0).GetComponent<Animator>().SetInteger("herostate", 998);
        combatMgr.myParty[1].transform.GetChild(0).GetComponent<Animator>().SetInteger("herostate", 998);
        combatMgr.myParty[2].transform.GetChild(0).GetComponent<Animator>().SetInteger("herostate", 998);
    }

}
