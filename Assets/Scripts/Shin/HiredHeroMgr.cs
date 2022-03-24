using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class HiredHeroMgr : MonoBehaviour  //현재 고용한 영웅 리스트를 관리. 
{
    public List<HeroClass> HiredheroData = new List<HeroClass>(); //이 리스트의 값으로 영웅을 생성하고 관리한다. 
    // Start is called before the first frame update
    public void _HiredHeroSave()
    {
        string jdata = JsonConvert.SerializeObject(HiredheroData);

        File.WriteAllText(Application.dataPath + "/" + "Resources" + "/" + "HiredHero.json", jdata);
    }

}
