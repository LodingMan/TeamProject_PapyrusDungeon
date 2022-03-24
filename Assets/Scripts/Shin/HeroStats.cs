using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class HeroStats : MonoBehaviour //ó�� Ŭ���̾�Ʈ�� �����ϴ� Json������ ���� �����´�. 
{                                      // ������ ���� HeroStats�� �˸´� ������ �־��ش�. 
    List<HeroClass> heroData = new List<HeroClass>();      //�� �������� heroData Ŭ������ ������ ����.
    public int dataLength;                                  //��������� �� ��ũ��Ʈ�� ������Ʈ�� ����ִ� �����ڴ� HeroJson�� ��� ���� ������ �ִ�. 
    public int[] index;                                     //Ŭ���̾�Ʈ�� �����ϴ� Json������ HeroClass ���·� �����ϹǷ� Json�� �о�ö� HeroŬ������ �о�´�.
    public string[] heroName;
    public string[] job;
    public int[] lv;
    public int[] hp;
    public int[] mp;
    public int[] atk;
    public int[] def;
    public int[] cri;
    public int[] acc;
    public int[] agi;
    public string[] weapon;
    public string[] armor;
    public string[] skill01;
    public string[] skill02;
    public string[] skill03;
    public string[] skill04;
    public string[] skill05;

    private void Start()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/" + "Resources" + "/" + "TotalHeroList.json");

        heroData = JsonConvert.DeserializeObject<List<HeroClass>>(jdata);
        dataLength = heroData.Count;
        index = new int[dataLength];
        heroName = new string[dataLength];
        job = new string[dataLength];
        lv = new int[dataLength];
        hp = new int[dataLength];
        mp = new int[dataLength];
        atk = new int[dataLength];
        def = new int[dataLength];
        cri = new int[dataLength];
        acc = new int[dataLength];
        agi = new int[dataLength];
        weapon = new string[dataLength];
        armor = new string[dataLength];
        skill01 = new string[dataLength];
        skill02 = new string[dataLength];
        skill03 = new string[dataLength];
        skill04 = new string[dataLength];
        skill05 = new string[dataLength];


        for (int i = 0; i < dataLength; i++)
        {
            index[i] = heroData[i].index;
            heroName[i] = heroData[i].name;
            job[i] = heroData[i].job;
            lv[i] = heroData[i].lv;
            hp[i] = heroData[i].hp;
            mp[i] = heroData[i].mp;
            atk[i] = heroData[i].atk;
            def[i] = heroData[i].def;
            cri[i] = heroData[i].cri;
            acc[i] = heroData[i].acc;
            weapon[i] = heroData[i].weapon;
            armor[i] = heroData[i].armor;
            skill01[i] = heroData[i].skill01;
            skill02[i] = heroData[i].skill02;
            skill03[i] = heroData[i].skill03;
            skill04[i] = heroData[i].skill04;
            skill05[i] = heroData[i].skill05;
        }

    }

    public void _save()
    {
        string jdata = JsonConvert.SerializeObject(heroData);
        //byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
        //string format = System.Convert.ToBase64String(bytes);

        //File.WriteAllText(Application.dataPath +"/" + "Resources" + "/" + "Hero.json", format);
        File.WriteAllText(Application.dataPath + "/" + "Resources" + "/" + "Hero.json", jdata);
        Debug.Log("���� �Ϸ�");
    }

    public void _load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/" + "Resources" + "/" + "Hero.json");
        //byte[] bytes = System.Convert.FromBase64String(jdata);
        //string reformat = System.Text.Encoding.UTF8.GetString(bytes);

        //heroData = JsonConvert.DeserializeObject<List<HeroesClass>>(reformat);
        heroData = JsonConvert.DeserializeObject<List<HeroClass>>(jdata);
        //Debug.Log(reformat);
        Debug.Log(jdata);
    }

}
