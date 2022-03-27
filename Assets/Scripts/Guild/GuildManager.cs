using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuildManager : MonoBehaviour
{
    public int guildLv = 1;
    public int oneDayCreateHeroCount = 3; // 주차가 넘어갔을 떄 생성할 Hero의 수. 길드가 레벨업하게 된다면 해당 수가 증가해 하루에 고용할 수 있는 영웅의 수가 증가한다. 
    public HeroManager heroManager;



}
