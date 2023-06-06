using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class playerMovement : MonoBehaviour
{
    
    [SerializeField] public GameObject[] square = new GameObject [4];
    public bool[] playerDirectionsArray = new bool [4];
    private bool facingUp, facingDown, facingLeft, facingRight;

    private shootBeamDraw shootBeamDraw;
    private playerState playerState;


    
    

    void colliderArrayLoop()
    {
        for (int i = 0; i < 4; i++)
        {
            square[i].GetComponent<BoxCollider2D>().enabled = false;
            square[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void directionArrayLoop()
    {
        for (int i = 0; i < playerDirectionsArray.Length; i++)
        {
            playerDirectionsArray[i] = false;
        }
    }

    public IEnumerator keepValue(bool direction, float value)
    {
        while(value == 0f)
        {
            direction = true;
        }
        yield return null;
    }

    void Start() 
    {

        shootBeamDraw = this.GetComponent<shootBeamDraw>();
        playerState = this.GetComponent<playerState>();

        playerDirectionsArray[0] = facingUp;
        playerDirectionsArray[1] = facingDown;
        playerDirectionsArray[2] = facingLeft;
        playerDirectionsArray[3] = facingRight;
        colliderArrayLoop();
        directionArrayLoop();
    }
  
    // Update is called once per frame
    void Update()
    {

        
        float playerVert = Input.GetAxis("Vertical") * 0.5f * Time.deltaTime;
        float playerHori = Input.GetAxis("Horizontal") * 0.5f * Time.deltaTime;

        if (playerVert != 0.0f)
        {
            playerHori = 0;
        }
        if (playerHori != 0.0f)
        {
            playerVert = 0;
        }

        transform.Translate(playerHori,playerVert,0);

        
       
        if (playerVert > 0.00f)
        {   
            directionArrayLoop();
            colliderArrayLoop();
            square[0].GetComponent<BoxCollider2D>().enabled = true;
            StartCoroutine(keepValue(playerDirectionsArray[0], 0f));
            //playerDirectionsArray[0] = true;
            shootBeamDraw.shootBeamDrawFunc(playerState.isShooting, playerDirectionsArray[0], square[0]);

        }
        else
        {
            playerDirectionsArray[0] = false;
        }
       
        //down box
        if (playerVert < 0.00f)
        {
            directionArrayLoop();
            colliderArrayLoop();
            square[1].GetComponent<BoxCollider2D>().enabled = true;
            playerDirectionsArray[1] = true;
            shootBeamDraw.shootBeamDrawFunc(playerState.isShooting, playerDirectionsArray[1], square[1]);

        }
        else
        {
            playerDirectionsArray[1] = false;
        }
     
        //right box
        if (playerHori > 0.00f)
        {
            directionArrayLoop();
            colliderArrayLoop();
            square[2].GetComponent<BoxCollider2D>().enabled = true;
            playerDirectionsArray[2] = true;
            shootBeamDraw.shootBeamDrawFunc(playerState.isShooting, playerDirectionsArray[2], square[2]);

        }
        else
        {
            playerDirectionsArray[2] = false;
        }
      
        //left box
        if (playerHori < 0.00f)
        {
            directionArrayLoop();
            colliderArrayLoop();
            square[3].GetComponent<BoxCollider2D>().enabled = true;
            playerDirectionsArray[3] = true;
            shootBeamDraw.shootBeamDrawFunc(playerState.isShooting, playerDirectionsArray[3], square[3]);


        }
        else
        {
            playerDirectionsArray[3] = false;
        }

        
        
       
   
     


    }
}
