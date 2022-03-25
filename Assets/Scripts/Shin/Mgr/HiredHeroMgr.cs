using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class HiredHeroMgr : MonoBehaviour
{
    public List<HeroClass> HiredheroData = new List<HeroClass>();

    private void Awake()
    {
        if (HiredheroData.Count != 0) // 데이터가 있으면 Load해서 먼저 받아옴.
        {
            _HiredHeroLoad();
            // 데이터에 정보가 있으면 Count만큼 프리팹 오브젝트를 생성하게 할 것.
        }
        
    }

    public void _HiredHeroSave()
    {
        string jdata = JsonConvert.SerializeObject(HiredheroData);

        File.WriteAllText(Application.dataPath + "/" + "Resources" + "/" + "HiredHero.json", jdata);
    }

    public void _HiredHeroLoad()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/" + "Resources" + "/" + "HiredHero.json");
        HiredheroData = JsonConvert.DeserializeObject<List<HeroClass>>(jdata);
    }
}
