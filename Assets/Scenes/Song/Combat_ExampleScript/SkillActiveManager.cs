using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;

public class SkillActiveManager : MonoBehaviour
{
    public TownManager townManager;
    public Combat_Guide_Script combat_Guide_Script;


    public RectTransform rectTransform;
    public RectTransform Lever;
    [Range(10, 150)]
    public float leverRange;
    public CanvasGroup canvasGroup;

    public Image Root;

    public e_CombatManager combatManager;
    public Target_Panal_Script target_Panal_Script;
    public Combat_Event_UI_Manager combat_Event_UI_Manager;
    public Shin.SkillDetailTable skillDetailTable;


    public Sprite[] SkillImages = new Sprite[4];
    public Text[] SkillText = new Text[4]; // 테스트용 변수다. 이미지로 대체해야됨 

    public List<GameObject> Childs;

    public skill[] currentSkills = new skill[3]; //이 UI가 출력될 당시 사용할 스킬들의 정보

    public bool isActive = false;



    private void Awake()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Childs.Add(transform.GetChild(i).gameObject);
            Childs[i].SetActive(false);
        }
        gameObject.SetActive(false);
    }



    public void SkillActiveOn(skill[] targetSkills) //스킬의 정보를 출력함
    {
        isActive = true;
        gameObject.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            currentSkills[i] = targetSkills[i];
            SkillImages[i] = skillDetailTable.sprite[currentSkills[i].Index];
            Childs[i].GetComponent<SpriteRenderer>().sprite = SkillImages[i];

        }


        for (int i = 0; i < transform.childCount; i++)
        {
            Childs.Add(transform.GetChild(i).gameObject);
            Childs[i].SetActive(true);
            // Childs[i].transform.DOMove(new Vector3(1.2f * i, 0, 0), 0.5);
            Childs[i].transform.DOMove(transform.position + new Vector3(1.5f * i, 0, 0), 0.5f);
        }



    }

    public void Skill1()
    {

        //Debug.Log("Test");
        combatManager.SaveSkill = currentSkills[0];
        for(int i = 0; i < combatManager.SaveSkill.MyPosition.Length; i++)
        {
           if( combatManager.SaveSkill.MyPosition[i] == combatManager.currentActiveUnitIndex)
            {
                switch(combatManager.SaveSkill.Type)
                {
                    case 0:
                        Debug.Log("AttackSkill");
                        target_Panal_Script.EnemyTargetView();
                        gameObject.SetActive(false);
                        Debug.Log("1번스킬 사용!");
                        InfoOut();

                        break;
                    case 1:
                        Debug.Log("BuffSkill");
                        target_Panal_Script.PlayerTargetView();
                        gameObject.SetActive(false);
                        combat_Event_UI_Manager.Current_Attack_Unit.gameObject.SetActive(false);
                        Debug.Log("1번스킬 사용!");
                        InfoOut();



                        break;
                }
                return;
            }

        }
        Debug.Log("사용불가");

    }
    public void Skill1_Info()
    {

        combat_Event_UI_Manager.Skill_Info_UI.rectTransform.DOAnchorPos(new Vector2(0, 0), 1);

        combat_Event_UI_Manager.SkillInfo_Text[0].text = currentSkills[0].Name;
        combat_Event_UI_Manager.SkillInfo_Text[2].text = "SKILL ATK : " + currentSkills[0].ATK;
        combat_Event_UI_Manager.SkillInfo_Text[3].text = "SKILL TYPE : " + currentSkills[0].Type;

        for (int i = 0; i< 3; i++)
        {
            if (currentSkills[0].MyPosition[i] == -1)
            {
                combat_Event_UI_Manager.SKillInfo_Image[i].enabled = false;
                combat_Event_UI_Manager.SKillInfo_Image[i+6].enabled = true;
            }
            else
            {
                combat_Event_UI_Manager.SKillInfo_Image[i].enabled = true;
                combat_Event_UI_Manager.SKillInfo_Image[i + 6].enabled = false;
            }

        }
        for (int i = 0; i < 3; i++)
        {
            if (currentSkills[0].EnemyPosition[i] == -1)
            {
                combat_Event_UI_Manager.SKillInfo_Image[i+3].enabled = false;
                combat_Event_UI_Manager.SKillInfo_Image[i + 9].enabled = true;
            }
            else
            {
                combat_Event_UI_Manager.SKillInfo_Image[i+3].enabled = true;
                combat_Event_UI_Manager.SKillInfo_Image[i + 9].enabled = false;
            }

        }
    }
    public void InfoOut()
    {
        combat_Event_UI_Manager.Skill_Info_UI.rectTransform.DOAnchorPos(new Vector2(0, 728), 1);

        if (townManager.Week == 1)
        {
            combat_Guide_Script.Combat_Skill_Guide_Off();
            combat_Guide_Script.isCombat_Skill_Guide = true;

        }

    }

    public void Skill2()
    {
        combatManager.SaveSkill = currentSkills[1];

        for (int i = 0; i < combatManager.SaveSkill.MyPosition.Length; i++)
        {
            if (combatManager.SaveSkill.MyPosition[i] == combatManager.currentActiveUnitIndex)
            {
                switch (combatManager.SaveSkill.Type)
                {
                    case 0:
                        Debug.Log("AttackSkill");
                        target_Panal_Script.EnemyTargetView();
                        gameObject.SetActive(false);
                        Debug.Log("2번스킬 사용!");
                        InfoOut();

                        break;
                    case 1:
                        Debug.Log("BuffSkill");
                        target_Panal_Script.PlayerTargetView();
                        gameObject.SetActive(false);
                        combat_Event_UI_Manager.Current_Attack_Unit.gameObject.SetActive(false);
                        Debug.Log("2번스킬 사용!");
                        InfoOut();
                        break;
                }
                return;
            }
        }

        Debug.Log("사용불가");
    }
    public void Skill2_Info()
    {

        combat_Event_UI_Manager.Skill_Info_UI.rectTransform.DOAnchorPos(new Vector2(0,0), 1);

        combat_Event_UI_Manager.SkillInfo_Text[0].text = currentSkills[1].Name;
        combat_Event_UI_Manager.SkillInfo_Text[2].text = "SKILL ATK : "+currentSkills[1].ATK;
        combat_Event_UI_Manager.SkillInfo_Text[3].text = "SKILL TYPE : " + currentSkills[1].Type;


        for (int i = 0; i < 3; i++)
        {
            if (currentSkills[1].MyPosition[i] == -1)
            {
                combat_Event_UI_Manager.SKillInfo_Image[i].enabled = false;
                combat_Event_UI_Manager.SKillInfo_Image[i + 6].enabled = true;
            }
            else
            {
                combat_Event_UI_Manager.SKillInfo_Image[i].enabled = true;
                combat_Event_UI_Manager.SKillInfo_Image[i + 6].enabled = false;
            }

        }

        for (int i = 0; i < 3; i++)
        {
            if (currentSkills[1].EnemyPosition[i] == -1)
            {
                combat_Event_UI_Manager.SKillInfo_Image[i + 3].enabled = false;
                combat_Event_UI_Manager.SKillInfo_Image[i + 9].enabled = true;
            }
            else
            {
                combat_Event_UI_Manager.SKillInfo_Image[i + 3].enabled = true;
                combat_Event_UI_Manager.SKillInfo_Image[i + 9].enabled = false;
            }

        }
    }
    public void Skill3()
    {
        combatManager.SaveSkill = currentSkills[2];

        for (int i = 0; i < combatManager.SaveSkill.MyPosition.Length; i++)
        {
            if (combatManager.SaveSkill.MyPosition[i] == combatManager.currentActiveUnitIndex)
            {
                switch (combatManager.SaveSkill.Type)
                {
                    case 0:
                        Debug.Log("AttackSkill");
                        target_Panal_Script.EnemyTargetView();
                        gameObject.SetActive(false);
                        Debug.Log("3번스킬 사용!");
                        InfoOut();

                        break;
                    case 1:
                        Debug.Log("BuffSkill");
                        target_Panal_Script.PlayerTargetView();
                        gameObject.SetActive(false);
                        combat_Event_UI_Manager.Current_Attack_Unit.gameObject.SetActive(false);
                        Debug.Log("3번스킬 사용!");
                        InfoOut();



                        break;
                }
                return;
            }

        }


        Debug.Log("사용불가");

    }
    public void Skill3_Info()
    {

        combat_Event_UI_Manager.Skill_Info_UI.rectTransform.DOAnchorPos(new Vector2(0, 0), 1);
        combat_Event_UI_Manager.SkillInfo_Text[0].text = currentSkills[2].Name;
        combat_Event_UI_Manager.SkillInfo_Text[2].text = "SKILL ATK : " + currentSkills[2].ATK;
        combat_Event_UI_Manager.SkillInfo_Text[3].text = "SKILL TYPE : " + currentSkills[2].Type;

        for (int i = 0; i < 3; i++)
        {
            if (currentSkills[2].MyPosition[i] == -1)
            {
                combat_Event_UI_Manager.SKillInfo_Image[i].enabled = false;
                combat_Event_UI_Manager.SKillInfo_Image[i + 6].enabled = true;
            }
            else
            {
                combat_Event_UI_Manager.SKillInfo_Image[i].enabled = true;
                combat_Event_UI_Manager.SKillInfo_Image[i + 6].enabled = false;
            }

        }

        for (int i = 0; i < 3; i++)
        {
            if (currentSkills[2].EnemyPosition[i] == -1)
            {
                combat_Event_UI_Manager.SKillInfo_Image[i + 3].enabled = false;
                combat_Event_UI_Manager.SKillInfo_Image[i + 9].enabled = true;
            }
            else
            {
                combat_Event_UI_Manager.SKillInfo_Image[i + 3].enabled = true;
                combat_Event_UI_Manager.SKillInfo_Image[i + 9].enabled = false;
            }

        }
    }

    public void SkillNone()
    {
        combat_Event_UI_Manager.Current_Attack_Unit.gameObject.SetActive(false);
        gameObject.SetActive(false);
        combatManager.speedComparisonArray.RemoveAt(0);
        combatManager.NextMove();

    }


}

