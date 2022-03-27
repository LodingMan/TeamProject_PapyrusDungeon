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
