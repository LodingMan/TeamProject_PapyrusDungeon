using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class TownManager : MonoBehaviour
{
    //플레이어의 정보를 관리하는 스크립트. 
    //해당 스크립트에서 현재 주자, 골드, 각 건물의 레벨현황 
    public int Week = 0;
    public int Gold = 0;

    public Song.HeroManager heroManager; // inspector창에 HeroManager넣었음
    public Shin.UI_ChurchManager churchManager;
    public e_CombatManager combatManager;

    public List<GameObject> OnControll = new List<GameObject>(); 

    public List<GameObject> OffControll = new List<GameObject>();
    public void NextWeek() // 전투 종료 , 처음 게임 시작 등의 이유로 플레이어의 진행도가 다음주로 넘어감.
                           // 해당 함수가 실행 되었을때 HeroManager에서 임의의 수만큼 Hero를 랜덤으로 생성하는데 
                           // 생성되는 수는 HeroManager에 선언되어있는 guildManager의 oneDayCreateHeroCount 변수를 참조한다.
    {
        Week++;
        //churchManager.HealingEnd();
        //churchManager.curWeek = Week;
        heroManager.RandomHeroCreate();
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
        for(int i = 0; i < heroManager.unemployedHeroList.Count; i++)
        {
            heroManager.unemployedHeroList[i].SetActive(false);
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
}
