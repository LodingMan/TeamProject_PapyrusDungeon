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
        heroSavingData.stat = gameObject.GetComponent<StatScript>().myStat; // ���� �ڽ��� �ɷ�ġ ����
        heroSavingData.skills = gameObject.GetComponent<SkillScript>().skills; //��ų ����
        //heroSavingData.equips = gameObject.GetComponent<EquipScript>().myEquip; //�������
    }

}
