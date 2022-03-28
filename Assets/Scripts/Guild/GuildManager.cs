using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//========================================================================================//
// 해당 스크립트는 길드의 수치와 UI를 한번에 관리하며 CurrentHeroList의 맴버는 여기서 정해집니다//
//========================================================================================//
public class GuildManager : MonoBehaviour
{
    public int guildLv = 1;
    public int oneDayCreateHeroCount = 3; // 주차가 넘어갔을 떄 생성할 Hero의 수. 길드가 레벨업하게 된다면 해당 수가 증가해 하루에 고용할 수 있는 영웅의 수가 증가한다. 


    public GameObject unemployedHero_UI_Prefabs_Create_Point;
    public GameObject currentHero_UI_Prefabs_Create_Point;
    public GameObject unemployedHero_UI_Prefab;
    public GameObject currentHero_UI_Prefab;

    public Song.HeroManager heroManager; // inspector창에 HeroManager넣었음
    public List<Button> Init_CurrentHeroList_Buttons;
    public List<string> unemployeHeroNames;

    public GameObject[] unemployedHero = new GameObject[9]; //함수의 매개변수를 전역으로 저장.

    public List<GameObject> Current_UI_Prefabs;


    public void UnemployedHero_UI_Prefabs_UpLoad(List<GameObject> UnemployedHero)
    {

        Array.Clear(unemployedHero, 0, unemployedHero.Length); //나중에 전투로 넘어가면 이걸로 unemploydHero배열 비울거임

        for (int i = 0; i < UnemployedHero.Count; i++)
        {
            unemployedHero[i] = UnemployedHero[i];

            Current_UI_Prefabs.Add(Instantiate(unemployedHero_UI_Prefab));
            Current_UI_Prefabs[i].name = "" + i;
            Current_UI_Prefabs[i].transform.parent = unemployedHero_UI_Prefabs_Create_Point.transform;
            Current_UI_Prefabs[i].transform.GetChild(0).GetComponent<Text>().text = "Name : " + UnemployedHero[i].GetComponent<StatScript>().myStat.Name;
            Current_UI_Prefabs[i].transform.GetChild(1).GetComponent<Text>().text = "Job : " + UnemployedHero[i].GetComponent<StatScript>().myStat.Job;
        }

    }




    #region //생성되는 모든 버튼의 기능을 달리하기 위해 그냥 함수 10개 갖다 박음
    public void ListBtn0()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[0]);
        heroManager.unemployedHeroList.Remove(unemployedHero[0]);
    }
    public void ListBtn1()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[1]);
        heroManager.unemployedHeroList.Remove(unemployedHero[1]);
    }
    public void ListBtn2()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[2]);
        heroManager.unemployedHeroList.Remove(unemployedHero[2]);
    }
    public void ListBtn3()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[3]);
        heroManager.unemployedHeroList.Remove(unemployedHero[3]);
    }
    public void ListBtn4()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[4]);
        heroManager.unemployedHeroList.Remove(unemployedHero[4]);
    }
    public void ListBtn5()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[5]);
        heroManager.unemployedHeroList.Remove(unemployedHero[5]);
    }
    public void ListBtn6()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[6]);
        heroManager.unemployedHeroList.Remove(unemployedHero[6]);
    }
    public void ListBtn7()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[7]);
        heroManager.unemployedHeroList.Remove(unemployedHero[7]);
    }
    public void ListBtn8()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[8]);
        heroManager.unemployedHeroList.Remove(unemployedHero[8]);
    }
    public void ListBtn9()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[9]);
        heroManager.unemployedHeroList.Remove(unemployedHero[9]);
    }
    #endregion
}
