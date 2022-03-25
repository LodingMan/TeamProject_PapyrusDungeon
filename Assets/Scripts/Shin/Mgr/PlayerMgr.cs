using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class PlayerMgr : MonoBehaviour
{
    public PlayerClass playerClass;
    public int gold;
    public int week;
    public int jewel;

    
    public void _save()
    {
        playerClass = new PlayerClass(gold, week, jewel);
        string jdata = JsonConvert.SerializeObject(playerClass);

        File.WriteAllText(Application.dataPath + "/" + "Resources" + "/" + "Player.json", jdata);
    }

    public void _load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/" + "Resources" + "/" + "Player.json");
        if (jdata == null)
        {
            Debug.Log("불러올 데이터가 없습니다... Player");
            return;
        }
        playerClass = JsonConvert.DeserializeObject<PlayerClass>(jdata);
        //Debug.Log(jdata);

        gold = playerClass.gold;
        week = playerClass.week;
        jewel = playerClass.jewel;
    }
}
