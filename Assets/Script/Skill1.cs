using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : MonoBehaviour
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
                transform.Rotate(Vector3.back * skillSpeed * Time.deltaTime); //회전시키기
                break;
            default:
                break;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
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
                skillSpeed = -150;   //시계방향
                Collorate();
                break;
            default:
                break;

        }
    }

    void Collorate()  // 무기(스킬) 배치 함수
    {
        for (int index = 0; index < skillCount; index++)  //skillCount 만큼 SkillManager에서 가져오기
        {
            Transform weapon;

            if (index < transform.childCount)   //가지고 있는 것 먼저 활용
            {
                weapon = transform.GetChild(index);
            }
            else   //모자르면 가져오기
            {
                weapon = GameManagerJinho.instance.skills.Get(skillPrefab).transform;
                weapon.parent = transform;
            }

            weapon.localPosition = Vector3.zero;  //플레이어 위치로 고정
            weapon.localRotation = Quaternion.identity;  //회전값 초기화

            Vector3 rotVec = Vector3.back * 360 * index / skillCount;
            weapon.Rotate(rotVec);
            weapon.Translate(weapon.up * 1.7f, Space.World);
        }
    }


}
