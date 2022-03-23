using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class HiredHeroMgr : MonoBehaviour
{
    public List<HeroClass> HiredheroData = new List<HeroClass>();
    // Start is called before the first frame update
    public void _HiredHeroSave()
    {
        string jdata = JsonConvert.SerializeObject(HiredheroData);

        File.WriteAllText(Application.dataPath + "/" + "Resources" + "/" + "HiredHero.json", jdata);
    }

}
