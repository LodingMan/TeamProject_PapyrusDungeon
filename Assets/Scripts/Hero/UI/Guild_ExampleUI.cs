using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guild_ExampleUI : MonoBehaviour
{
    //����Ŭ�����̹Ƿ� ������ ������� ����.
    public Text ClassJob;

    public Song.HeroManager heroManager;
    public void TestFunc()
    {
        // �Լ� ���� UI���� �ؽ�Ʈ�� ���� �����Ǿ��ִ� ����� ������Ʈ�� �������� ����
        // CurrentHeroList�� ������Ʈ�� �̹� �����Ǿ��־�� �Ѵ�. 
        ClassJob.text = heroManager.CurrentHeroList[0].GetComponent<StatScript>().Job; //heroManager�� ���� ��������Ʈ��
                                                                                       //�ɹ� ������Ʈ�� ���ݿ��� ���� ���ڿ��� ������

    }

}
