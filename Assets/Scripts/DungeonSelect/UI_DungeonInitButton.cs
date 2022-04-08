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
        public Button btn;
        public GameObject canvas_Town;
        public GameObject camera_Town;
        public GameObject canvas_Tent;        
        public GameObject camera_Tent;
        public GameObject camfire;

        public GameObject inventory;
        public ShopManager shopMgr;

        public RectTransform loadingPanel;
        public GuildManager guildMgr;
        public UI_Tweening_Manager twMgr;
        public Song.UI_DungeonSelect_Manager dgMgr;
        public Transform[] tentPos = new Transform[3];

        public GameObject TownPrefabs;
        public GameObject TentPrefabs;

        private void Awake()
        {
            guildMgr = GameObject.Find("GuildManager").GetComponent<GuildManager>();
            shopMgr = GameObject.Find("ShopManager").GetComponent<ShopManager>();
            twMgr = GameObject.Find("TweeningManager").GetComponent<UI_Tweening_Manager>();
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

            if (canvas_Town.activeSelf)
            {
                canvas_Town.SetActive(false);
            }
            StartCoroutine(TweenLoadingPanelToTent()); 
        }

        public IEnumerator TweenLoadingPanelToTent()
        {
            yield return new WaitForSeconds(2f);
            if (camera_Town.activeSelf)
            {
                camera_Town.SetActive(false);
            }
            
            if (!camera_Town.activeSelf) camera_Tent.SetActive(true);
            if (!canvas_Town.activeSelf) canvas_Tent.SetActive(true);

            for (int i = 0; i < guildMgr.Party_Hero_Member.Length; i++)
            {
                guildMgr.Party_Hero_Member[i].GetComponent<NaviMeshHero>().herostate = Shin.NaviMeshHero.HEROSTATE.IDLE;
                guildMgr.Party_Hero_Member[i].GetComponent<NaviMeshHero>().anim.SetInteger("herostate", (int)Shin.NaviMeshHero.HEROSTATE.IDLE);
                guildMgr.Party_Hero_Member[i].GetComponent<NaviMeshHero>().enabled = false;
                guildMgr.Party_Hero_Member[i].GetComponent<NavMeshAgent>().enabled = false;
                guildMgr.Party_Hero_Member[i].transform.position = tentPos[i].position;
                guildMgr.Party_Hero_Member[i].transform.LookAt(camfire.transform);
                
            }

            for (int i = 0; i < guildMgr.heroManager.CurrentHeroList.Count; i++)//여기서 검사해서.
            {
                if (!guildMgr.heroManager.CurrentHeroList[i].GetComponent<HeroScript_Current_State>().isParty) //파티중이 아닌 애들은
                {
                    guildMgr.heroManager.CurrentHeroList[i].SetActive(false);
                }
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
            if (camera_Tent.activeSelf)
            {
                camera_Tent.SetActive(false);
            }
            if (!camera_Tent.activeSelf) camera_Town.SetActive(true); 
            if (!canvas_Tent.activeSelf) canvas_Town.SetActive(true);

            loadingPanel.DOAnchorPos(new Vector2(1500, 0), 0.5f);
            twMgr.isTentOn = false;
            dgMgr.isTent = false;
            TownPrefabs.SetActive(true);
            TentPrefabs.SetActive(false);

            for (int i = 0; i < guildMgr.Party_Hero_Member.Length; i++)
            {
                guildMgr.Party_Hero_Member[i].transform.position = new Vector3(0,0,0); // 이거를 TownPos로 변경.
                guildMgr.Party_Hero_Member[i].GetComponent<NavMeshAgent>().enabled = true;
                guildMgr.Party_Hero_Member[i].GetComponent<NaviMeshHero>().enabled = true;
                
                // 여기서 
            }
            for (int i = 0; i < guildMgr.heroManager.CurrentHeroList.Count; i++)//여기서 검사해서.
            {
                if (guildMgr.heroManager.CurrentHeroList[i].activeSelf == false) // 꺼져있는 애들을 다시 켜줌.
                {
                    guildMgr.heroManager.CurrentHeroList[i].SetActive(true);
                }
            }
        }
    }
}

