using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class TotalHeroJsonSave : MonoBehaviour
{
    public List<HeroClass> heroData = new List<HeroClass>();
    public int loof;
    public int[] index;
    public string[] heroname;
    public string[] job;
    public string[] equipname;
    public Stats stats;
    public Equip equip;
    public Skill[] ski;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < loof; i++)
        {
            stats = new Stats(heroname[i], job[i], 1, 1, 1, 1, 1, 1, 1, 1);
            equip = new Equip(equipname[i], 1, 1, 1, 1, 1, 1, 1, 1);
            ski = new Skill[5];
            ski[0] = new Skill("skill01", 1, 1, 1, 1, 1, 1, 1, 1, 1);
            ski[1] = new Skill("skill01", 1, 1, 1, 1, 1, 1, 1, 1, 1);
            ski[2] = new Skill("skill01", 1, 1, 1, 1, 1, 1, 1, 1, 1);
            ski[3] = new Skill("skill01", 1, 1, 1, 1, 1, 1, 1, 1, 1);
            ski[4] = new Skill("skill01", 1, 1, 1, 1, 1, 1, 1, 1, 1);
            heroData.Add(new HeroClass(index[i], stats, equip, ski));
        }
        
        string jdata = JsonConvert.SerializeObject(heroData);
        File.WriteAllText(Application.dataPath + "/" + "Resources" + "/" + "TotalHero.json", jdata);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
