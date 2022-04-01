using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject[] myParty = new GameObject[3];
    public Song.HeroManager heroManager;
    public Song.GuildManager guildManager;

    public void Init_Dungeon_Party()
    {
        myParty = guildManager.Party_Hero_Member;
        //DungeonSelectManager에서 DungeonType가져옴
        //myParty에 있는 Hero오브젝트의 네비 끄기
        //myParty에 있는 Hero오브젝트 전부 전투위치로 옮김.
        //현재 Start에서 실행하는 맵 생성을 이 함수 호출 시기로 바꿈. 
        //미니맵 카메라 활성화
        //Enemy배치 (구상해놓기)
        //
        //
    }

    

    
}
