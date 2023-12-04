using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�¼��� ����
    public GameObject Alien1;
    public Transform Player;

    //���Ĵ� ����
    public Time timeTxt;
    float time;

    void Start()
    {
        //�¼���
        InvokeRepeating("MakeAlien1", 0.0f, 2f);


    }

    // Update is called once per frame
    void Update()
    {
        //���Ĵ�
        time += Time.deltaTime;
        // timeTxt.text = time.ToString();


    }

    // �¼���
    void MakeAlien1()
    {
        float spawnAngle = Random.Range(0.0f, 360.0f);
        float spawnRadius = Random.Range(10.0f, 11.0f);

        float spawnX = Player.position.x + spawnRadius * Mathf.Cos(spawnAngle * Mathf.Deg2Rad);
        float spawnY = Player.position.y + spawnRadius * Mathf.Sin(spawnAngle * Mathf.Deg2Rad);

        Instantiate(Alien1, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
    }
}
