using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKillTable //: MonoBehaviour  03-25 수정
{                       // 수정 사유 : 데이터를 가져오는데 사용되는 메모리를 줄이기 위해 Monobehaviour를 지우고 HeroManager에서 SkillTable를 초기화 해서 값을 사용함. 
                        // 여기에 있는 값을 다른 스크립트에서 사용하려면 SkillTable skillTable = new SkillTable(); 사용하면 이 클래스에 있는 값을 가져갈 수 있다.  
    public Dictionary<int, skill> skillTable_Dictionary = new Dictionary<int, skill>() // 03-26 Lv 추가
    {
        { 0, new skill(0, "SkillName1", 1, 1, 1 ,new int[3] { 1, 2, 3 }, new int[3] { 1, 2, 3 })},
        { 1, new skill(1, "SkillName2", 1, 2, 2, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })},
        { 2, new skill(2, "SkillName3", 1, 3, 3, new int[3] { 1, 2, 3 }, new int[3] { 1, 0, 3 })},
        { 3, new skill(3, "SkillName4", 1, 4, 4, new int[3] { 0, 2, 0 }, new int[3] { 0, 2, 0 })},
        { 4, new skill(4, "SkillName5", 1, 5, 5, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })},
        { 5, new skill(5, "SkillName6", 1, 1, 1 ,new int[3] { 1, 2, 3 }, new int[3] { 1, 2, 3 })},
        { 6, new skill(6, "SkillName7", 1, 2, 2, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })},
        { 7, new skill(7, "SkillName8", 1, 3, 3, new int[3] { 1, 2, 3 }, new int[3] { 1, 0, 3 })},
        { 8, new skill(8, "SkillName9", 1, 4, 4, new int[3] { 0, 2, 0 }, new int[3] { 0, 2, 0 })},
        { 9, new skill(9, "SkillName10", 1, 5, 5, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })}
    };

    // Monobehaviour를 지우면서 같이 지움
    //void Start()
    //{
    //    initSkill[0] = new skill(0, "SkillName1", 1, 1 ,new int[3] { 1, 2, 3 },new int[3] { 1,2,3} );
    //    initSkill[1] = new skill(0, "SkillName2", 2, 2, new int[3] {1, 0, 3 }, new int[3] { 0, 0, 3 });
    //    initSkill[2] = new skill(0, "SkillName3", 3, 3, new int[3] { 1, 2, 3 }, new int[3] { 1, 0, 3 });
    //    initSkill[3] = new skill(0, "SkillName4", 4, 4, new int[3] { 0, 2, 0 }, new int[3] { 0, 2, 0 });
    //    initSkill[4] = new skill(0, "SkillName5", 5, 5, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 });
    //}

}
