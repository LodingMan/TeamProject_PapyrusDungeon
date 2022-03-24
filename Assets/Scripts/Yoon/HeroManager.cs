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

            if (isNewbie) //ó�� ���� �� Json ���� ����
            {
                heroData.Add(new StatClass("�߸�����", lv[0], hp[0], mp[0], atk[0], def[0], cri[0], acc[0], agi[0], weapon[0], armor[0], 0));
                heroData.Add(new StatClass("�ü�", lv[1], hp[1], mp[1], atk[1], def[1], cri[1], acc[1], agi[1], weapon[1], armor[1], 1));
                heroData.Add(new StatClass("���", lv[2], hp[2], mp[2], atk[2], def[2], cri[2], acc[2], agi[2], weapon[2], armor[2], 2));
                heroData.Add(new StatClass("�ߺ���", lv[3], hp[3], mp[3], atk[3], def[3], cri[3], acc[3], agi[3], weapon[3], armor[3], 3));
                heroData.Add(new StatClass("������", lv[4], hp[4], mp[4], atk[4], def[4], cri[4], acc[4], agi[4], weapon[4], armor[4], 4));
                heroData.Add(new StatClass("����", lv[5], hp[5], mp[5], atk[5], def[5], cri[5], acc[5], agi[5], weapon[5], armor[5], 5));

                //=============================================�߸�����
                skillData.Add(new SkillClass("��Ÿ", 1, 1, 1));
                skillData.Add(new SkillClass("��Ÿ", 1, 1, 1));
                skillData.Add(new SkillClass("���భŸ", 1, 1, 1));
                skillData.Add(new SkillClass("�г�", 1, 1, 1));
                skillData.Add(new SkillClass("������ �ϰ�", 1, 1, 1));
                //=============================================�ü�
                skillData.Add(new SkillClass("ȭ����", 1, 1, 1));
                skillData.Add(new SkillClass("��ȭ��", 1, 1, 1));
                skillData.Add(new SkillClass("�ڱ�����", 1, 1, 1));
                skillData.Add(new SkillClass("��弦", 1, 1, 1));
                skillData.Add(new SkillClass("�ַο�����", 1, 1, 1));
                //=============================================���
                skillData.Add(new SkillClass("��� �ֵθ���", 1, 1, 1));
                skillData.Add(new SkillClass("�и�", 1, 1, 1));
                skillData.Add(new SkillClass("���ٵ��", 1, 1, 1));
                skillData.Add(new SkillClass("��������", 1, 1, 1));
                skillData.Add(new SkillClass("����", 1, 1, 1));
                //=============================================�ߺ���
                skillData.Add(new SkillClass("�������", 1, 1, 1));
                skillData.Add(new SkillClass("���пø���", 1, 1, 1));
                skillData.Add(new SkillClass("���й�ġ��", 1, 1, 1));
                skillData.Add(new SkillClass("����", 1, 1, 1));
                skillData.Add(new SkillClass("���", 1, 1, 1));
                //=============================================������
                skillData.Add(new SkillClass("�����ַο�", 1, 1, 1));
                skillData.Add(new SkillClass("���̾", 1, 1, 1));
                skillData.Add(new SkillClass("���ڵ�", 1, 1, 1));
                skillData.Add(new SkillClass("��������", 1, 1, 1));
                skillData.Add(new SkillClass("��Ȧ", 1, 1, 1));
                //=============================================����
                skillData.Add(new SkillClass("���Ǵ�����", 1, 1, 1));
                skillData.Add(new SkillClass("�����Ѹ���", 1, 1, 1));
                skillData.Add(new SkillClass("��������", 1, 1, 1));
                skillData.Add(new SkillClass("������ǵ�", 1, 1, 1));
                skillData.Add(new SkillClass("��������", 1, 1, 1));

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
        heroData.Add(new StatClass("�߸�����", lv[0], hp[0], mp[0], atk[0], def[0], cri[0], acc[0], agi[0], weapon[0], armor[0], 0));
        heroData.Add(new StatClass("�ü�", lv[1], hp[1], mp[1], atk[1], def[1], cri[1], acc[1], agi[1], weapon[1], armor[1], 1));
        heroData.Add(new StatClass("���", lv[2], hp[2], mp[2], atk[2], def[2], cri[2], acc[2], agi[2], weapon[2], armor[2], 2));
        heroData.Add(new StatClass("�ߺ���", lv[3], hp[3], mp[3], atk[3], def[3], cri[3], acc[3], agi[3], weapon[3], armor[3], 3));
        heroData.Add(new StatClass("������", lv[4], hp[4], mp[4], atk[4], def[4], cri[4], acc[4], agi[4], weapon[4], armor[4], 4));
        heroData.Add(new StatClass("����", lv[5], hp[5], mp[5], atk[5], def[5], cri[5], acc[5], agi[5], weapon[5], armor[5], 5));

        //=============================================�߸�����
        skillData.Add(new SkillClass("��Ÿ", 1, 1, 1));  // ��ų�̸�, ������, �Ҹ�mp, ��Ÿ�� ��
        skillData.Add(new SkillClass("��Ÿ", 1, 1, 1));
        skillData.Add(new SkillClass("���భŸ", 1, 1, 1));
        skillData.Add(new SkillClass("�г�", 1, 1, 1));
        skillData.Add(new SkillClass("������ �ϰ�", 1, 1, 1));
        //=============================================�ü�
        skillData.Add(new SkillClass("ȭ����", 1, 1, 1));
        skillData.Add(new SkillClass("��ȭ��", 1, 1, 1));
        skillData.Add(new SkillClass("�ڱ�����", 1, 1, 1));
        skillData.Add(new SkillClass("��弦", 1, 1, 1));
        skillData.Add(new SkillClass("�ַο�����", 1, 1, 1));
        //=============================================���
        skillData.Add(new SkillClass("��� �ֵθ���", 1, 1, 1));
        skillData.Add(new SkillClass("�и�", 1, 1, 1));
        skillData.Add(new SkillClass("���ٵ��", 1, 1, 1));
        skillData.Add(new SkillClass("��������", 1, 1, 1));
        skillData.Add(new SkillClass("����", 1, 1, 1));
        //=============================================�ߺ���
        skillData.Add(new SkillClass("�������", 1, 1, 1));
        skillData.Add(new SkillClass("���пø���", 1, 1, 1));
        skillData.Add(new SkillClass("���й�ġ��", 1, 1, 1));
        skillData.Add(new SkillClass("����", 1, 1, 1));
        skillData.Add(new SkillClass("���", 1, 1, 1));
        //=============================================������
        skillData.Add(new SkillClass("�����ַο�", 1, 1, 1));
        skillData.Add(new SkillClass("���̾", 1, 1, 1));
        skillData.Add(new SkillClass("���ڵ�", 1, 1, 1));
        skillData.Add(new SkillClass("��������", 1, 1, 1));
        skillData.Add(new SkillClass("��Ȧ", 1, 1, 1));
        //=============================================����
        skillData.Add(new SkillClass("���Ǵ�����", 1, 1, 1));
        skillData.Add(new SkillClass("�����Ѹ���", 1, 1, 1));
        skillData.Add(new SkillClass("��������", 1, 1, 1));
        skillData.Add(new SkillClass("������ǵ�", 1, 1, 1));
        skillData.Add(new SkillClass("��������", 1, 1, 1));

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
