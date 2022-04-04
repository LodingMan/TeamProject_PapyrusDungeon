using System.Collections.Generic;
using UnityEngine;

namespace Song
{


    public class UI_DungeonSelect_Manager : MonoBehaviour
    {
        public List<GameObject> buttons;  //원래 있던버튼 싹다 비활성화 시켜주기
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
                    Debug.Log("영웅3명을 파티에 넣어주세요");
                    return;
                }
            }
            //카메라 이동
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].SetActive(false);//기존 버튼 비활성
            }
            uI_Tweening_Manager.UI_DungeonSelectPanel_On(); // 사용할 패널 내려옴
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
