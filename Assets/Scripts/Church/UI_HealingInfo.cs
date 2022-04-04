using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Shin
{
    public class UI_HealingInfo : MonoBehaviour
    {
        // public HeroSavingData employedHeroData = new HeroSavingData();
        Shin.UI_ChurchManager uI_ChurchManager;
        Song.HeroManager heroManager;
        public TownManager townManager;
        public StatScript statScript;
        public HeroScript_Current_State heroScript_Current_State;
        public Text text_Name;
        public Text text_Job;
        public Button btn; // �ڱ� �ڽ�
        public int curWeek;
        public static int healingCnt; // ȸ������ ���� ����Ʈ ������ ����� static int
        public Button btn_ReturnChurch;
        private void Awake()
        {
            uI_ChurchManager = GameObject.Find("ChurchManager").GetComponent<Shin.UI_ChurchManager>();
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            townManager = GameObject.Find("TownManager").GetComponent<TownManager>();
            btn_ReturnChurch = GameObject.Find("Btn_ReturnChurch").GetComponent<Button>();
            statScript = GetComponent<StatScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();
            btn = GetComponent<Button>();//�ʱ�ȭ
            //btn.onClick.AddListener(Create_EmployedHero_UI_Prefab); // �ڱ��ڽ��� ��ư�� ������ �Լ� ����.
            btn.onClick.AddListener(HealingEnd);
        }

        void Start()
        {
            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++) // ����Ʈ ���̸�ŭ.
            {
                if (gameObject.name == heroManager.CurrentHeroList[i].name) // �̸� ���ؼ�
                {
                    statScript.myStat = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat; // �� �ֱ�.
                    heroScript_Current_State.isHealing = heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isHealing;
                }
            }

            text_Name.text = "�̸� : " + statScript.myStat.Name;
            text_Job.text = "���� : " + statScript.myStat.Job;

        }

        public void HealingEnd() // Btn_HealEnd ��Ŭ��
        {
            // **������������ 1�� �̻��� ������ ȸ�������� �ߵ��ǵ��� �����ؾ���.
            // �ڱ� �ڽŸ� �ǵ��� ����.
            if((townManager.Week - curWeek >= 1)) {
                for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
                {
                    if (gameObject.name == heroManager.CurrentHeroList[i].name)
                    {
                        heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isHealing = false;
                        // ȸ���� ����� �� ȸ���ǵ���.
                        heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat.HP = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat.MAXHP; // hpȸ��
                        heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat.MP = heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat.MAXMP; // mpȸ��
                    }
                }
                uI_ChurchManager.EmployedDestroy_UI();
                uI_ChurchManager.EmployedInit_UI();
                Destroy(gameObject);
            }
            else
            {
                uI_ChurchManager.tweenMgr.UI_ChurchWarningPanel_On();
                uI_ChurchManager.isWarning = true;
                Debug.Log("���� 1�ְ� ������ ����");
            }
            
        }

    }

}