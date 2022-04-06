using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;

public class SkillActiveManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IPointerDownHandler
{
    public RectTransform rectTransform;
    public RectTransform Lever;
    [Range(10, 150)]
    public float leverRange;
    public CanvasGroup canvasGroup;

    public Image Root;

    public e_CombatManager combatManager;
    public Target_Panal_Script enemyTargetScript;
    public Combat_Event_UI_Manager combat_Event_UI_Manager;


    public Image[] SkillImage = new Image[4];
    public Text[] SkillText = new Text[4]; // �׽�Ʈ�� ������. �̹����� ��ü�ؾߵ� 
    public List<GameObject> Childs;

    public skill[] currentSkills = new skill[3]; //�� UI�� ��µ� ��� ����� ��ų���� ����

    public bool isActive = false;



    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = Lever.gameObject.GetComponent<CanvasGroup>();
        
        for(int i = 0; i < transform.childCount; i++)
        {
            Childs.Add(transform.GetChild(i).gameObject);
            Childs[i].SetActive(false);
        }
        gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        for (int i = 0; i < Childs.Count; i++)
        {
            Childs[i].SetActive(true); //Ŭ���� ���� UI����
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(isActive)
        {

            var inputPos = eventData.position - rectTransform.anchoredPosition;
            inputPos = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;

            Lever.anchoredPosition = inputPos;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(isActive)
        {
            var inputPos = eventData.position - rectTransform.anchoredPosition;
            inputPos = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;

            Lever.anchoredPosition = inputPos;
            canvasGroup.blocksRaycasts = false;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(isActive)
        {

            Lever.anchoredPosition = Vector2.zero;
            canvasGroup.blocksRaycasts = true;

            for (int i = 0; i < Childs.Count; i++)
            {
                Childs[i].SetActive(false); //���콺����  UI����
            }
        }
    }


    public void SkillActiveOn(skill[] targetSkills) //��ų�� ������ �����
    {
        isActive = true;
        gameObject.SetActive(true);

        for (int i = 0; i < 3; i++) currentSkills[i] = targetSkills[i];

        SkillText[0].text = currentSkills[0].Name;
        SkillText[1].text = currentSkills[1].Name;
        SkillText[2].text = currentSkills[2].Name;
        SkillText[3].text = "�� �ѱ��";

        //���߿� �̹����� ��ü�Ҷ� currentKill[i]�� �ε��� == ��ų ������ ����Ʈ ��ȣ �϶� �ش� ��ų �������� SkillImage�� �ִ´�. 



        for (int i = 0; i < transform.childCount; i++)
        {
            Childs.Add(transform.GetChild(i).gameObject);
            Childs[i].SetActive(false);
        }
    }

    public void Skill1()
    {
        //Debug.Log("Test");
        combatManager.SaveSkill = currentSkills[0];
        for(int i = 0; i < combatManager.SaveSkill.MyPosition.Length; i++)
        {
           if( combatManager.SaveSkill.MyPosition[i] == combatManager.currentActiveHeroIndex)
            {
                enemyTargetScript.TargetView();
                gameObject.SetActive(false);
                Debug.Log("1����ų ���!");
                return;
            }
        }
        Debug.Log("���Ұ�");

    }
    public void Skill1_Info()
    {

        combat_Event_UI_Manager.Skill_Info_UI.rectTransform.DOAnchorPos(new Vector2(314.6f, -12.3f), 1);
        for(int i = 0; i< 3; i++)
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
        combat_Event_UI_Manager.Skill_Info_UI.rectTransform.DOAnchorPos(new Vector2(314.6f, 682), 1);

    }

    public void Skill2()
    {
        combatManager.SaveSkill = currentSkills[1];
        for (int i = 0; i < combatManager.SaveSkill.MyPosition.Length; i++)
        {
            if (combatManager.SaveSkill.MyPosition[i] == combatManager.currentActiveHeroIndex)
            {
                enemyTargetScript.TargetView();
                gameObject.SetActive(false);
                Debug.Log("2����ų ���!");
                return;
            }
        }
        Debug.Log("���Ұ�");

    }
    public void Skill2_Info()
    {

        combat_Event_UI_Manager.Skill_Info_UI.rectTransform.DOAnchorPos(new Vector2(314.6f, -12.3f), 1);

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
            if (combatManager.SaveSkill.MyPosition[i] == combatManager.currentActiveHeroIndex)
            {
                enemyTargetScript.TargetView();
                gameObject.SetActive(false);
                Debug.Log("3����ų ���!");
                return;
            }
        }
        Debug.Log("���Ұ�");

    }
    public void Skill3_Info()
    {

        combat_Event_UI_Manager.Skill_Info_UI.rectTransform.DOAnchorPos(new Vector2(314.6f, -12.3f), 1);

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
        combatManager.speedComparisonArray.RemoveAt(0);
        combatManager.NextMove();

    }


}

