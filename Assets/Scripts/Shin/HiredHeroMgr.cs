using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class HiredHeroMgr : MonoBehaviour
{
    public List<HeroClass> HiredheroData = new List<HeroClass>();
    public void _HiredHeroSave()
    {
        string jdata = JsonConvert.SerializeObject(HiredheroData);

        File.WriteAllText(Application.dataPath + "/" + "Resources" + "/" + "HiredHero.json", jdata);
    }

}
