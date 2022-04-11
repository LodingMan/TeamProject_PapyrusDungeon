using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public ManagerTable MgrTable;
    public TownManager townMgr;
    public GameObject guildTuto01;
    public GameObject guildTuto02;
    public GameObject guildTuto03;
    public GameObject guildTuto04;
    public GameObject guildTuto05;
    // Start is called before the first frame update
    void Start()
    {
        MgrTable = GameObject.Find("ManagerTable").GetComponent<ManagerTable>();
        townMgr = MgrTable.townManager;
        
        if (PlayerPrefs.HasKey("Week")) // Week가 존재하면, 이미 했다는거
        {
            townMgr.Week = PlayerPrefs.GetInt("Week");
        }
        else
        {
            townMgr.NextWeek();
            if (townMgr.Week == 1)
            {
                guildTuto01.SetActive(true);
                // 길드 튜토리얼 시작.
            }

        }
        
    }
    private void Update()
    {
        if (townMgr.Week == 1)
        {
            if (guildTuto04.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    guildTuto04.SetActive(false);
                    guildTuto05.SetActive(true);
                }
            }
        }
    }
    public void GuildTuto01On()
    {
        guildTuto01.SetActive(true);
    }
    public void GuildTuto01Off()
    {
        guildTuto01.SetActive(false);
        GuildTuto02On();
    }
    public void GuildTuto02On()
    {
        if (townMgr.Week == 1)
        {
            guildTuto02.SetActive(true);
        }
    }

    public void GuildTuto02Off()
    {
        if (MgrTable.heroManager.CurrentHeroList.Count >= 3)
        {
            guildTuto02.SetActive(false);
            guildTuto03.SetActive(true);
        }
    }
    public void GuildTuto03Off()
    {
        if (MgrTable.guildManager.Party_Hero_Member[0] != null 
            && MgrTable.guildManager.Party_Hero_Member[1] != null 
            && MgrTable.guildManager.Party_Hero_Member[2] != null)  
        {
            guildTuto03.SetActive(false);
            guildTuto04.SetActive(true);
            
        }
    }

    public void GuildTuto05Off()
    {
        guildTuto05.SetActive(false);
    }


}
