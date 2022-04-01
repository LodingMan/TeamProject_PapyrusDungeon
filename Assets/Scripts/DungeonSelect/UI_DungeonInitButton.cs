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
        public Canvas canvas_Town;
        public Camera camera_Town;
        public Canvas canvas_Tent;        
        public Camera camera_Tent;
        public GameObject camfire;
        
        public GuildManager guildMgr;
        public Transform[] tentPos = new Transform[3];

        private void Awake()
        {
            guildMgr = GameObject.Find("GuildManager").GetComponent<GuildManager>();
            btn = GetComponent<Button>();
            btn.onClick.AddListener(OnClickBtn);
        }

        public void OnClickBtn() // 이 버튼이 눌리면 town off, tent on.    
        {
            if (camera_Town.enabled)
            {
                camera_Town.enabled = false;
                camera_Tent.enabled = true;
            }
            if (canvas_Town.enabled)
            {
                canvas_Town.enabled = false;
                canvas_Tent.enabled = true;
            }

            for (int i = 0; i < guildMgr.Party_Hero_Member.Length; i++)
            {
                guildMgr.Party_Hero_Member[i].GetComponent<NaviMeshHero>().herostate = Shin.NaviMeshHero.HEROSTATE.IDLE;
                guildMgr.Party_Hero_Member[i].GetComponent<NaviMeshHero>().anim.SetInteger("herostate", (int)Shin.NaviMeshHero.HEROSTATE.IDLE);
                guildMgr.Party_Hero_Member[i].GetComponent<NaviMeshHero>().enabled = false;
                guildMgr.Party_Hero_Member[i].GetComponent<NavMeshAgent>().enabled = false;
                guildMgr.Party_Hero_Member[i].transform.position = tentPos[i].position;
                guildMgr.Party_Hero_Member[i].transform.LookAt(camfire.transform);
                
            }


        }
    }
}

