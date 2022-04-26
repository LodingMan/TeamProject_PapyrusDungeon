using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//원래 UI매니져에 들어가야 하지만 이미 작성되었으므로 예외적으로 이 스크립트에 처리하도록 함.

public class Target_Panal_Script : MonoBehaviour
{
    public GameObject[] EnemyTargetUI = new GameObject[3];
    public GameObject[] PlayerTargetUI = new GameObject[3];
    public e_CombatManager combatManager;


    private void Start()
    {

        TargetAllOff();
    }
    public void EnemyTargetView() 
    {
       // Debug.Log("Func");
        for (int i = 0; i < combatManager.enemys.Count; i++)
        {
            if(combatManager.SaveSkill.EnemyPosition[i] == -1)
            {
                continue;
            }
            EnemyTargetUI[i].SetActive(true);
            EnemyTargetUI[i].GetComponent<Unit_Target_Script>().This_TargetObject = combatManager.enemys[combatManager.SaveSkill.EnemyPosition[i]];
        }
    }

    public void PlayerTargetView()
    {
        // Debug.Log("Func");
        for (int i = 0; i < combatManager.myParty.Count; i++)
        {
            if (combatManager.SaveSkill.EnemyPosition[i] == -1)
            {
                continue;
            }
            PlayerTargetUI[i].SetActive(true);
            Debug.Log(i);
            PlayerTargetUI[i].GetComponent<Unit_Target_Script>().This_TargetObject = combatManager.myParty[combatManager.SaveSkill.EnemyPosition[i]];
        }
    }


    public void TargetAllOff()
    {
        for(int i = 0; i < 3; i ++)
        {
            EnemyTargetUI[i].SetActive(false);
            PlayerTargetUI[i].SetActive(false);
            
        }
    }


}
