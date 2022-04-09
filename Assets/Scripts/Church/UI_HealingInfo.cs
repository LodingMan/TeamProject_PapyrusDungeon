using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Shin
{
    public class UI_HealingInfo : MonoBehaviour
    {
        Shin.UI_ChurchManager uI_ChurchManager;
        Song.HeroManager heroManager;
        HeroImageTable heroImageTable;
        public TownManager townManager;
        public StatScript statScript;
        public HeroScript_Current_State heroScript_Current_State;
        public Text text_Name;
        public Text text_Job;
        public Button btn; // �ڱ� �ڽ�
        public Image heroIcon;
        
        public int curWeek;
        public static int healingCnt; // ȸ������ ���� ����Ʈ ������ ����� static int
        //public Button btn_ReturnChurch;
        private void Awake()
        {
            uI_ChurchManager = GameObject.Find("ChurchManager").GetComponent<Shin.UI_ChurchManager>();
            heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
            townManager = GameObject.Find("TownManager").GetComponent<TownManager>();
            heroImageTable = GameObject.Find("HeroImageManager").GetComponent<Shin.HeroImageTable>();

            statScript = GetComponent<StatScript>();
            heroScript_Current_State = GetComponent<HeroScript_Current_State>();

            btn = GetComponent<Button>();//�ʱ�ȭ
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

            text_Name.text = statScript.myStat.Name;
            text_Job.text = statScript.myStat.Job;
            switch (statScript.myStat.Job)
            {
                case "Babarian":
                    heroIcon.sprite = heroImageTable.sprite[0];
                    break;
                case "Archer":
                    heroIcon.sprite = heroImageTable.sprite[1];
                    break;
                case "Knight":
                    heroIcon.sprite = heroImageTable.sprite[2];
                    break;
                case "Barristan":
                    heroIcon.sprite = heroImageTable.sprite[3];
                    break;
                case "Mage":
                    heroIcon.sprite = heroImageTable.sprite[4];
                    break;
                case "Porter":
                    heroIcon.sprite = heroImageTable.sprite[5];
                    break;
                default:
                    break;
            }
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
                uI_ChurchManager.isWarning = true;
                uI_ChurchManager.tweenMgr.UI_ChurchWarning_On();
                StartCoroutine(WarningPanelOff());
            }
        }

        IEnumerator WarningPanelOff()
        {
            yield return new WaitForSeconds(1f);
            if (uI_ChurchManager.isWarning)
            {
                uI_ChurchManager.isWarning = false;
            }
            
        }
    }

}