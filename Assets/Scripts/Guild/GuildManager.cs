using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//========================================================================================//
// �ش� ��ũ��Ʈ�� ����� ��ġ�� UI�� �ѹ��� �����ϸ� CurrentHeroList�� �ɹ��� ���⼭ �������ϴ�//
//========================================================================================//
public class GuildManager : MonoBehaviour
{
    public int guildLv = 1;
    public int oneDayCreateHeroCount = 3; // ������ �Ѿ�� �� ������ Hero�� ��. ��尡 �������ϰ� �ȴٸ� �ش� ���� ������ �Ϸ翡 ����� �� �ִ� ������ ���� �����Ѵ�. 


    public GameObject unemployedHero_UI_Prefabs_Create_Point;
    public GameObject unemployedHero_UI_Prefab;

    public Song.HeroManager heroManager; // inspectorâ�� HeroManager�־���
    public List<Button> Init_CurrentHeroList_Buttons;
    public List<string> unemployeHeroNames;

    public List<GameObject> unemployedHero; //�Լ��� �Ű������� �������� ����.
    
    public GameObject Current_UI_Prefab;


    public void UnemployedHero_UI_Prefabs_UpLoad(List<GameObject> UnemployedHero)
    {
        unemployedHero = UnemployedHero;

        for (int i = 0; i < UnemployedHero.Count; i++)
        {
            Current_UI_Prefab = Instantiate(unemployedHero_UI_Prefab);
            Current_UI_Prefab.name = "" + i;
            Current_UI_Prefab.transform.parent = unemployedHero_UI_Prefabs_Create_Point.transform;
            Current_UI_Prefab.transform.GetChild(0).GetComponent<Text>().text = "Name : " + UnemployedHero[i].GetComponent<StatScript>().myStat.Name;
            Current_UI_Prefab.transform.GetChild(1).GetComponent<Text>().text = "Job : " + UnemployedHero[i].GetComponent<StatScript>().myStat.Job;
        }

    }

    #region //�����Ǵ� ��� ��ư�� ����� �޸��ϱ� ���� �׳� �Լ� 10�� ���� ����
    public void ListBtn0()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[0]);
    }
    public void ListBtn1()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[1]);
    }
    public void ListBtn2()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[2]);
    }
    public void ListBtn3()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[3]);
    }
    public void ListBtn4()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[4]);
    }
    public void ListBtn5()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[5]);
    }
    public void ListBtn6()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[6]);
    }
    public void ListBtn7()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[7]);
    }
    public void ListBtn8()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[8]);
    }
    public void ListBtn9()
    {
        heroManager.CurrentHeroList.Add(unemployedHero[9]);
    }
    #endregion
}
