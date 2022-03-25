using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class MonsterManager : MonoBehaviour
{
    public List<MonsterStatClass> MonsterStats = new List<MonsterStatClass>();
    public List<SkillClass> MonsterSkills = new List<SkillClass>();

    public int[] lv = new int[6];
    public int[] hp = new int[6];
    public int[] mp = new int[6];
    public int[] atk = new int[6];
    public int[] def = new int[6];
    public int[] cri = new int[6];
    public int[] acc = new int[6];
    public int[] agi = new int[6];


    public int NewbieCheck;
    public bool isNewbie = false;




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
                MonsterStats.Add(new MonsterStatClass("���", lv[0], hp[0], mp[0], atk[0], def[0], cri[0], acc[0], agi[0]));
                MonsterStats.Add(new MonsterStatClass("������", lv[1], hp[1], mp[1], atk[1], def[1], cri[1], acc[1], agi[1]));
                MonsterStats.Add(new MonsterStatClass("��Ʋ", lv[2], hp[2], mp[2], atk[2], def[2], cri[2], acc[2], agi[2]));
                MonsterStats.Add(new MonsterStatClass("���̷���", lv[3], hp[3], mp[3], atk[3], def[3], cri[3], acc[3], agi[3]));
                MonsterStats.Add(new MonsterStatClass("�̹�", lv[4], hp[4], mp[4], atk[4], def[4], cri[4], acc[4], agi[4]));
                MonsterStats.Add(new MonsterStatClass("��", lv[5], hp[5], mp[5], atk[5], def[5], cri[5], acc[5], agi[5]));

                MonsterSkills.Add(new SkillClass("��ų1", 1, 0, 1));  // ��ų�̸�, ������, �Ҹ�mp, ��Ÿ�� ��
                MonsterSkills.Add(new SkillClass("��ų2", 1, 0, 1));
                MonsterSkills.Add(new SkillClass("��ų3", 1, 0, 1));
                MonsterSkills.Add(new SkillClass("��ų4", 1, 0, 1));
                MonsterSkills.Add(new SkillClass("��ų5", 1, 0, 1));
                MonsterSkills.Add(new SkillClass("��ų6", 1, 0, 1));


                isNewbie = false;

                string jdata = JsonConvert.SerializeObject(MonsterStats);
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
                string format = System.Convert.ToBase64String(bytes);

                string jdata2 = JsonConvert.SerializeObject(MonsterSkills);
                byte[] bytes2 = System.Text.Encoding.UTF8.GetBytes(jdata2);
                string format2 = System.Convert.ToBase64String(bytes2);

                File.WriteAllText(Application.dataPath + "/" + "Resources" + "/" + "/Monster.json", format);
                File.WriteAllText(Application.dataPath + "/" + "Resources" + "/" + "/MonsterSkill.json", format2);

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
                string jdata = File.ReadAllText(Application.dataPath + "/" + "Resources" + "/" + "/Monster.json");
                byte[] bytes = System.Convert.FromBase64String(jdata);
                string reformat = System.Text.Encoding.UTF8.GetString(bytes);

                string jdata2 = File.ReadAllText(Application.dataPath + "/" + "Resources" + "/" + "/MonsterSkill.json");
                byte[] bytes2 = System.Convert.FromBase64String(jdata2);
                string reformat2 = System.Text.Encoding.UTF8.GetString(bytes2);

                MonsterStats = JsonConvert.DeserializeObject<List<MonsterStatClass>>(reformat);
                MonsterSkills = JsonConvert.DeserializeObject<List<SkillClass>>(reformat2);

            }

        }
        yield return new WaitForEndOfFrame();
    }

}
