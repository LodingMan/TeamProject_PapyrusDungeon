using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class HeroStats : MonoBehaviour
{
    List<HeroesClass> heroData = new List<HeroesClass>();

    public string[] heroName = new string[3];
    public int[] lv = new int[3];
    public int[] hp = new int[3];
    public int[] mp = new int[3];
    public int[] atk = new int[3];
    public int[] def = new int[3];
    public int[] cri = new int[3];
    public int[] acc = new int[3];
    public int[] agi = new int[3];
    public string[] weapon = new string[3];
    public string[] armor = new string[3];


    void Awake()
    {
        heroData.Add(new HeroesClass(heroName[0], lv[0], hp[0], mp[0], atk[0], def[0], cri[0], acc[0], agi[0], weapon[0], armor[0]));
        heroData.Add(new HeroesClass(heroName[1], lv[1], hp[1], mp[1], atk[1], def[1], cri[1], acc[1], agi[1], weapon[1], armor[1]));
        heroData.Add(new HeroesClass(heroName[2], lv[2], hp[2], mp[2], atk[2], def[2], cri[2], acc[2], agi[2], weapon[2], armor[2]));

    }

    public void _save()
    {
        string jdata = JsonConvert.SerializeObject(heroData);
        //byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
        //string format = System.Convert.ToBase64String(bytes);

        //File.WriteAllText(Application.dataPath +"/" + "Resources" + "/" + "Hero.json", format);
        File.WriteAllText(Application.dataPath + "/" + "Resources" + "/" + "Hero.json", jdata);
        Debug.Log("저장 완료");
    }

    public void _load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/" + "Resources" + "/" + "Hero.json");
        //byte[] bytes = System.Convert.FromBase64String(jdata);
        //string reformat = System.Text.Encoding.UTF8.GetString(bytes);

        //heroData = JsonConvert.DeserializeObject<List<HeroesClass>>(reformat);
        heroData = JsonConvert.DeserializeObject<List<HeroesClass>>(jdata);
        //Debug.Log(reformat);
        Debug.Log(jdata);
    }

}
