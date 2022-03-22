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
    // Json���� ���� �ε��� �Լ��� ���� ��������.

    public void InstantiateInfo()
    {
        
        _Save();
    }
}