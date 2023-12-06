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
    {   // �÷��̾ �̵������ϰ� �ϴ� �ڵ�
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.position += new Vector3(x, y) * Time.deltaTime * speed;

        // ��ü���������� ������ ������ ���Ͽ� �ٷ� ����ϴ�.
        Vector2 Ien = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(Ien.y, Ien.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(z) > 90f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���Ϳ� �÷��̾ �浹�� ������ ����
        if (collision.gameObject.tag == "Monster")
        {
           
            GameManagerJihu.I.GameOver();
        }
    }

}
