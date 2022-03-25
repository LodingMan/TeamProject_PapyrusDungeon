using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKillTable : MonoBehaviour
{
   //모든 스킬들의 값 관리, 0~4번인덱스까지 마법사의 스킬이다. 
    public Dictionary<int, skill> initSkill = new Dictionary<int, skill>();

    void Start()
    {
        initSkill[0] = new skill(0, "SkillName1", 1, 1 ,new int[3] { 1, 2, 3 },new int[3] { 1,2,3} );
        initSkill[1] = new skill(0, "SkillName2", 2, 2, new int[3] {1, 0, 3 }, new int[3] { 0, 0, 3 });
        initSkill[2] = new skill(0, "SkillName3", 3, 3, new int[3] { 1, 2, 3 }, new int[3] { 1, 0, 3 });
        initSkill[3] = new skill(0, "SkillName4", 4, 4, new int[3] { 0, 2, 0 }, new int[3] { 0, 2, 0 });
        initSkill[4] = new skill(0, "SkillName5", 5, 5, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 });
    }

}
