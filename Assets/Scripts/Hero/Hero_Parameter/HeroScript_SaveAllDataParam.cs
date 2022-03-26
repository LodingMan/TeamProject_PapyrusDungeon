using UnityEngine;

public class HeroScript_SaveAllDataParam : MonoBehaviour
{
    public HeroSavingData heroSavingData = new HeroSavingData(); //�� ������Ʈ�� json���� ������ ����ɶ� ����� ������

    void Start()
    {
        SaveMydata(); //������Ʈ�� �����ʰ� ���ÿ� �ڽ��� ���� �ʱ�ȭ,
                      //���� ���̺� , ������ �� ������Ʈ�� ������ �ʱ�ȭ �� �ʿ䰡 �ִٸ� ���
    }
    public void SaveMydata() 
    {
        #region // �Ķ���� ����. �󼼳����� ClassBundle.cs 66����
        //heroSavingData.Name = gameObject.GetComponent<StatScript>().Name;
        //heroSavingData.Index = gameObject.GetComponent<StatScript>().Index;
        //heroSavingData.Job = gameObject.GetComponent<StatScript>().Job;
        //heroSavingData.HP = gameObject.GetComponent<StatScript>().HP;
        //heroSavingData.MP = gameObject.GetComponent<StatScript>().MP;
        //heroSavingData.Atk = gameObject.GetComponent<StatScript>().Atk;
        //heroSavingData.Def = gameObject.GetComponent<StatScript>().Def;
        //heroSavingData.Cri = gameObject.GetComponent<StatScript>().Cri;
        //heroSavingData.Acc = gameObject.GetComponent<StatScript>().Acc;
        //heroSavingData.Agi = gameObject.GetComponent<StatScript>().Agi;
        //heroSavingData.Speed = gameObject.GetComponent<StatScript>().Speed;
        //endregion �ٷ� �Ʒ� �ѹ������� ��ü��.
        #endregion
        heroSavingData.stat = gameObject.GetComponent<StatScript>().myStat; // ���� �ڽ��� �ɷ�ġ ����
        heroSavingData.skills = gameObject.GetComponent<SkillScript>().skills; //��ų ����
        heroSavingData.equips = gameObject.GetComponent<EquipScript>().myEquip; //�������
    }

}
