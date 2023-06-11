using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class playerMovement : MonoBehaviour
{
    [SerializeField] public Sprite facingUpSprite, facingDownSprite, facingLeftSprite, facingRightSprite;
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

        
        float playerVert = Input.GetAxis("Vertical") * 0.75f * Time.deltaTime;
        float playerHori = Input.GetAxis("Horizontal") * 0.75f * Time.deltaTime;

        if (playerVert != 0)
        {
            playerHori = 0;
        }
        else
        {
            playerVert = 0;
        }

        transform.Translate(playerHori,playerVert,0);

        shootBeamDraw.shootBeamDrawFunc(playerState.isShooting, playerDirectionsArray, square);

        if (Input.GetKeyDown(KeyCode.W))  
        {
            directionArrayLoop();
            playerDirectionsArray[0] = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            directionArrayLoop();
            playerDirectionsArray[1] = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            directionArrayLoop();
            playerDirectionsArray[2] = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            directionArrayLoop();
            playerDirectionsArray[3] = true;
        }
       
        if (playerVert > 0)
        {   
            colliderArrayLoop();
            square[0].GetComponent<BoxCollider2D>().enabled = true;

        }

        if (playerDirectionsArray[0] == true)
        {
            this.GetComponent<SpriteRenderer>().sprite = facingUpSprite;
        }
        else if (playerDirectionsArray[1] == true)
        {
            this.GetComponent<SpriteRenderer>().sprite = facingDownSprite;
        }
        else if (playerDirectionsArray[2] == true)
        {
            this.GetComponent<SpriteRenderer>().sprite = facingLeftSprite;
        }
        else if (playerDirectionsArray[3] == true)
        {
            this.GetComponent<SpriteRenderer>().sprite = facingRightSprite;
        }
      
       
        //down box
        if (playerVert < 0)
        {
            colliderArrayLoop();
            square[1].GetComponent<BoxCollider2D>().enabled = true;

        }
       
     
        //right box
        if (playerHori > 0)
        {
            colliderArrayLoop();
            square[3].GetComponent<BoxCollider2D>().enabled = true;
        }
      
      
        //left box
        if (playerHori < 0)
        {
            colliderArrayLoop();
            square[2].GetComponent<BoxCollider2D>().enabled = true;


        }
       

        
        
       
   
     


    }
}
