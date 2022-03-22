using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillScripts : MonoBehaviour
{

    public int skillDmg;
    public int skillMp;
    public float curTime;

    public Text skillTestTxt;

    public string who;
    public SaveAndLoadMgr skillData;
    public string[] skills = new string[5];
    public bool isActive = true;

    public Button[] skillBtn = new Button[5];


    private void Awake()
    {
        skillData = GameObject.Find("GameMgr").GetComponent<SaveAndLoadMgr>();
    }

    private void Update()
    {
      
        SkillSet();
    }
    public void SkillSet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                who = hit.transform.gameObject.tag;

            }
        }
        if (who == "Barbarian")
        {
            skills[0] = skillData.skillData[0].name;
            skills[1] = skillData.skillData[1].name;
            skills[2] = skillData.skillData[2].name;
            skills[3] = skillData.skillData[3].name;
            skills[4] = skillData.skillData[4].name;

        }
        if (who == "Archer")
        {
            skills[0] = skillData.skillData[5].name;
            skills[1] = skillData.skillData[6].name;
            skills[2] = skillData.skillData[7].name;
            skills[3] = skillData.skillData[8].name;
            skills[4] = skillData.skillData[9].name;

        }
        if (who == "Knight")
        {
            skills[0] = skillData.skillData[10].name;
            skills[1] = skillData.skillData[11].name; 
            skills[2] = skillData.skillData[12].name; 
            skills[3] = skillData.skillData[13].name;
            skills[4] = skillData.skillData[14].name;

        }
        if (who == "Barristan")
        {
            skills[0] = skillData.skillData[15].name;
            skills[1] = skillData.skillData[16].name;
            skills[2] = skillData.skillData[17].name;
            skills[3] = skillData.skillData[18].name;
            skills[4] = skillData.skillData[19].name;

        }
        if (who == "Mage")
        {
            skills[0] = skillData.skillData[20].name;
            skills[1] = skillData.skillData[21].name;
            skills[2] = skillData.skillData[22].name;
            skills[3] = skillData.skillData[23].name;
            skills[4] = skillData.skillData[24].name;

        }
        if (who == "Slave")
        {
            skills[0] = skillData.skillData[25].name;
            skills[1] = skillData.skillData[26].name;
            skills[2] = skillData.skillData[27].name;
            skills[3] = skillData.skillData[28].name;
            skills[4] = skillData.skillData[29].name;

        }

    }

    public void playerSkill1()
    {
        if (who == "Barbarian")
        {
            skillTestTxt.text = "바바리안 1번 스킬";
        }
        if (who == "Archer")
        {
            skillTestTxt.text = "아처 1번 스킬";
        }
    }
    public void playerSkill2()
    {
        if (who == "Barbarian")
        {
            skillTestTxt.text = "바바리안 2번 스킬";
        }
        if (who == "Archer")
        {
            skillTestTxt.text = "아처 2번 스킬";
        }
    }
    public void playerSkill3()
    {
        if (who == "Barbarian")
        {
            skillTestTxt.text = "바바리안 3번 스킬";

        }
        if (who == "Archer")
        {
            skillTestTxt.text = "아처 3번 스킬";
        }
    }
    public void playerSkill4()
    {
        if (who == "Barbarian")
        {
            skillTestTxt.text = "바바리안 4번 스킬";
        }
        if (who == "Archer")
        {
            skillTestTxt.text = "아처 4번 스킬";
        }
    }
    public void playerSkill5()
    {
        if (who == "Barbarian")
        {
            skillTestTxt.text = "바바리안 5번 스킬";
        }
        if (who == "Archer")
        {
            skillTestTxt.text = "아처 5번 스킬";
        }
    }
}
