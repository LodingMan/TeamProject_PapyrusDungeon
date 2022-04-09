using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin {
    // SkillDetailManager�� �޾� ����, ��ų ����� ��ų �̹��� �����.
    public class SkillDetailTable : MonoBehaviour
    {
        public List<SkillDetail> skilldetails = new List<SkillDetail>();
        public Sprite[] sprite;

        private void Start()
        {
            List<Dictionary<string, object>> data = CSVReader.Read("SkillDetailCSV");

            // ���⼭ Lean���� ������ ����.

            skilldetails.Add(new SkillDetail(0, "None", "None"));

            for (var i = 1; i < data.Count+1; i++)
            {
                skilldetails.Add(new SkillDetail(i, data[i-1]["Name"].ToString(), data[i-1]["Effect"].ToString()));
            }
        }

    }
}

