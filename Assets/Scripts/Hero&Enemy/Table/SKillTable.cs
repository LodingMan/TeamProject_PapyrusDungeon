using System.Collections.Generic;

public class SKillTable
{
    public Dictionary<int, skill> skillTable_Dictionary = new Dictionary<int, skill>() // 03-26 Lv �߰�
    {
        //Mage
        { 0, new skill(30, "SkillName1", 1, 1, 0 , 0 ,new int[3] {0,1,2}, new int[3] {0,1,-1  },2)},
        { 2, new skill(2, "SkillName3", 1, 3, 0, 0 , new int[3] {0,1,-1}, new int[3] {0,1,-1  },2)},
        { 1, new skill(1, "SkillName2", 1, 2, 0, 0 , new int[3] {0,1,-1}, new int[3] {0,1,-1  },2)},
        { 3, new skill(3, "SkillName4", 1, 4, 1, 2 , new int[3] {0,1,-1}, new int[3] {0,1,-1  },2)},
        { 4, new skill(4, "SkillName5", 1, 5, 0, 0 , new int[3] {0,1,-1}, new int[3] {0,1,-1  },2)},
        //Archer
        { 5, new skill(5, "SkillName6", 1, 1, 0, 0  ,new int[3] {0,1,2  }, new int[3] { 0,1,-1 },2)},
        { 6, new skill(6, "SkillName7", 1, 2, 0, 0 , new int[3] {0,1,-1  }, new int[3] { 0,1,-1 },2)},
        { 7, new skill(7, "SkillName8", 1, 3, 1, 5 , new int[3] {0,1,-1  }, new int[3] { 0,1,-1 },2)},
        { 8, new skill(8, "SkillName9", 1, 4, 0, 0 , new int[3] {0,1,-1  }, new int[3] { 0,1,-1 },2)},
        { 9, new skill(9, "SkillName10", 1, 5, 0, 0 , new int[3] {0,1,-1  }, new int[3] {0,1,-1  },2)},
        //Babarian
        { 10, new skill(10, "SkillName11", 1, 1, 0, 0  ,new int[3] {0,1,2  }, new int[3] {0,1,-1  },2)},
        { 11, new skill(11, "SkillName12", 1, 2, 0, 0 , new int[3] {0,1,-1  }, new int[3] {0,1,-1  },2)},
        { 12, new skill(12, "SkillName13", 1, 3, 0, 0 , new int[3] {0,1,-1  }, new int[3] {0,1,-1  },2)},
        { 13, new skill(13, "SkillName14", 1, 4, 1, 1 , new int[3] {0,1,-1  }, new int[3] {0,1,-1  },2)},
        { 14, new skill(14, "SkillName15", 1, 5, 0, 0 , new int[3] {0,1,-1  }, new int[3] {0,1,-1  },2)},
        //Knight
        { 15, new skill(15, "SkillName16", 1, 1, 0, 0 ,new int[3] {0,1,2 }, new int[3] { 0,1,-1  },2)},
        { 16, new skill(16, "SkillName17", 1, 2, 1, 1 , new int[3] {0,1,-1 }, new int[3] { 0,1,-1  },2)},
        { 17, new skill(17, "SkillName18", 1, 3, 1, 2 , new int[3] {0,1,-1 }, new int[3] { 0,1,-1  },2)},
        { 18, new skill(18, "SkillName19", 1, 4, 1, 1 , new int[3] {0,1,-1 }, new int[3] { 0,1,-1  },2)},
        { 19, new skill(19, "SkillName20", 1, 5, 0, 0 , new int[3] {0,1,-1 }, new int[3] { 0,1,-1  },2)},
        //Barristan
        { 20, new skill(20, "SkillName21", 1, 1, 0, 0 ,new int[3] {0,1,2 }, new int[3] { 0,1,-1  },2)},
        { 21, new skill(21, "SkillName22", 1, 2, 1, 1 , new int[3] {0,1,-1 }, new int[3] { 0,1,-1  },2)},
        { 22, new skill(22, "SkillName23", 1, 3, 0, 0 , new int[3] {0,1,-1 }, new int[3] { 0,1,-1  },2)},
        { 23, new skill(23, "SkillName24", 1, 4, 1, 2 , new int[3] {0,1,-1 }, new int[3] { 0,1,-1  },2)},
        { 24, new skill(24, "SkillName25", 1, 5, 1, 5 , new int[3] {0,1,-1 }, new int[3] { 0,1,-1  },2)},
        //Porter
        { 25, new skill(25, "SkillName26", 1, 1, 1, 2  ,new int[3] {0,1,2 }, new int[3] {0,1,-1  },2)},
        { 26, new skill(26, "SkillName27", 1, 2, 0, 0 , new int[3] {0,1,-1 }, new int[3] {0,1,-1  },2)},
        { 27, new skill(27, "SkillName28", 1, 3, 1, 1 , new int[3] {0,1,-1 }, new int[3] {0,1,-1  },2)},
        { 28, new skill(28, "SkillName29", 1, 4, 1, 2 , new int[3] {0,1,-1 }, new int[3] {0,1,-1  },2)},
        { 29, new skill(29, "SkillName30", 1, 5, 1, 5 , new int[3] {0,1,-1 }, new int[3] {0,1,-1  },2)},

        //
        { 30, new skill(30, "SkillName31", 1, 1, 0, 0  ,new int[3] {0,1,-1 }, new int[3] { 0,1,-1  },2)},
        { 31, new skill(31, "SkillName32", 1, 2, 0, 0 , new int[3] {0,1,-1 }, new int[3] { 0,1,-1  },2)},
        { 32, new skill(32, "SkillName33", 1, 3, 0, 0 , new int[3] {0,1,-1 }, new int[3] { 0,1,-1  },2)},
        { 33, new skill(33, "SkillName34", 1, 4, 0, 0 , new int[3] {0,1,-1 }, new int[3] { 0,1,-1  },2)},
        { 34, new skill(34, "SkillName35", 1, 5, 0, 0 , new int[3] {0,1,-1 }, new int[3] { 0,1,-1  },2)},
        //
        { 35, new skill(35, "SkillName36", 1, 1, 0 , 0 ,new int[3] {0,1,-1 }, new int[3] {0,1,-1   },2)},
        { 36, new skill(36, "SkillName37", 1, 2, 0, 0 , new int[3] {0,1,-1 }, new int[3] {0,1,-1   },2)},
        { 37, new skill(37, "SkillName38", 1, 3, 0, 0 , new int[3] {0,1,-1 }, new int[3] {0,1,-1   },2)},
        { 38, new skill(38, "SkillName39", 1, 4, 0, 0 , new int[3] {0,1,-1 }, new int[3] {0,1,-1   },2)},
        { 39, new skill(39, "SkillName40", 1, 5, 0, 0 , new int[3] {0,1,-1 }, new int[3] {0,1,-1   },2)},

        //100���ķ� ���� ��ų
        { 100, new skill(100, "SkillName101", 1, 1, 0, 0 ,new int[3] { 0,1,-1 }, new int[3] { 0,1,-1 },0)},
        { 101, new skill(101, "SkillName102", 1, 2, 0, 0 , new int[3] { 0,1,-1 }, new int[3] { 0,1,-1 },0)},
        { 102, new skill(102, "SkillName103", 1, 3, 0, 0 , new int[3] { 0,1,-1 }, new int[3] { 0,1,-1 },0)},

        { 103, new skill(103, "SkillName104", 1, 1, 0, 0 ,new int[3] {0,1,-1 }, new int[3] { 0,1,-1 },0)},
        { 104, new skill(104, "SkillName37", 1, 2, 0, 0 , new int[3] { 0,1,-1 } , new int[3]{ 0,1,-1 },0)},
        { 105, new skill(105, "SkillName38", 1, 3, 0, 0 , new int[3] { 0, 1, -1 }, new int[3]{0,1,-1 },0)},

        { 106, new skill(106, "SkillName36", 1, 1, 0, 0 ,new int[3] {0,1,-1 }, new int[3] {0,1,-1 },0)},
        { 107, new skill(107, "SkillName107", 1,2, 0, 0 , new int[3] {0,1,-1 }, new int[3] {0,1,-1 },0)},
        { 108, new skill(108, "SkillName38", 1, 3, 0, 0 , new int[3] {0,1,-1 }, new int[3] {0,1,-1 },0)},


    };


}
