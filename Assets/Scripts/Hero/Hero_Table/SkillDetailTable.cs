using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shin {
    public class SkillDetailTable : MonoBehaviour
    {
        public List<SkillDetail> skilldetails = new List<SkillDetail>();

        private void Start()
        {
            for (int i = 0; i < 40; i++)
            {
                skilldetails.Add(new SkillDetail(i, "SkillName" + (i+1), i + "번 스킬 설명입니다"));
            }
        }

    }
}

