using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class MonsterAdd : MonoBehaviour
{

    GameObject player;
    public float speed;
    public int maxHits = 2;
    private int currentHits = 0;



    // Start is called before the first frame update


    void Start()
    {
        player = GameObject.Find("Player"); //�÷��̾ �����ϴ� �ڵ�
    }

    // Update is called once per frame
    void Update()
    {

        //�÷��̾ ���� �̵��ϴ� �ڵ�
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���Ϳ� �Ѿ��� �浹������ �ڵ�
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
            currentHits++; // ���� ���� Ƚ���� 1������
            if (currentHits >= maxHits) // ���� ���� Ƚ���� �ִ� ���� Ƚ���� �Ǹ� ���� �ı�
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Skill")
        {
            currentHits++;
            if (currentHits >= maxHits)
            {
                Destroy(gameObject);
            }
        }
    }
}
