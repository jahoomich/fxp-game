using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class playerMovement : MonoBehaviour
{
    
    [SerializeField] public GameObject[] square = new GameObject [4];
    
    

    void arrayLoop()
    {
        for (int i = 0; i < 4; i++)
        {
            square[i].GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void Start() 
    {
        arrayLoop();
    }
  
    // Update is called once per frame
    void Update()
    {
        float playerVert = Input.GetAxis("Vertical") * 0.5f * Time.deltaTime;
        float playerHori = Input.GetAxis("Horizontal") * 0.5f * Time.deltaTime;

        transform.Translate(playerHori,playerVert,0);

       

        if (playerVert > 0)
        {
            arrayLoop();
            square[0].GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (playerVert < 0)
        {
            arrayLoop();
            square[1].GetComponent<BoxCollider2D>().enabled = true;
        }

        if (playerHori > 0)
        {
            arrayLoop();
            square[3].GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (playerHori < 0)
        {
            arrayLoop();
            square[2].GetComponent<BoxCollider2D>().enabled = true;
        }



    }
}
