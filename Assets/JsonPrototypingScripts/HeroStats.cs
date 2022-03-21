using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class HeroStats : MonoBehaviour
{
    List<HeroesClass> heroData = new List<HeroesClass>();

    public int[] lv = new int[3];
    public int[] hp = new int[3];
    public int[] mp = new int[3];
    public int[] atk = new int[3];
    public int[] def = new int[3];
    public int[] cri = new int[3];
    public int[] acc = new int[3];
    public int[] agi = new int[3];


    void Awake()
    {
        heroData.Add(new HeroesClass("기사", lv[0], hp[0], mp[0], atk[0], def[0], cri[0], acc[0], agi[0]));
        heroData.Add(new HeroesClass("마법사", lv[1], hp[1], mp[1], atk[1], def[1], cri[1], acc[1], agi[1]));
        heroData.Add(new HeroesClass("짐꾼", lv[2], hp[2], mp[2], atk[2], def[2], cri[2], acc[2], agi[2]));

    }

    public void _save()
    {
        string jdata = JsonConvert.SerializeObject(heroData);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
        string format = System.Convert.ToBase64String(bytes);

        File.WriteAllText(Application.dataPath + "/ysg.json", format);
        Debug.Log("저장 완료");
    }

    public void _load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/ysg.json");
        byte[] bytes = System.Convert.FromBase64String(jdata);
        string reformat = System.Text.Encoding.UTF8.GetString(bytes);

        heroData = JsonConvert.DeserializeObject<List<HeroesClass>>(reformat);
        Debug.Log(reformat);
    }
}
