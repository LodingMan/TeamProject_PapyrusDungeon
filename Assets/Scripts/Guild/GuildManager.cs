using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//========================================================================================//
// 해당 스크립트는 길드의 수치와 UI를 한번에 관리하며 CurrentHeroList의 맴버는 여기서 정해집니다//
//========================================================================================//
public class GuildManager : MonoBehaviour
{
    public int guildLv = 1;
    public int oneDayCreateHeroCount = 3; // 주차가 넘어갔을 떄 생성할 Hero의 수. 길드가 레벨업하게 된다면 해당 수가 증가해 하루에 고용할 수 있는 영웅의 수가 증가한다. 


    public GameObject unemployedHero_UI_Prefabs_Create_Point;
    public GameObject unemployedHero_UI_Prefab;

    public Song.HeroManager heroManager; // inspector창에 HeroManager넣었음



    public void UnemployedHero_UI_Prefabs_UpLoad(List<GameObject> unemployedHero)
    {
        GameObject Current_UI_Prefab;

        for (int i = 0; i < unemployedHero.Count; i++)
        {
            Current_UI_Prefab = Instantiate(unemployedHero_UI_Prefab);
            Current_UI_Prefab.transform.parent = unemployedHero_UI_Prefabs_Create_Point.transform;
            Current_UI_Prefab.transform.GetChild(0).GetComponent<Text>().text = "Name : " + unemployedHero[i].GetComponent<StatScript>().myStat.Name;
            Current_UI_Prefab.transform.GetChild(1).GetComponent<Text>().text = "Job : " + unemployedHero[i].GetComponent<StatScript>().myStat.Job;


        }

    }

    private void Start()
    {

    }
}
