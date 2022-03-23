using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class HeroManager : MonoBehaviour
{


    public bool isNewbie = true;
    public int NewbieCheck = 0;

    public List<StatClass> heroData = new List<StatClass>();
    public List<SkillClass> skillData = new List<SkillClass>();

    public List<GameObject> HasHeroList = new List<GameObject>();

    public List<string> weaponList = new List<string>();
    public List<string> armorList = new List<string>();

    

    public int[] lv = new int[6];
    public int[] hp = new int[6];
    public int[] mp = new int[6];
    public int[] atk = new int[6];
    public int[] def = new int[6];
    public int[] cri = new int[6];
    public int[] acc = new int[6];
    public int[] agi = new int[6];
    public string[] weapon = new string[6];
    public string[] armor = new string[6];

    public bool isLoaded = false;




    void Awake()
    {
        StartCoroutine(NewbieCheckDelay());

    }



    public IEnumerator NewbieCheckDelay()
    {
        NewbieCheck = PlayerPrefs.GetInt("isNewbie");
        yield return new WaitForSeconds(1f);
        if (NewbieCheck == 0)
        {
            isNewbie = true;

            if (isNewbie) //처음 시작 시 Json 최초 생성
            {
                heroData.Add(new StatClass("야만전사", lv[0], hp[0], mp[0], atk[0], def[0], cri[0], acc[0], agi[0], weapon[0], armor[0], 0));
                heroData.Add(new StatClass("궁수", lv[1], hp[1], mp[1], atk[1], def[1], cri[1], acc[1], agi[1], weapon[1], armor[1], 1));
                heroData.Add(new StatClass("기사", lv[2], hp[2], mp[2], atk[2], def[2], cri[2], acc[2], agi[2], weapon[2], armor[2], 2));
                heroData.Add(new StatClass("중보병", lv[3], hp[3], mp[3], atk[3], def[3], cri[3], acc[3], agi[3], weapon[3], armor[3], 3));
                heroData.Add(new StatClass("마법사", lv[4], hp[4], mp[4], atk[4], def[4], cri[4], acc[4], agi[4], weapon[4], armor[4], 4));
                heroData.Add(new StatClass("짐꾼", lv[5], hp[5], mp[5], atk[5], def[5], cri[5], acc[5], agi[5], weapon[5], armor[5], 5));

                //=============================================야만전사
                skillData.Add(new SkillClass("강타", 1, 1, 1));
                skillData.Add(new SkillClass("난타", 1, 1, 1));
                skillData.Add(new SkillClass("도약강타", 1, 1, 1));
                skillData.Add(new SkillClass("분노", 1, 1, 1));
                skillData.Add(new SkillClass("최후의 일격", 1, 1, 1));
                //=============================================궁수
                skillData.Add(new SkillClass("화살쏘기", 1, 1, 1));
                skillData.Add(new SkillClass("독화살", 1, 1, 1));
                skillData.Add(new SkillClass("뒤구르기", 1, 1, 1));
                skillData.Add(new SkillClass("헤드샷", 1, 1, 1));
                skillData.Add(new SkillClass("애로우해일", 1, 1, 1));
                //=============================================기사
                skillData.Add(new SkillClass("대검 휘두르기", 1, 1, 1));
                skillData.Add(new SkillClass("패링", 1, 1, 1));
                skillData.Add(new SkillClass("가다듬기", 1, 1, 1));
                skillData.Add(new SkillClass("선두지휘", 1, 1, 1));
                skillData.Add(new SkillClass("심판", 1, 1, 1));
                //=============================================중보병
                skillData.Add(new SkillClass("방패찍기", 1, 1, 1));
                skillData.Add(new SkillClass("방패올리기", 1, 1, 1));
                skillData.Add(new SkillClass("방패밀치기", 1, 1, 1));
                skillData.Add(new SkillClass("도발", 1, 1, 1));
                skillData.Add(new SkillClass("고양", 1, 1, 1));
                //=============================================마법사
                skillData.Add(new SkillClass("매직애로우", 1, 1, 1));
                skillData.Add(new SkillClass("파이어볼", 1, 1, 1));
                skillData.Add(new SkillClass("블리자드", 1, 1, 1));
                skillData.Add(new SkillClass("정신집중", 1, 1, 1));
                skillData.Add(new SkillClass("블랙홀", 1, 1, 1));
                //=============================================짐꾼
                skillData.Add(new SkillClass("포션던지기", 1, 1, 1));
                skillData.Add(new SkillClass("연막뿌리기", 1, 1, 1));
                skillData.Add(new SkillClass("포츈코인", 1, 1, 1));
                skillData.Add(new SkillClass("프랜드실드", 1, 1, 1));
                skillData.Add(new SkillClass("도망가기", 1, 1, 1));

                isNewbie = false;

                string jdata = JsonConvert.SerializeObject(heroData);
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
                string format = System.Convert.ToBase64String(bytes);

                string jdata2 = JsonConvert.SerializeObject(skillData);
                byte[] bytes2 = System.Text.Encoding.UTF8.GetBytes(jdata2);
                string format2 = System.Convert.ToBase64String(bytes2);

                File.WriteAllText(Application.dataPath + "/Hero.json", format);
                File.WriteAllText(Application.dataPath + "/Skill.json", format2);


                PlayerPrefs.SetInt("isNewbie", 1);
                NewbieCheck = PlayerPrefs.GetInt("isNewbie");
                PlayerPrefs.Save();
            }

        }
        else if (NewbieCheck == 1)
        {
            isNewbie = false;
            if (!isNewbie)
            {
                string jdata = File.ReadAllText(Application.dataPath + "/Hero.json");
                byte[] bytes = System.Convert.FromBase64String(jdata);
                string reformat = System.Text.Encoding.UTF8.GetString(bytes);

                string jdata2 = File.ReadAllText(Application.dataPath + "/Skill.json");
                byte[] bytes2 = System.Convert.FromBase64String(jdata2);
                string reformat2 = System.Text.Encoding.UTF8.GetString(bytes2);

                heroData = JsonConvert.DeserializeObject<List<StatClass>>(reformat);

                skillData = JsonConvert.DeserializeObject<List<SkillClass>>(reformat2);

                isLoaded = true;

}

        }
        yield return new WaitForEndOfFrame();
    }

    public void _save()
    {
        heroData.Add(new StatClass("야만전사", lv[0], hp[0], mp[0], atk[0], def[0], cri[0], acc[0], agi[0], weapon[0], armor[0], 0));
        heroData.Add(new StatClass("궁수", lv[1], hp[1], mp[1], atk[1], def[1], cri[1], acc[1], agi[1], weapon[1], armor[1], 1));
        heroData.Add(new StatClass("기사", lv[2], hp[2], mp[2], atk[2], def[2], cri[2], acc[2], agi[2], weapon[2], armor[2], 2));
        heroData.Add(new StatClass("중보병", lv[3], hp[3], mp[3], atk[3], def[3], cri[3], acc[3], agi[3], weapon[3], armor[3], 3));
        heroData.Add(new StatClass("마법사", lv[4], hp[4], mp[4], atk[4], def[4], cri[4], acc[4], agi[4], weapon[4], armor[4], 4));
        heroData.Add(new StatClass("짐꾼", lv[5], hp[5], mp[5], atk[5], def[5], cri[5], acc[5], agi[5], weapon[5], armor[5], 5));

        //=============================================야만전사
        skillData.Add(new SkillClass("강타", 1, 1, 1));  // 스킬이름, 데미지, 소모mp, 쿨타임 순
        skillData.Add(new SkillClass("난타", 1, 1, 1));
        skillData.Add(new SkillClass("도약강타", 1, 1, 1));
        skillData.Add(new SkillClass("분노", 1, 1, 1));
        skillData.Add(new SkillClass("최후의 일격", 1, 1, 1));
        //=============================================궁수
        skillData.Add(new SkillClass("화살쏘기", 1, 1, 1));
        skillData.Add(new SkillClass("독화살", 1, 1, 1));
        skillData.Add(new SkillClass("뒤구르기", 1, 1, 1));
        skillData.Add(new SkillClass("헤드샷", 1, 1, 1));
        skillData.Add(new SkillClass("애로우해일", 1, 1, 1));
        //=============================================기사
        skillData.Add(new SkillClass("대검 휘두르기", 1, 1, 1));
        skillData.Add(new SkillClass("패링", 1, 1, 1));
        skillData.Add(new SkillClass("가다듬기", 1, 1, 1));
        skillData.Add(new SkillClass("선두지휘", 1, 1, 1));
        skillData.Add(new SkillClass("심판", 1, 1, 1));
        //=============================================중보병
        skillData.Add(new SkillClass("방패찍기", 1, 1, 1));
        skillData.Add(new SkillClass("방패올리기", 1, 1, 1));
        skillData.Add(new SkillClass("방패밀치기", 1, 1, 1));
        skillData.Add(new SkillClass("도발", 1, 1, 1));
        skillData.Add(new SkillClass("고양", 1, 1, 1));
        //=============================================마법사
        skillData.Add(new SkillClass("매직애로우", 1, 1, 1));
        skillData.Add(new SkillClass("파이어볼", 1, 1, 1));
        skillData.Add(new SkillClass("블리자드", 1, 1, 1));
        skillData.Add(new SkillClass("정신집중", 1, 1, 1));
        skillData.Add(new SkillClass("블랙홀", 1, 1, 1));
        //=============================================짐꾼
        skillData.Add(new SkillClass("포션던지기", 1, 1, 1));
        skillData.Add(new SkillClass("연막뿌리기", 1, 1, 1));
        skillData.Add(new SkillClass("포츈코인", 1, 1, 1));
        skillData.Add(new SkillClass("프랜드실드", 1, 1, 1));
        skillData.Add(new SkillClass("도망가기", 1, 1, 1));

        isNewbie = false;

        string jdata = JsonConvert.SerializeObject(heroData);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
        string format = System.Convert.ToBase64String(bytes);

        string jdata2 = JsonConvert.SerializeObject(skillData);
        byte[] bytes2 = System.Text.Encoding.UTF8.GetBytes(jdata2);
        string format2 = System.Convert.ToBase64String(bytes2);

        File.WriteAllText(Application.dataPath + "/Hero.json", format);
        File.WriteAllText(Application.dataPath + "/Skill.json", format2);
    }

    public void _load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/Hero.json");
        byte[] bytes = System.Convert.FromBase64String(jdata);
        string reformat = System.Text.Encoding.UTF8.GetString(bytes);

        string jdata2 = File.ReadAllText(Application.dataPath + "/Skill.json");
        byte[] bytes2 = System.Convert.FromBase64String(jdata2);
        string reformat2 = System.Text.Encoding.UTF8.GetString(bytes2);

        heroData = JsonConvert.DeserializeObject<List<StatClass>>(reformat);

        skillData = JsonConvert.DeserializeObject<List<SkillClass>>(reformat2);

        isLoaded = true;

    }

    public void LoadHeroParty()
    {
        GameObject hero1 = Instantiate(HasHeroList[0]);
        GameObject hero2 = Instantiate(HasHeroList[1]);
        GameObject hero3 = Instantiate(HasHeroList[2]);
    }
}
