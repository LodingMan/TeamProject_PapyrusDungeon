using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class TownManager : MonoBehaviour
{
    //�÷��̾��� ������ �����ϴ� ��ũ��Ʈ. 
    //�ش� ��ũ��Ʈ���� ���� ����, ���, �� �ǹ��� ������Ȳ 
    public int Week = 0;
    public int Gold = 0;

    public Song.HeroManager heroManager; // inspectorâ�� HeroManager�־���

    public void NextWeek() // ���� ���� , ó�� ���� ���� ���� ������ �÷��̾��� ���൵�� �����ַ� �Ѿ.
    {                       // �ش� �Լ��� ���� �Ǿ����� HeroManager���� ������ ����ŭ Hero�� �������� �����ϴµ� 
        Week++;             // �����Ǵ� ���� HeroManager�� ����Ǿ��ִ� guildManager�� oneDayCreateHeroCount ������ �����Ѵ�. 
        //heroManager.RandomHeroCreate();
    } //�������ڸ� TownManager�� HeroManager���� ������ �����϶� ����ϰ�, HeroManager�� Guild���� ��� �����ؾ� �ϴ��� ���� �޾� �����Ѵ�. 
}
