using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using DG.Tweening;

public class TownManager : MonoBehaviour
{
    //�÷��̾��� ������ �����ϴ� ��ũ��Ʈ. 
    //�ش� ��ũ��Ʈ���� ���� ����, ���, �� �ǹ��� ������Ȳ
    public int Week = 0;
    public int Gold = 0;
    public int Jewel = 0;

    public ManagerTable MgrTable;
    public IntroSceneScript introSceneScript;
    public Song.HeroManager heroManager; // inspectorâ�� HeroManager�־���
    public Song.GuildManager guildManager;
    public Shin.UI_ChurchManager churchManager;
    public e_CombatManager combatManager;
    public ShopManager shopMgr;
    public Shin.UI_DungeonInitButton DIB;
    public Song.UI_DungeonSelect_Manager uI_DungeonSelect_Manager;
    public GameObject equipInfoCanvus;
    public Image equipImage;
    public Text[] equipInfos = new Text[4];

    public List<GameObject> OnControll = new List<GameObject>(); 

    public List<GameObject> OffControll = new List<GameObject>();

    public Text text_Week;
    public Text text_Gold;
    public Text text_Jewel;

    public bool isTown;
    public bool isTent;
    public bool isCombat;
    public bool isInven;

    
    private void Awake()
    {
        introSceneScript = GameObject.Find("BGM_Manager").GetComponent<IntroSceneScript>();
        MgrTable = GameObject.Find("ManagerTable").GetComponent<ManagerTable>();
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
    public void NextWeek() // ���� ���� , ó�� ���� ���� ���� ������ �÷��̾��� ���൵�� �����ַ� �Ѿ.      
    {
        Week++;          // �ش� �Լ��� ���� �Ǿ����� HeroManager���� ������ ����ŭ Hero�� �������� �����ϴµ� 
        heroManager.RandomHeroCreate();  // �����Ǵ� ���� HeroManager�� ����Ǿ��ִ� guildManager�� oneDayCreateHeroCount ������ �����Ѵ�.
        shopMgr.ItemSpawn();

        //Combat_Event_UI_Manager CEUM = GameObject.Find("Combat_Event_UI_Manger").GetComponent<Combat_Event_UI_Manager>();
        




    } //�������ڸ� TownManager�� HeroManager���� ������ �����϶� �����ϰ�, HeroManager�� Guild���� ��� �����ؾ� �ϴ��� ���� �޾� �����Ѵ�. 

    public void UpdateManager_All_Off()
    {
        // OffControll = GameObject.Find("TentManager");
        // OffControll.GetComponent<ItemUseManager>().enabled = false;
        Debug.Log(OffControll.Count);
        for (int i = 0; i < OffControll.Count; i++)
        {
            OffControll[i].SetActive(false); //�� ����Ʈ�� ����� �� �������µ� ���߿� �� ����Ʈ�� �ѹ��� �ٽ� �ѹ������.

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
        Debug.Log("�̰� ������ �ȵ�");
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
            OffControll[i].SetActive(true); //�� ����Ʈ�� ����� �� �������µ� ���߿� �� ����Ʈ�� �ѹ��� �ٽ� �ѹ������.
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


        combatManager.Out_Dungeon_Party(); //��Ƽ�ɹ� ������ �ű� , �׺� ����

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
        introSceneScript.audioSS.clip = introSceneScript.audioTown;
        introSceneScript.audioSS.Play();
        

        DIB.dgMgr.isTent = false;
        DIB.TownPrefabs.SetActive(true);
        DIB.TentPrefabs.SetActive(false);
        DIB.canvas_Tent.SetActive(false);

        NextWeek();
        
    }

    public void ClickInven()
    {
        isInven = true;
    }
}
