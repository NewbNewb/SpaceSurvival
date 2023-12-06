using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //ÅÂ¼º´Ô ¼±¾ð
    public GameObject Alien1;
    public Transform Player;

    //ÁöÈÄ´Ô ¼±¾ð
    public Time timeTxt;
    float time;

    void Start()
    {
        //ÅÂ¼º´Ô
        InvokeRepeating("MakeAlien1", 0.0f, 2f);


    }

    // Update is called once per frame
    void Update()
    {
        //ÁöÈÄ´Ô
        time += Time.deltaTime;
        // timeTxt.text = time.ToString();


    }

    // ÅÂ¼º´Ô
    void MakeAlien1()
    {
        float spawnAngle = Random.Range(0.0f, 360.0f);
        float spawnRadius = Random.Range(10.0f, 11.0f);

        float spawnX = Player.position.x + spawnRadius * Mathf.Cos(spawnAngle * Mathf.Deg2Rad);
        float spawnY = Player.position.y + spawnRadius * Mathf.Sin(spawnAngle * Mathf.Deg2Rad);

        Instantiate(Alien1, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
    }
}
