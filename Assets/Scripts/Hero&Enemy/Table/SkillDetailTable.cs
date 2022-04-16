using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Localization;

namespace Shin {
    // SkillDetailManager�� �޾� ����, ��ų ����� ��ų �̹��� �����.
    public class SkillDetailTable : MonoBehaviour
    {
        public GameObject leanlocalzation;
        List<Dictionary<string, object>> dataKOR;
        List<Dictionary<string, object>> dataENG;
        
        public string currentLanguage;
        public List<SkillDetail> skilldetails = new List<SkillDetail>();
        public Sprite[] sprite;
        
        private void Start()
        {
            dataKOR = CSVReader.Read("SkillDetailKorCSV");
            dataENG = CSVReader.Read("SkillDetailEngCSV");

            currentLanguage = leanlocalzation.GetComponent<LeanLocalization>().DefaultLanguage;
            skilldetails.Add(new SkillDetail(0, "None", "None"));
            if (currentLanguage == "Korean")
            {
                for (var i = 1; i < dataKOR.Count + 1; i++)
                {
                    skilldetails.Add(new SkillDetail(i, dataKOR[i - 1]["Name"].ToString(), dataKOR[i - 1]["Effect"].ToString()));
                }
            }
            else if (currentLanguage == "English")
            {
                for (var i = 1; i < dataENG.Count + 1; i++)
                {
                    skilldetails.Add(new SkillDetail(i, dataENG[i - 1]["Name"].ToString(), dataENG[i - 1]["Effect"].ToString()));
                }
            }
            

            
        }
        public void ChangeLanguage()
        {
            for (var i = 0; i < skilldetails.Count; i++)
            {
                skilldetails.RemoveAt(i);
            }

            currentLanguage = leanlocalzation.GetComponent<LeanLocalization>().currentLanguage;
            skilldetails.Add(new SkillDetail(0, "None", "None"));
            if (currentLanguage == "Korean")
            {
                for (var i = 1; i < dataKOR.Count + 1; i++)
                {
                    skilldetails.Add(new SkillDetail(i, dataKOR[i - 1]["Name"].ToString(), dataKOR[i - 1]["Effect"].ToString()));
                }
            }
            else if (currentLanguage == "English")
            {
                for (var i = 1; i < dataENG.Count + 1; i++)
                {
                    skilldetails.Add(new SkillDetail(i, dataENG[i - 1]["Name"].ToString(), dataENG[i - 1]["Effect"].ToString()));
                }
            }
        }
        /*public void ChangeLanguageKOR()
        {
            for (var i = 0; i < skilldetails.Count; i++)
            {
                skilldetails.RemoveAt(i);
            }     
            currentLanguage = leanlocalzation.GetComponent<LeanLocalization>().currentLanguage;
            skilldetails.Add(new SkillDetail(0, "None", "None"));
            if (currentLanguage == "Korean")
            {
                for (var i = 1; i < dataKOR.Count + 1; i++)
                {
                    skilldetails.Add(new SkillDetail(i, dataKOR[i - 1]["Name"].ToString(), dataKOR[i - 1]["Effect"].ToString()));
                }
            }
        }

        public void ChangeLanguageENG()
        {
            for (var i = 0; i < skilldetails.Count; i++)
            {
                skilldetails.RemoveAt(i);
            }
            currentLanguage = leanlocalzation.GetComponent<LeanLocalization>().currentLanguage;
            skilldetails.Add(new SkillDetail(0, "None", "None"));
            if (currentLanguage == "English")
            {
                for (var i = 1; i < dataKOR.Count + 1; i++)
                {
                    skilldetails.Add(new SkillDetail(i, dataENG[i - 1]["Name"].ToString(), dataENG[i - 1]["Effect"].ToString()));
                }
            }
        }*/

    }
}

