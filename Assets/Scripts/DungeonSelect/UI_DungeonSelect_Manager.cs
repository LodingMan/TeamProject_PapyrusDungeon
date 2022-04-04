using System.Collections.Generic;
using UnityEngine;

namespace Song
{


    public class UI_DungeonSelect_Manager : MonoBehaviour
    {
        public List<GameObject> buttons;  //���� �ִ���ư �ϴ� ��Ȱ��ȭ �����ֱ�
        public UI_Tweening_Manager uI_Tweening_Manager;
        public bool isDungeonSelect = false;
        public bool isTent = false;
        public int DungeonType;
        public GuildManager guildManager;

        private void Start()
        {
            uI_Tweening_Manager = GameObject.Find("TweeningManager").GetComponent<UI_Tweening_Manager>();

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
                    Debug.Log("����3���� ��Ƽ�� �־��ּ���");
                    return;
                }
            }
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
    }
}
