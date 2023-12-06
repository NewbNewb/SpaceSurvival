using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;


public class gameManagerTaeseong : MonoBehaviour
{
    public GameObject Alien1;
    public GameObject Alien2;
    public GameObject Alien3;
    public GameObject Alien4;
    public GameObject Player;
    //public GameObject Bullet;
    public TMP_Text timeTxt;
    private float time;
    private bool isRunning = true;
    private bool hasInvokedMakeAlien2 = false;
    private bool hasInvokedMakeAlien3 = false;
    private bool hasInvokedMakeAlien4 = false;

    public static gameManagerTaeseong I;
    
    void Awake()
    {
        I = this;
    }


    void Start()
    {
        // �Ѿ˰� ���� ���� �ڵ�(�ҷ������Լ�, ��ġ(?), �󸶸��� �����Ǵ��� �ð�)
        InvokeRepeating("MakeAlien1", 0.0f, 2f);
        //InvokeRepeating("MakeBullet", 0.0f, 0.2f);
    }

    void Update()
    {
        if (isRunning) // ���ӽ��� �߿� �ð��� ����
        {
            // Ÿ�̸� ǥ��
            time += Time.deltaTime;
            int hour = (int)time / 3600;
            int min = (int)time % 3600 / 60;
            int sec = (int)time % 3600 % 60;
            timeTxt.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, min, sec);
        }
        
        // �ð��� ������ ���� ���͵� ���� �����ǰ� �ϴ� �ڵ�
        if (time >= 10f && !hasInvokedMakeAlien2)
        {
            hasInvokedMakeAlien2 = true;
            InvokeRepeating("MakeAlien2", 0.0f, 2f);
        }

        if (time >= 20f && !hasInvokedMakeAlien3)
        {
            hasInvokedMakeAlien3 = true;
            InvokeRepeating("MakeAlien3", 0.0f, 3f);
        }

        if (time >= 30f && !hasInvokedMakeAlien4)
        {
            hasInvokedMakeAlien4 = true;
            InvokeRepeating("MakeAlien4", 0.0f, 2f);
        }
    }
    void MakeAlien1()
    {

            // �÷��̾� �ֺ����� ������ ���� �����ϰ� �ϴ� �ڵ�
            float spawnAngle = Random.Range(0.0f, 360.0f);
            float spawnRadius = Random.Range(10.0f, 11.0f);

            float spawnX = Player.transform.position.x + spawnRadius * Mathf.Cos(spawnAngle * Mathf.Deg2Rad);
            float spawnY = Player.transform.position.y + spawnRadius * Mathf.Sin(spawnAngle * Mathf.Deg2Rad);

            Instantiate(Alien1, new Vector3(spawnX, spawnY, 0), Quaternion.identity);

        
    }

    void MakeAlien2()
    {

        // �÷��̾� �ֺ����� ������ ���� �����ϰ� �ϴ� �ڵ�
        float spawnAngle = Random.Range(0.0f, 360.0f);
        float spawnRadius = Random.Range(10.0f, 11.0f);

        float spawnX = Player.transform.position.x + spawnRadius * Mathf.Cos(spawnAngle * Mathf.Deg2Rad);
        float spawnY = Player.transform.position.y + spawnRadius * Mathf.Sin(spawnAngle * Mathf.Deg2Rad);

        Instantiate(Alien2, new Vector3(spawnX, spawnY, 0), Quaternion.identity);


    }

    void MakeAlien3()
    {

        // �÷��̾� �ֺ����� ������ ���� �����ϰ� �ϴ� �ڵ�
        float spawnAngle = Random.Range(0.0f, 360.0f);
        float spawnRadius = Random.Range(10.0f, 11.0f);

        float spawnX = Player.transform.position.x + spawnRadius * Mathf.Cos(spawnAngle * Mathf.Deg2Rad);
        float spawnY = Player.transform.position.y + spawnRadius * Mathf.Sin(spawnAngle * Mathf.Deg2Rad);

        Instantiate(Alien3, new Vector3(spawnX, spawnY, 0), Quaternion.identity);


    }

    void MakeAlien4()
    {

        // �÷��̾� �ֺ����� ������ ���� �����ϰ� �ϴ� �ڵ�
        float spawnAngle = Random.Range(0.0f, 360.0f);
        float spawnRadius = Random.Range(10.0f, 11.0f);

        float spawnX = Player.transform.position.x + spawnRadius * Mathf.Cos(spawnAngle * Mathf.Deg2Rad);
        float spawnY = Player.transform.position.y + spawnRadius * Mathf.Sin(spawnAngle * Mathf.Deg2Rad);

        Instantiate(Alien4, new Vector3(spawnX, spawnY, 0), Quaternion.identity);


    }


    //void MakeBullet()
    //{
    //    // �÷��̾�� ���� �Ѿ��� �����ǰ� �ϴ� �ڵ�
    //    float x = Player.transform.position.x;
    //    float y = Player.transform.position.y;
    //    Instantiate(Bullet, new Vector3(x, y, 0), Quaternion.identity);
    //}
}



