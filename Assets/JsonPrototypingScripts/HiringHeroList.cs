using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;

public class HiringHeroList : MonoBehaviour
{
    public List<HeroesClass> hiringHeroes = new List<HeroesClass>();

    
    public void _Save()
    {
        string jdata = JsonConvert.SerializeObject(hiringHeroes);
        File.WriteAllText(Application.dataPath + "/" + "Resources" + "/" + "hiringHeroes.json", jdata);
    }
    // Json으로 저장 로드할 함수를 새로 만들어야함.

    public void InstantiateInfo()
    {
        
        _Save();
    }
}