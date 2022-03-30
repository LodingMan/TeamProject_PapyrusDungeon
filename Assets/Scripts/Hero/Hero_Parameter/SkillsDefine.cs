using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsDefine : MonoBehaviour {
    public SkillScript skillScript;

    private void Start()
    {
        skillScript = gameObject.GetComponent<SkillScript>();
        for (int i = 0; i < 3; i++)
        {
            skillScript.SkillIndex[i] = Random.Range(0, 5);
            skillScript.mySkills[i] = skillScript.skills[skillScript.SkillIndex[i]];
            for (int j = i; j > 0; j--)
            {
                if (skillScript.SkillIndex[i] == skillScript.SkillIndex[j - 1])
                {
                    i--;
                }
            }
        }
    }
}