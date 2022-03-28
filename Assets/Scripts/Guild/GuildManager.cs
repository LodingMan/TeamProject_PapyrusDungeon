using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//========================================================================================//
// �ش� ��ũ��Ʈ�� ����� ��ġ�� UI�� �ѹ��� �����ϸ� CurrentHeroList�� �ɹ��� ���⼭ �������ϴ�//
//========================================================================================//
public class GuildManager : MonoBehaviour
{
    public int guildLv = 1;
    public int oneDayCreateHeroCount = 3; // ������ �Ѿ�� �� ������ Hero�� ��. ��尡 �������ϰ� �ȴٸ� �ش� ���� ������ �Ϸ翡 ����� �� �ִ� ������ ���� �����Ѵ�. 


    public GameObject unemployedHero_UI_Prefabs_Create_Point;
    public GameObject currentHero_UI_Prefabs_Create_Point;
    public GameObject unemployedHero_UI_Prefab;
    public GameObject currentHero_UI_Prefab;

    public Song.HeroManager heroManager; // inspectorâ�� HeroManager�־���
    public List<Button> Init_CurrentHeroList_Buttons;
    public List<string> unemployeHeroNames;

    public GameObject[] unemployedHero = new GameObject[9]; //�Լ��� �Ű������� �������� ����.

    public List<GameObject> Current_UI_Prefabs;


    public void UnemployedHero_UI_Prefabs_UpLoad(List<GameObject> UnemployedHero)
    {

        Array.Clear(unemployedHero, 0, unemployedHero.Length); //���߿� ������ �Ѿ�� �̰ɷ� unemploydHero�迭 ������

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




    #region //�����Ǵ� ��� ��ư�� ����� �޸��ϱ� ���� �׳� �Լ� 10�� ���� ����
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
