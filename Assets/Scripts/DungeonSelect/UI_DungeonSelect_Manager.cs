using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Song
{


    public class UI_DungeonSelect_Manager : MonoBehaviour
    {
        public ManagerTable MgrTable;
        public List<GameObject> buttons;  //���� �ִ���ư �ϴ� ��Ȱ��ȭ �����ֱ�
        public UI_Tweening_Manager uI_Tweening_Manager;
        public UI_SoundMgr soundMgr;
        public bool isDungeonSelect = false;
        public bool isTent = false;
        public int DungeonType;
        public GuildManager guildManager;
        public RectTransform warningDungeonSelect;


        private void Start()
        {
            MgrTable = GameObject.Find("ManagerTable").GetComponent<ManagerTable>();
            uI_Tweening_Manager = GameObject.Find("TweeningManager").GetComponent<UI_Tweening_Manager>();
            soundMgr = GameObject.Find("UI_SoundMgr").GetComponent<UI_SoundMgr>();
        }

        private void Update()
        {
            if (isDungeonSelect)
            {
                if (uI_Tweening_Manager.StackCount == 0)
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        DungeonSelect_Off();
                    }
                }

            }

        }
        public void DungeonSelect_On()
        {
            for (int i = 0; i < 3; i++)
            {
                if (guildManager.Party_Hero_Member[i] == null)
                {
                    Debug.Log("no member");
                    warningDungeonSelect.DOAnchorPos(new Vector2(0, 0), 0.5f);
                    StartCoroutine(WarningDungeonSelect());
                    soundMgr.FailClipDungeonSelect();
                    return;
                }
            }
            MgrTable.tweenManager.UI_BackGroundPanel_On_Off();
            soundMgr.PlayClipBtn();
            //ī�޶� �̵�
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].SetActive(false);//���� ��ư ��Ȱ��
            }
            uI_Tweening_Manager.UI_DungeonSelectPanel_On(); // ����� �г� ������
            isDungeonSelect = true;


        }
        public void DungeonSelect_Off()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].SetActive(true);
            }
            isDungeonSelect = false;

        }

        public void DungeonSelect1()
        {
            DungeonType = 1;
        }
        public void DungeonSelect2()
        {
            DungeonType = 2;
        }
        public void DungeonSelect3()
        {
            DungeonType = 3;
        }

        public void VillageToTent()
        {
            if (!isTent)
            {
                isTent = true;
            }
            else
            {
                isTent = false;
            }
        }
        public IEnumerator WarningDungeonSelect() // shin
        {
            yield return new WaitForSeconds(1f);
            warningDungeonSelect.DOAnchorPos(new Vector2(0, 1090), 0.5f);
        }
        public void EnterDungeon()
        {
            isTent = false;
        }


    }
}
