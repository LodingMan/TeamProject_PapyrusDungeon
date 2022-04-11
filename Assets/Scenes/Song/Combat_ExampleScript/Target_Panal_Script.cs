using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Target_Panal_Script : MonoBehaviour
{
    public GameObject[] EnemyTargetUI = new GameObject[3];
    public GameObject[] PlayerTargetUI = new GameObject[3];
    public GameObject[] TargetUIPos = new GameObject[2];
    public e_CombatManager combatManager;


    private void Start()
    {
        TargetAllOff();
    }
    public void EnemyTargetView() //공격가능한 대상을 표시해줌 물론 UI로 처리함. 
    {
       // Debug.Log("Func");
        for (int i = 0; i < combatManager.enemys.Count; i++)
        {
            if(combatManager.SaveSkill.EnemyPosition[i] == -1)
            {
                continue;
            }
            EnemyTargetUI[i].SetActive(true);
            EnemyTargetUI[i].transform.DOMove(TargetUIPos[0].transform.position + new Vector3(2f * i, 0),1f);
            EnemyTargetUI[i].GetComponent<Unit_Target_Script>().This_TargetObject = combatManager.enemys[combatManager.SaveSkill.EnemyPosition[i]];
        }
    }


    public void PlayerTargetView() //공격가능한 대상을 표시해줌 물론 UI로 처리함. 
    {
        // Debug.Log("Func");
        for (int i = 0; i < combatManager.myParty.Count; i++)
        {
            if (combatManager.SaveSkill.EnemyPosition[i] == -1)
            {
                continue;
            }
            PlayerTargetUI[i].SetActive(true);
            PlayerTargetUI[i].transform.DOMove(TargetUIPos[1].transform.position + new Vector3(-2f * i, 0), 1f);
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
