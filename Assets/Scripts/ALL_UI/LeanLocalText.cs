using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Localization;
using Shin;
using Song;

namespace Shin {
    public class LeanLocalText : MonoBehaviour
    {
        public LeanLocalization leanlocalzation;
        public string currentLanguage;
        public string oriText;
        public Text text;
        List<Dictionary<string, object>> dataText;
        
        void Start()
        {
            leanlocalzation = GameObject.Find("LeanLocalization").GetComponent<LeanLocalization>();
            text = GetComponent<Text>();
            dataText = CSVReader.Read("TextCSV");
            currentLanguage = leanlocalzation.GetComponent<LeanLocalization>().currentLanguage;

            oriText = dataText[0][text.text].ToString(); // 영어가 기본
            text.text = oriText;

        }
        private void Update()
        {
            ChangeLanguage();
        }

        public void ChangeLanguage()
        {
            currentLanguage = leanlocalzation.GetComponent<LeanLocalization>().currentLanguage;
            if (currentLanguage == "English")
            {
                text.text = dataText[0][oriText].ToString();
            }
            else if (currentLanguage == "Korean")
            {
                text.text = dataText[1][oriText].ToString();
            }
        }
    }
    
}

