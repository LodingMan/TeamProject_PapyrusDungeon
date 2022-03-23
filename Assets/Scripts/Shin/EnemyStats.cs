using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class EnemyStats : MonoBehaviour
{
    List<EnemyClass> enemyData = new List<EnemyClass>();

    public string[] enemyName = new string[3];
    public int[] lv = new int[3];
    public int[] hp = new int[3];
    public int[] mp = new int[3];
    public int[] atk = new int[3];
    public int[] def = new int[3];
    public int[] cri = new int[3];
    public int[] acc = new int[3];
    public int[] agi = new int[3];
    
    void Start()
    {
        enemyData.Add(new EnemyClass(enemyName[0], lv[0], hp[0], mp[0], atk[0], def[0], cri[0], acc[0], agi[0]));
        enemyData.Add(new EnemyClass(enemyName[1], lv[1], hp[1], mp[1], atk[1], def[1], cri[1], acc[1], agi[1]));
        enemyData.Add(new EnemyClass(enemyName[2], lv[2], hp[2], mp[2], atk[2], def[2], cri[2], acc[2], agi[2]));
    }

    public void _save()
    {
        string jdata = JsonConvert.SerializeObject(enemyData);

        File.WriteAllText(Application.dataPath + "/" + "Resources" + "/" + "Enemy.json", jdata);
        //Debug.Log("저장 완료");
    }

    public void _load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/" + "Resources" + "/" + "Enemy.json");
        
        enemyData = JsonConvert.DeserializeObject<List<EnemyClass>>(jdata);
        //Debug.Log(reformat);
        Debug.Log(jdata);
    }
}
