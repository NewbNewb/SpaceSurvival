using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        // �Ѿ��� ���� ������ �������� �̻� �ö󰡸� �������� �ϴ� �ڵ�
        transform.position += new Vector3(0, 0.05f, 0);
        if(transform.position.y > 9.0f)
        {
            Destroy(gameObject);
        }
        
    }   
}
