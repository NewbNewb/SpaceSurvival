using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerattack1 : MonoBehaviour
{
    public GameObject bullet;
   
    public Transform pos;
    public float cooltime;
    private float curtime;
  

    void Update()
    {
        Vector2 Ien = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(Ien.y, Ien.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);

        if (curtime <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Instantiate(bullet, pos.position, transform.rotation);
            }
            curtime = cooltime; 
        }
        curtime -= Time.deltaTime;
    }
}
