using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public GameObject[] skillPrefabs;  //��ų ��������� ������ ����
    List<GameObject>[] skill;  // ��ų�� ����ϴ� ����Ʈ

    private void Awake()
    {
        skill = new List<GameObject>[skillPrefabs.Length];  //���� �ʱ�ȭ

        for (int index = 0; index < skill.Length; index++)  //����Ʈ �ʱ�ȭ
        {
            skill[index] = new List<GameObject>();
        }

    }

    public GameObject Get(int index)  //������Ʈ �޾ƿ���
    {
        GameObject select = null;

        foreach (GameObject skillList in skill[index])  //������ ��ų�� ������Ʈ ����
        {
            if (!skillList.activeSelf)   //select ������ �Ҵ�
            {
                select = skillList;
                select.SetActive(true);
                break;
            }
        }
        if (!select)   //�� ã���� ���Ӱ� ���� �� select ������ �Ҵ�
        {
            select = Instantiate(skillPrefabs[index], transform);
            skill[index].Add(select);
        }
        return select;
    }


}
