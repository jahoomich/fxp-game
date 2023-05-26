using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetController : MonoBehaviour
{

    public GameObject player;
    public GameObject metalBlock;
    private playerState playerState;
    private metalBlockMovement metalBlockMovement;
    public bool inRange;

    void Start() 
    {
        inRange = false;
        playerState = player.GetComponent<playerState>();
        metalBlockMovement = metalBlock.GetComponent<metalBlockMovement>();
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if ((other.tag == "playerTrigger"))
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if ((other.tag == "playerTrigger"))
        {
            inRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((inRange == true) && (playerState.isShooting == true) && (playerState.isPositive == true))
        {
            metalBlockMovement.moveBlockForward();
        }

        if ((inRange == true) && (playerState.isShooting == true) && (playerState.isNegative == true))
        {
            metalBlockMovement.moveBlockBackward();
        }
    
       
        
    }
}
