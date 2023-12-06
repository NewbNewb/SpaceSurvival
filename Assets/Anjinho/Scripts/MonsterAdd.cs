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
        player = GameObject.Find("Player"); //플레이어를 지정하는 코드
    }

    // Update is called once per frame
    void Update()
    {

        //플레이어를 향해 이동하는 코드
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 몬스터와 총알이 충돌했을때 코드
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
            currentHits++; // 현재 맞은 횟수가 1씩증가
            if (currentHits >= maxHits) // 현재 맞은 횟수가 최대 맞은 횟수가 되면 몬스터 파괴
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
