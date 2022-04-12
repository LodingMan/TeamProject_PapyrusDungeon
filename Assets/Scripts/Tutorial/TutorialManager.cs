using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public ManagerTable MgrTable;
    public TownManager townMgr;
    public GameObject guildTuto00;
    public GameObject guildTuto01;
    public GameObject guildTuto02;
    public GameObject guildTuto03;
    public GameObject guildTuto04;
    public GameObject EnterTuto00;
    public GameObject EnterTuto01;
    public GameObject guildTuto05;
    public GameObject guildTuto06;

    public bool[] guildTuto;
    public bool[] enterTuto;
    public bool[] churchTuto;
    // Start is called before the first frame update
    void Start()
    {
        MgrTable = GameObject.Find("ManagerTable").GetComponent<ManagerTable>();
        townMgr = MgrTable.townManager;
        guildTuto = new bool[7];
        enterTuto = new bool[2];
        churchTuto = new bool[3];
        guildTuto[0] = true;
        if (PlayerPrefs.HasKey("Week")) // Week가 존재하면, 이미 했다는거
        {
            townMgr.Week = PlayerPrefs.GetInt("Week");
        }
        else
        {
            townMgr.NextWeek();
            if (townMgr.Week == 1)
            {
                guildTuto00.SetActive(true);
                MgrTable.tweenManager.isTuto = true;
                // 길드 튜토리얼 시작.
            }

        }
        
    }
    private void Update()
    {
        if (townMgr.Week != 1)
        {
            MgrTable.tweenManager.isTuto = false;
        }
/*        if (townMgr.Week == 1)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && MgrTable.tweenManager.isTuto)
            {
                if (MgrTable.tweenManager.isGuild == false)
                {
                    GuildTuto04Off();
                }
            }
        }*/
    }
    public void GuildTuto00On()
    {
        if (guildTuto[0])
        {
            guildTuto[0] = true;
            guildTuto00.SetActive(true);
        }
    }
    public void GuildTuto00Off()
    {
        guildTuto00.SetActive(false);
        GuildTuto01On();
    }
    public void GuildTuto01On()
    {
        if (townMgr.Week == 1 && guildTuto[0])
        {
            guildTuto[0] = false;
            guildTuto[1] = true;
            guildTuto01.SetActive(true);
        }
    }

    public void GuildTuto01Off()
    {
        if (MgrTable.heroManager.CurrentHeroList.Count >= 3)
        {
            guildTuto01.SetActive(false);
            GuildTuto02On();
        }
    }
    public void GuildTuto02On()
    {
        if (townMgr.Week == 1 && guildTuto[1])
        {
            guildTuto[1] = false;
            guildTuto[2] = true;
            guildTuto02.SetActive(true);
        }
    }
    public void GuildTuto02Off()
    {
        if (MgrTable.guildManager.Party_Hero_Member[0] != null 
            && MgrTable.guildManager.Party_Hero_Member[1] != null 
            && MgrTable.guildManager.Party_Hero_Member[2] != null)  
        {
            guildTuto02.SetActive(false);
            GuildTuto03On();
        }
    }
    public void GuildTuto03On()
    {
        if (townMgr.Week == 1 && guildTuto[2])
        {
            guildTuto[2] = false;
            guildTuto[3] = true;
            guildTuto03.SetActive(true);
        }
    }
    public void GuildTuto03Off()
    {
        guildTuto03.SetActive(false);
        GuildTuto04On();
    }
    public void GuildTuto04On()
    {
        if (townMgr.Week == 1 && guildTuto[3])
        {
            guildTuto[3] = false;
            guildTuto[4] = true;
            guildTuto04.SetActive(true);
        }
    }
    public void GuildTuto04Off()
    {
        guildTuto04.SetActive(false);
    }

    public void EnterTuto00On()
    {
        if (townMgr.Week == 1 && guildTuto[4])
        {
            guildTuto[4] = false;
            enterTuto[0] = true;
            EnterTuto00.SetActive(true);
        }
    }
    public void EnterTuto00Off()
    {
        EnterTuto00.SetActive(false);
        EnterTuto01On();
    }
    public void EnterTuto01On()
    {
        if (townMgr.Week == 1 && enterTuto[0])
        {
            enterTuto[0] = false;
            enterTuto[1] = true;
            EnterTuto01.SetActive(true);
        }
        
    }
    public void EnterTuto01Off()
    {
        EnterTuto01.SetActive(false);
    }


    public void GuildTuto05On()
    {
        if (townMgr.Week == 2 && enterTuto[1])
        {
            enterTuto[1] = false;
            guildTuto[5] = true;
            guildTuto05.SetActive(true);
        }
    }
    public void GuildTuto05Off()
    {
        guildTuto05.SetActive(false);
    }

    public void GuildTuto06On()
    {
        if (townMgr.Week == 2 && guildTuto[5])
        {
            guildTuto[5] = false;
            guildTuto[6] = true;
            guildTuto06.SetActive(true);
        }
    }
    public void GuildTuto06Off()
    {
        if (MgrTable.guildManager.Party_Hero_Member[0] == null && MgrTable.guildManager.Party_Hero_Member[1] == null && MgrTable.guildManager.Party_Hero_Member[2] == null)
        {
            guildTuto06.SetActive(false);
        }  
    }
    
    public void ChurchTuto00On()
    {

    }
    public void ChurchTuto00Off()
    {

    }
    
}

