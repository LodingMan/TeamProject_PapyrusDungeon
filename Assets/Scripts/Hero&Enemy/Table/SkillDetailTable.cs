using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Localization;

namespace Shin
{
    // SkillDetailManagerï¿½ï¿½ ï¿½Þ¾ï¿½ ï¿½ï¿½ï¿½ï¿½, ï¿½ï¿½Å³ ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½Å³ ï¿½Ì¹ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½.
    public class SkillDetailTable : MonoBehaviour
    {
        public GameObject leanlocalzation;
        List<Dictionary<string, object>> dataKOR;
        List<Dictionary<string, object>> dataENG;

        List<Dictionary<string, object>> dataJPN;
        public string currentLanguage;
        public List<SkillDetail> skilldetails = new List<SkillDetail>();
        public Sprite[] sprite;

        private void Start()
        {
            dataKOR = CSVReader.Read("SkillDetailKorCSV");
            dataENG = CSVReader.Read("SkillDetailEngCSV");
            dataJPN = CSVReader.Read("SkillDetailJpnCSV");

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
            else if (currentLanguage == "Japanese")
            {
                for (var i = 1; i < dataJPN.Count + 1; i++)
                {
                    skilldetails.Add(new SkillDetail(i, dataJPN[i - 1]["Name"].ToString(), dataJPN[i - 1]["Effect"].ToString()));
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
            else if (currentLanguage == "Japanese")
            {
                for (var i = 1; i < dataJPN.Count + 1; i++)
                {
                    Debug.Log("ÀÏº»¾î");
                    skilldetails.Add(new SkillDetail(i, dataJPN[i - 1]["Name"].ToString(), dataJPN[i - 1]["Effect"].ToString()));
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

