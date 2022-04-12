using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public ManagerTable MgrTable;
    public QuestionPanel questionPanel;
    public TownManager townMgr;
    public GameObject guildTuto00;
    public GameObject guildTuto01;
    public GameObject guildTuto02;
    public GameObject guildTuto03;
    public GameObject guildTuto04;
    public GameObject EnterTuto00;
    public GameObject EnterTuto01;
    public GameObject QuestionPanel;

    public bool[] guildTuto;
    public bool[] enterTuto;

    public bool isChurch;
    public bool isTrain;
    public bool isInven;
    public bool isShop;
    public bool isSmith;
    // Start is called before the first frame update
    void Start()
    {
        MgrTable = GameObject.Find("ManagerTable").GetComponent<ManagerTable>();
        townMgr = MgrTable.townManager;
        guildTuto = new bool[5];
        enterTuto = new bool[2];
        guildTuto[0] = true; 
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
        MgrTable.tweenManager.isTuto = false;
        EnterTuto01.SetActive(false);
    }

    public void QuestionOn()
    {
        QuestionPanel.SetActive(true);
        questionPanel.Church.SetActive(true);
        isChurch = true;
    }
    public void QuestionOff()
    {
        questionPanel.Church.SetActive(false);
        questionPanel.Train.SetActive(false);
        questionPanel.Inven.SetActive(false);
        questionPanel.Shop.SetActive(false);
        questionPanel.Smith.SetActive(false);
        isChurch = false;
        isTrain = false;
        isInven = false;
        isShop = false;
        isSmith = false;
        QuestionPanel.SetActive(false);

        
    }
}

