using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using DG.Tweening;
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

        public GameObject inventory;
        public ShopManager shopMgr;

        public RectTransform loadingPanel;
        public GuildManager guildMgr;
        public UI_Tweening_Manager twMgr;
        public Transform[] tentPos = new Transform[3];

        public GameObject TownPrefabs;
        public GameObject TentPrefabs;

        private void Awake()
        {
            guildMgr = GameObject.Find("GuildManager").GetComponent<GuildManager>();
            shopMgr = GameObject.Find("ShopManager").GetComponent<ShopManager>();
            twMgr = GameObject.Find("TweeningManager").GetComponent<UI_Tweening_Manager>();
            btn = GetComponent<Button>();
            btn.onClick.AddListener(OnClickBtn);
            tentPos[0].position = new Vector3(-32f, 0.95f, -132);
            tentPos[1].position = new Vector3(-32.12f, 0.95f, -135.43f);
            tentPos[2].position = new Vector3(-35.29f, 0.95f, -135.98f);

        }

        public void OnClickBtn() // �� ��ư�� ������ town off, tent on.    
        {

            loadingPanel.DOAnchorPos(new Vector2(0, 0), 0.5f);

            for (int i = 0; i < shopMgr.hasItemList.Count; i++)
            {
                shopMgr.hasItemList[i].transform.SetParent(inventory.transform);
                shopMgr.hasItemList[i].transform.localPosition = inventory.transform.localPosition;
                shopMgr.hasItemList[i].transform.localScale = new Vector3(1, 1, 1);
            }
            for (int i = 0; i < shopMgr.hasEquipList.Count; i++)
            {
                shopMgr.hasEquipList[i].transform.SetParent(inventory.transform);
                shopMgr.hasEquipList[i].transform.localPosition = inventory.transform.localPosition;
                shopMgr.hasEquipList[i].transform.localScale = new Vector3(1, 1, 1);
            }

            if (canvas_Town.enabled)
            {
                canvas_Town.enabled = false;
            }
            StartCoroutine(TweenLoadingPanelToTent()); 
        }

        public IEnumerator TweenLoadingPanelToTent()
        {
            yield return new WaitForSeconds(2f);
            if (camera_Town.enabled)
            {
                camera_Town.enabled = false;
            }
            
            if (!camera_Town.enabled) camera_Tent.enabled = true;
            if (!canvas_Town.enabled) canvas_Tent.enabled = true;

            for (int i = 0; i < guildMgr.Party_Hero_Member.Length; i++)
            {
                guildMgr.Party_Hero_Member[i].GetComponent<NaviMeshHero>().herostate = Shin.NaviMeshHero.HEROSTATE.IDLE;
                guildMgr.Party_Hero_Member[i].GetComponent<NaviMeshHero>().anim.SetInteger("herostate", (int)Shin.NaviMeshHero.HEROSTATE.IDLE);
                guildMgr.Party_Hero_Member[i].GetComponent<NaviMeshHero>().enabled = false;
                guildMgr.Party_Hero_Member[i].GetComponent<NavMeshAgent>().enabled = false;
                guildMgr.Party_Hero_Member[i].transform.position = tentPos[i].position;
                guildMgr.Party_Hero_Member[i].transform.LookAt(camfire.transform);
            }

            for (int i = 0; i < twMgr.UIStack.Length; i++)
            {
                twMgr.UIStack[i] = null;
            }
            twMgr.StackCount = 0;
            twMgr.isTentOn = true;
            TownPrefabs.SetActive(false);
            TentPrefabs.SetActive(true);

            loadingPanel.DOAnchorPos(new Vector2(1500, 0), 0.5f);
            twMgr.UI_DungeonSelectPanelPos.DOAnchorPos(new Vector2(0, 1090), 0.5f);
            twMgr.UI_DunGeonEntrance_Pos.DOAnchorPos(new Vector2(0, 1090), 0.5f);
            
        }
        public IEnumerator TweenLoadingPanelToTown()
        {
            yield return new WaitForSeconds(2f);
            if (camera_Tent.enabled)
            {
                camera_Tent.enabled = false;
            }
            if (!camera_Tent.enabled) camera_Town.enabled = true;
            if (!canvas_Tent.enabled) canvas_Town.enabled = true;

            loadingPanel.DOAnchorPos(new Vector2(1500, 0), 0.5f);
            twMgr.isTentOn = false;
            TownPrefabs.SetActive(true);
            TentPrefabs.SetActive(false);
        }
    }
}

