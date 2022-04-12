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
    public GameObject guildTuto07;
    public GameObject churchTuto00;
    public GameObject churchTuto01;

    public bool[] guildTuto;
    public bool[] enterTuto;
    public bool[] churchTuto;
    // Start is called before the first frame update
    void Start()
    {
        MgrTable = GameObject.Find("ManagerTable").GetComponent<ManagerTable>();
        townMgr = MgrTable.townManager;
        guildTuto = new bool[8];
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
            MgrTable.tweenManager.isTuto = true;
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
            GuildTuto07On();
        }

    }
    public void GuildTuto07On()
    {
        if (townMgr.Week == 2 && guildTuto[6])
        {
            guildTuto[6] = false;
            guildTuto[7] = true;
            guildTuto07.SetActive(true);
        }
    }

    public void GuildTuto07Off()
    {
        guildTuto07.SetActive(false);
        ChurchTuto00On();
    }
    public void ChurchTuto00On()
    {
        if (townMgr.Week == 2 && guildTuto[7])
        {
            guildTuto[7] = false;
            churchTuto[0] = true;
            churchTuto00.SetActive(true);
        }
    }
    public void ChurchTuto00Off()
    {
        churchTuto00.SetActive(false);
    }
    public void ChurchTuto01On()
    {
        if (townMgr.Week == 2 && churchTuto[0])
        {
            churchTuto[0] = false;
            churchTuto[1] = true;
            churchTuto01.SetActive(true);
        }
    }
    
}

