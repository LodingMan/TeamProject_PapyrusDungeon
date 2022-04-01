using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Song;

namespace Shin
{
    public class UI_DungeonInitButton : MonoBehaviour
    {
        Button btn;
        public GameObject canvas_Town;
        public GameObject camera_Town;
        public GameObject canvas_Tent;        
        public GameObject camera_Tent;
        public GuildManager guildMgr;
        public Transform[] tentPos = new Transform[3];

        private void Awake()
        {
            guildMgr = GameObject.Find("GuildManager").GetComponent<GuildManager>();
            btn = GetComponent<Button>();
            btn.onClick.AddListener(OnClickBtn);
        }

        public void OnClickBtn()
        {
            if (camera_Town.activeSelf == true)
            {
                camera_Town.SetActive(false);
                camera_Tent.SetActive(true);
            }
            if (canvas_Town.activeSelf == true)
            {
                canvas_Town.SetActive(false);
                canvas_Tent.SetActive(true);
            }

            for (int i = 0; i < guildMgr.Party_Hero_Member.Length; i++)
            {
                guildMgr.Party_Hero_Member[i].GetComponent<NaviMeshHero>().enabled = false;
                guildMgr.Party_Hero_Member[i].GetComponent<NavMeshAgent>().enabled = false;
                guildMgr.Party_Hero_Member[i].transform.position = tentPos[i].position;
            }


        }
    }
}

