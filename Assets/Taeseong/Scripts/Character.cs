using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    [SerializeField] private SpriteRenderer characterRenderer;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {   // 플레이어가 이동가능하게 하는 코드
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.position += new Vector3(x, y) * Time.deltaTime * speed;

        // 객체지향적이진 않지만 구현이 급하여 바로 썼습니다.
        Vector2 Ien = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(Ien.y, Ien.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(z) > 90f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 몬스터와 플레이어가 충돌시 게임이 멈춤
        if (collision.gameObject.tag == "Monster")
        {
           
            GameManagerJihu.I.GameOver();
        }
    }

}
