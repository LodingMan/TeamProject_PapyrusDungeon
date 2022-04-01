using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKillTable //: MonoBehaviour  03-25 수정
{                       // 수정 사유 : 데이터를 가져오는데 사용되는 메모리를 줄이기 위해 Monobehaviour를 지우고 HeroManager에서 SkillTable를 초기화 해서 값을 사용함. 
                        // 여기에 있는 값을 다른 스크립트에서 사용하려면 SkillTable skillTable = new SkillTable(); 사용하면 이 클래스에 있는 값을 가져갈 수 있다.

    public Dictionary<int, skill> skillTable_Dictionary = new Dictionary<int, skill>() // 03-26 Lv 추가
    {
        //Mage
        { 0, new skill(0, "SkillName1", 1, 1, 1 ,new int[3] { 1, 2, 3 }, new int[3] { 1, 2, 3 })},
        { 1, new skill(1, "SkillName2", 1, 2, 2, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })},
        { 2, new skill(2, "SkillName3", 1, 3, 3, new int[3] { 1, 2, 3 }, new int[3] { 1, 0, 3 })},
        { 3, new skill(3, "SkillName4", 1, 4, 4, new int[3] { 0, 2, 0 }, new int[3] { 0, 2, 0 })},
        { 4, new skill(4, "SkillName5", 1, 5, 5, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })},
        //Archer
        { 5, new skill(5, "SkillName6", 1, 1, 1 ,new int[3] { 1, 2, 3 }, new int[3] { 1, 2, 3 })},
        { 6, new skill(6, "SkillName7", 1, 2, 2, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })},
        { 7, new skill(7, "SkillName8", 1, 3, 3, new int[3] { 1, 2, 3 }, new int[3] { 1, 0, 3 })},
        { 8, new skill(8, "SkillName9", 1, 4, 4, new int[3] { 0, 2, 0 }, new int[3] { 0, 2, 0 })},
        { 9, new skill(9, "SkillName10", 1, 5, 5, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })},
        //
        { 10, new skill(10, "SkillName11", 1, 1, 1 ,new int[3] { 1, 2, 3 }, new int[3] { 1, 2, 3 })},
        { 11, new skill(11, "SkillName12", 1, 2, 2, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })},
        { 12, new skill(12, "SkillName13", 1, 3, 3, new int[3] { 1, 2, 3 }, new int[3] { 1, 0, 3 })},
        { 13, new skill(13, "SkillName14", 1, 4, 4, new int[3] { 0, 2, 0 }, new int[3] { 0, 2, 0 })},
        { 14, new skill(14, "SkillName15", 1, 5, 5, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })},
        //
        { 15, new skill(15, "SkillName16", 1, 1, 1 ,new int[3] { 1, 2, 3 }, new int[3] { 1, 2, 3 })},
        { 16, new skill(16, "SkillName17", 1, 2, 2, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })},
        { 17, new skill(17, "SkillName18", 1, 3, 3, new int[3] { 1, 2, 3 }, new int[3] { 1, 0, 3 })},
        { 18, new skill(18, "SkillName19", 1, 4, 4, new int[3] { 0, 2, 0 }, new int[3] { 0, 2, 0 })},
        { 19, new skill(19, "SkillName20", 1, 5, 5, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })},
        //
        { 20, new skill(20, "SkillName21", 1, 1, 1 ,new int[3] { 1, 2, 3 }, new int[3] { 1, 2, 3 })},
        { 21, new skill(21, "SkillName22", 1, 2, 2, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })},
        { 22, new skill(22, "SkillName23", 1, 3, 3, new int[3] { 1, 2, 3 }, new int[3] { 1, 0, 3 })},
        { 23, new skill(23, "SkillName24", 1, 4, 4, new int[3] { 0, 2, 0 }, new int[3] { 0, 2, 0 })},
        { 24, new skill(24, "SkillName25", 1, 5, 5, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })},
        //
        { 25, new skill(25, "SkillName26", 1, 1, 1 ,new int[3] { 1, 2, 3 }, new int[3] { 1, 2, 3 })},
        { 26, new skill(26, "SkillName27", 1, 2, 2, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })},
        { 27, new skill(27, "SkillName28", 1, 3, 3, new int[3] { 1, 2, 3 }, new int[3] { 1, 0, 3 })},
        { 28, new skill(28, "SkillName29", 1, 4, 4, new int[3] { 0, 2, 0 }, new int[3] { 0, 2, 0 })},
        { 29, new skill(29, "SkillName30", 1, 5, 5, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })},
        //
        { 30, new skill(30, "SkillName31", 1, 1, 1 ,new int[3] { 1, 2, 3 }, new int[3] { 1, 2, 3 })},
        { 31, new skill(31, "SkillName32", 1, 2, 2, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })},
        { 32, new skill(32, "SkillName33", 1, 3, 3, new int[3] { 1, 2, 3 }, new int[3] { 1, 0, 3 })},
        { 33, new skill(33, "SkillName34", 1, 4, 4, new int[3] { 0, 2, 0 }, new int[3] { 0, 2, 0 })},
        { 34, new skill(34, "SkillName35", 1, 5, 5, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })},
        //
        { 35, new skill(35, "SkillName36", 1, 1, 1 ,new int[3] { 1, 2, 3 }, new int[3] { 1, 2, 3 })},
        { 36, new skill(36, "SkillName37", 1, 2, 2, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })},
        { 37, new skill(37, "SkillName38", 1, 3, 3, new int[3] { 1, 2, 3 }, new int[3] { 1, 0, 3 })},
        { 38, new skill(38, "SkillName39", 1, 4, 4, new int[3] { 0, 2, 0 }, new int[3] { 0, 2, 0 })},
        { 39, new skill(39, "SkillName40", 1, 5, 5, new int[3] { 1, 0, 3 }, new int[3] { 0, 0, 3 })}
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
