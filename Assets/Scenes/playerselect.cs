using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerselect : MonoBehaviour
{
    public GameObject player1img;
    public GameObject player2img;

   


    SpriteRenderer spriteRenderer;

    public Sprite sprite1;
    public Sprite sprite2;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            player1img.SetActive(false);
            player2img.SetActive(true);



            spriteRenderer.sprite = sprite1;

       
            

        }

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            player1img.SetActive(true);
            player2img.SetActive(false);

            spriteRenderer.sprite = sprite2;

            

        }
    }
}
