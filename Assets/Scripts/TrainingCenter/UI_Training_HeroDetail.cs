using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin {
    public class UI_Training_HeroDetail : MonoBehaviour // 이 스크립트에서 Training_HeroInfo 패널 관리
    {
        public Shin.UI_Training_EmployedInfo uI_Training_EmployedInfo;
        public Image heroInfo;
        public Text testText00;
        public Text testText01;
        Button btn;
        private void Awake()
        {
            btn = GetComponent<Button>();
            btn.onClick.AddListener(ShowHeroDetail);
        }
        // Start is called before the first frame update
        void Start()
        {
            uI_Training_EmployedInfo = GetComponent<Shin.UI_Training_EmployedInfo>();
            heroInfo = uI_Training_EmployedInfo.heroInfo;
            testText00 = heroInfo.transform.GetChild(0).GetComponent<Text>();
            testText01 = heroInfo.transform.GetChild(1).GetComponent<Text>();
        }

        void ShowHeroDetail()
        {
            testText00.text = uI_Training_EmployedInfo.statScript.myStat.Name;
            testText01.text = uI_Training_EmployedInfo.statScript.myStat.Job;
            heroInfo.name = testText00.text;
        }
    }

}

