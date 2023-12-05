using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public int skillId;
    public int skillPrefab;
    public int skillCount;
    public float skillDamage;
    public float skillSpeed;

    // Start is called before the first frame update
    void Start()
    {
        CheckSkillId();
    }

    // Update is called once per frame
    void Update()
    {
        switch (skillId)
        {
            case 0:
                transform.Rotate(Vector3.back * skillSpeed * Time.deltaTime); //ȸ����Ű��
                break;
            default:
                break;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            LevelUp(10, 1);
            Debug.Log("Level Up!!!");
        }

    }

    public void LevelUp(float damage, int count)
    {
        this.skillCount += count;
        this.skillDamage += damage;
        

        if (skillId == 0) Collorate();
    }

    public void CheckSkillId()
    {
        switch (skillId)
        {
            case 0:
                skillSpeed = -150;   //�ð����
                Collorate();
                break;
            default:
                break;

        }
    }

    void Collorate()  // ����(��ų) ��ġ �Լ�
    {
        for (int index = 0; index < skillCount; index++)  //skillCount ��ŭ SkillManager���� ��������
        {
            Transform weapon;

            if (index < transform.childCount)   //������ �ִ� �� ���� Ȱ��
            {
                weapon = transform.GetChild(index);
            }
            else   //���ڸ��� ��������
            {
                weapon = GameManagerJinho.instance.skills.Get(skillPrefab).transform;
                weapon.parent = transform;
            }

            weapon.localPosition = Vector3.zero;  //�÷��̾� ��ġ�� ����
            weapon.localRotation = Quaternion.identity;  //ȸ���� �ʱ�ȭ

            Vector3 rotVec = Vector3.back * 360 * index / skillCount;
            weapon.Rotate(rotVec);
            weapon.Translate(weapon.up * 1.7f, Space.World);
        }
    }


}
