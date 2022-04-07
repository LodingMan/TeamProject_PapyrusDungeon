using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Target_Panal_Script : MonoBehaviour
{
    public GameObject[] TargetUI = new GameObject[3];
    public e_CombatManager combatManager;


    private void Start()
    {
        TargetAllOff();
    }
    public void TargetView() //공격가능한 대상을 표시해줌 물론 UI로 처리함. 
    {
       // Debug.Log("Func");
        for (int i = 0; i < combatManager.enemys.Count; i++)
        {
            if(combatManager.SaveSkill.EnemyPosition[i] == -1)
            {
                continue;
            }
            TargetUI[i].SetActive(true);
            TargetUI[i].transform.DOMove(transform.position + new Vector3(1.5f * i, 0),1f);
            TargetUI[i].GetComponent<Enemy_Target_Script>().This_TargetObject = combatManager.enemys[combatManager.SaveSkill.EnemyPosition[i]];
        }
    }
    public void TargetAllOff()
    {
        for(int i = 0; i < 3; i ++)
        {
            TargetUI[i].SetActive(false);
            
        }
    }


}
