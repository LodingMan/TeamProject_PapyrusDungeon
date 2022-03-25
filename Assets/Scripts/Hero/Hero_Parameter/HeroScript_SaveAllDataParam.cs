using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript_SaveAllDataParam : MonoBehaviour
{
    public HeroSavingData heroSavingData = new HeroSavingData(); //�� ������Ʈ�� json���� ������ ����ɶ� ����� ������

    void Start()
    {
        SaveMydata();
    }
    public void SaveMydata()
    {
        // ���� ���� : �����͸� �����Ҷ����� ���� ������ ������Ʈ ����Ʈ�� ��������� �ѹ��� �����ϱ����ؼ� ������ �Լ��� ����
        #region // ���� �ڽ��� �ɷ�ġ ����
        heroSavingData.Name = gameObject.GetComponent<StatScript>().Name;
        heroSavingData.Index = gameObject.GetComponent<StatScript>().Index;
        heroSavingData.Job = gameObject.GetComponent<StatScript>().Job;
        heroSavingData.HP = gameObject.GetComponent<StatScript>().HP;
        heroSavingData.MP = gameObject.GetComponent<StatScript>().MP;
        heroSavingData.Atk = gameObject.GetComponent<StatScript>().Atk;
        heroSavingData.Def = gameObject.GetComponent<StatScript>().Def;
        heroSavingData.Cri = gameObject.GetComponent<StatScript>().Cri;
        heroSavingData.Acc = gameObject.GetComponent<StatScript>().Acc;
        heroSavingData.Agi = gameObject.GetComponent<StatScript>().Agi;
        heroSavingData.skills = gameObject.GetComponent<SkillScript>().skills;
        #endregion
    }

}
