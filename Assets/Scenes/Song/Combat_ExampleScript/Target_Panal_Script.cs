using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target_Panal_Script : MonoBehaviour
{
    public Image[] TargetUI = new Image[3];
    public e_CombatManager combatManager;


    public void TargetView() //공격가능한 대상을 표시해줌 물론 UI로 처리함. 
    {
       // Debug.Log("Func");
        for (int i = 0; i < combatManager.enemys.Count; i++)
        {
            if(combatManager.SaveSkill.EnemyPosition[i] == -1)
            {
                continue;
            }
            TargetUI[combatManager.SaveSkill.EnemyPosition[i]].enabled=true;
            TargetUI[combatManager.SaveSkill.EnemyPosition[i]].GetComponent<RectTransform>().anchoredPosition = combatManager.CombatCamera.WorldToScreenPoint(combatManager.enemys[combatManager.SaveSkill.EnemyPosition[i]].transform.position);
            TargetUI[combatManager.SaveSkill.EnemyPosition[i]].GetComponent<Enemy_Target_Script>().This_TargetObject = combatManager.enemys[combatManager.SaveSkill.EnemyPosition[i]];
        }
    }
    public void TargetAllOff()
    {
        for(int i = 0; i < 3; i ++)
        {
            TargetUI[i].enabled = false;
            
        }
    }


}
