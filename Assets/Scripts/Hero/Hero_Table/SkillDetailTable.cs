using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin {
    public class SkillDetailTable : MonoBehaviour
    {
        public List<SkillDetail> skilldetails = new List<SkillDetail>();
        public Sprite[] sprite;
        private void Start()
        {
            for (int i = 0; i < 40; i++)
            {
                skilldetails.Add(new SkillDetail(i, "SkillName" + (i+1), i + "번 스킬 설명입니다"));
            }
        }

    }
}

