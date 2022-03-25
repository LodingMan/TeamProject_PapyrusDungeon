using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class TotalHeroMgr : MonoBehaviour
{
    public List<HeroClass> heroData = new List<HeroClass>();

    private void Start()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/" + "Resources" + "/" + "TotalHero.json");

        heroData = JsonConvert.DeserializeObject<List<HeroClass>>(jdata);
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
        heroData = JsonConvert.DeserializeObject<List<HeroClass>>(jdata);
        //Debug.Log(reformat);
        Debug.Log(jdata);
    }

}
