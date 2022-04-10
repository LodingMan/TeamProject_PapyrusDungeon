using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using DG.Tweening;

public class TownManager : MonoBehaviour
{
    //플레이어의 정보를 관리하는 스크립트. 
    //해당 스크립트에서 현재 주자, 골드, 각 건물의 레벨현황
    public int Week = 0;
    public int Gold = 0;
    public int Jewel = 0;

    public Song.HeroManager heroManager; // inspector창에 HeroManager넣었음
    public Song.GuildManager guildManager;
    public Shin.UI_ChurchManager churchManager;
    public e_CombatManager combatManager;
    public ShopManager shopMgr;
    public Shin.UI_DungeonInitButton DIB;
    public Song.UI_DungeonSelect_Manager uI_DungeonSelect_Manager;

    public List<GameObject> OnControll = new List<GameObject>(); 

    public List<GameObject> OffControll = new List<GameObject>();

    public Text text_Week;
    public Text text_Gold;
    public Text text_Jewel;

    public bool isTown;
    public bool isTent;
    public bool isCombat;

    private void Awake()
    {
        isTown = true;
        isTent = false;
        isCombat = false;
    }
    public void Update()
    {
        text_Week.text = Week.ToString();
        text_Gold.text = Gold.ToString();
        text_Jewel.text = Jewel.ToString();
    }
    public void NextWeek() // 전투 종료 , 처음 게임 시작 등의 이유로 플레이어의 진행도가 다음주로 넘어감.      
    {
        Week++;          // 해당 함수가 실행 되었을때 HeroManager에서 임의의 수만큼 Hero를 랜덤으로 생성하는데 
        heroManager.RandomHeroCreate();  // 생성되는 수는 HeroManager에 선언되어있는 guildManager의 oneDayCreateHeroCount 변수를 참조한다.
        shopMgr.ItemSpawn();

        //Combat_Event_UI_Manager CEUM = GameObject.Find("Combat_Event_UI_Manger").GetComponent<Combat_Event_UI_Manager>();
        




    } //정리하자면 TownManager는 HeroManager에게 영웅을 생성하라 명령하고, HeroManager는 Guild에게 몇마리 생성해야 하는지 값을 받아 생성한다. 

    public void UpdateManager_All_Off()
    {
        // OffControll = GameObject.Find("TentManager");
        // OffControll.GetComponent<ItemUseManager>().enabled = false;
        Debug.Log(OffControll.Count);
        for (int i = 0; i < OffControll.Count; i++)
        {
            OffControll[i].SetActive(false); //이 리스트에 들어간놈들 다 꺼버리는데 나중에 이 리스트로 한번에 다시 켜버리면됨.

        }

        for(int i = 0; i < heroManager.CurrentHeroList.Count; i++)
        {
            heroManager.CurrentHeroList[i].SetActive(false);
        }
        for(int i = 0; i < guildManager.unemployedHero.Length; i++)
        {
            if(guildManager.unemployedHero[i] != null)
            {
                guildManager.unemployedHero[i].SetActive(false);
            }
        }

        for(int i = 0; i < combatManager.myParty.Count; i++)
        {
            combatManager.myParty[i].SetActive(true);
        }

        for(int i = 0; i < OnControll.Count; i++)
        {
            OnControll[i].SetActive(true);
        }

    }

    public void UpdateManager_All_ON()
    {
        Debug.Log("이거 켜지면 안됨");
    }

    public void LoadTownFunc()
    {

        StartCoroutine(LoadTown());
    }
    public IEnumerator LoadTown()
    {
        CombatCameraControll CCC = GameObject.Find("CombatCameraControll").GetComponent<CombatCameraControll>();
        Combat_Event_UI_Manager CEUM = GameObject.Find("Combat_Event_UI_Manger").GetComponent<Combat_Event_UI_Manager>();
      //  Shin.UI_DungeonInitButton DIB = GameObject.Find("TentManager").GetComponent<Shin.UI_DungeonInitButton>();

        CEUM.GameClearPanalUp();
        CCC.BlackFade_In();

        yield return new WaitForSeconds(3);


        for (int i = 0; i < OffControll.Count; i++)
        {
            OffControll[i].SetActive(true); //이 리스트에 들어간놈들 다 꺼버리는데 나중에 이 리스트로 한번에 다시 켜버리면됨.
        }

        for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
        {
            heroManager.CurrentHeroList[i].SetActive(true);
        }

        for (int i = 0; i < OnControll.Count; i++)
        {
            OnControll[i].SetActive(false);
        }


        MapCreate MC = GameObject.Find("MapCreator").GetComponent<MapCreate>();
        MC.MapDestroy();
        CCC.UI_Camera_All_On();
        for(int i = 0; i < uI_DungeonSelect_Manager.buttons.Count; i++)
        {
            uI_DungeonSelect_Manager.buttons[i].SetActive(true);
        }


        combatManager.Out_Dungeon_Party(); //파티맴버 마을로 옮김 , 네비 켜줌

        if ( DIB.camera_Tent.activeSelf) { DIB.camera_Tent.SetActive(false); }
        if ( DIB.camera_Combat.activeSelf) { DIB.camera_Combat.SetActive(false); }
        if ( !DIB.camera_Town.activeSelf)  { DIB.camera_Combat.SetActive(true); }

        if ( DIB.canvas_Tent.activeSelf) { DIB.canvas_Tent.SetActive(false); }
        if( DIB.canvas_Combat.activeSelf) { DIB.canvas_Combat.SetActive(false); }
        if ( !DIB.canvas_Town.activeSelf) { DIB.canvas_Town.SetActive(true); }

        DIB.loadingPanel.DOAnchorPos(new Vector2(1500, 0), 0.5f);
        isTown = true;
        isTent = false;
        isCombat = false;
        
        DIB.dgMgr.isTent = false;
        DIB.TownPrefabs.SetActive(true);
        DIB.TentPrefabs.SetActive(false);
        DIB.canvas_Tent.SetActive(false);

        NextWeek();

    }
}
