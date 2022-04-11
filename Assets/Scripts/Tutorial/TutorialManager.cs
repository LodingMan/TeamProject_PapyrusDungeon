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
        if (townMgr.Week == 1)
        {
            GuildTuto02Off();
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
        if (MgrTable.heroManager.CurrentHeroList.Count >= 2)
        {
            guildTuto02.SetActive(false);
        }
    }
}
