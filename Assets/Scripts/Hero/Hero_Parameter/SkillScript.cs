using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillScript : MonoBehaviour
{
    public skill[] skills = new skill[5];// �ش� �÷��̾ ������ �ִ� ��ų ����Ʈ.
                                         // �ش� ������Ʈ�� �������� �ش� �迭���� ������ ��ų�� ������ ���� �ȴ�. 
                                         // �ش� ������� ��ų�� ������ �ø��ٸ� ���⿡ �����ؼ� ������ �÷��ָ� �ȴ�.
                                         // ��밡���� ��ų / ��� �Ұ����� ��ų�� ���⼭ �����⸦ ���. ex) int[] onSkillIndex  = new int{2, 3 ,5}
    public int[] SkillIndex = new int[3];

    public skill[] mySkills = new skill[3];
    private void Start()
    {
        for(int i = 0; i<3; i++)
        {
            SkillIndex[i] = Random.Range(0, 5);
            mySkills[i] = skills[SkillIndex[i]];
            for(int j = i; j > 0; j--)
            {
                if(SkillIndex[i] == SkillIndex[j-1])
                {
                    i--;
                }
            }
        }

    }




}
