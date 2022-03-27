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

    public void NextWeek() // 전투 종료 , 처음 게임 시작 등의 이유로 플레이어의 진행도가 다음주로 넘어감.
    {                       // 해당 함수가 실행 되었을때 HeroManager에서 임의의 수만큼 Hero를 랜덤으로 생성하는데 
        Week++;             // 생성되는 수는 HeroManager에 선언되어있는 guildManager의 oneDayCreateHeroCount 변수를 참조한다. 
        //heroManager.RandomHeroCreate();
    } //정리하자면 TownManager는 HeroManager에게 영웅을 생성하라 명령하고, HeroManager는 Guild에게 몇마리 생성해야 하는지 값을 받아 생성한다. 
}
