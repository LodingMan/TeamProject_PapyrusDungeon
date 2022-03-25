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
        if (HiredheroData.Count != 0) // �����Ͱ� ������ Load�ؼ� ���� �޾ƿ�.
        {
            _HiredHeroLoad();
            // �����Ϳ� ������ ������ Count��ŭ ������ ������Ʈ�� �����ϰ� �� ��.
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
