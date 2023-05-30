using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetUpMovement : MonoBehaviour
{
    public int moveAmount;
    public bool inRange;
    public bool powerOn;
    public Vector3 endPosition;

    public GameObject metalBlock;
    private Transform metBlockTransform;
    private metalBlockMovement metalBlockMovement;

    public GameObject magnetBlock;
    private magnetUpRange magnetUpRange;

    public GameObject player;
    private playerState playerState;

    [HideInInspector]public bool isColliding;

    // Start is called before the first frame update
    void Start()
    {
        moveAmount = 10;
        inRange = false;
        magnetUpRange = magnetBlock.GetComponent<magnetUpRange>();
        metBlockTransform = metalBlock.GetComponent<Transform>();
        playerState = player.GetComponent<playerState>();
        metalBlockMovement = metalBlock.GetComponent<metalBlockMovement>();
    }

    //public bool upCheckRange(Vector3 position)
    //{
        //for (int i = 0; i < magnetUpRange.range.Length; i++)
        //{
            //if (position == magnetUpRange.range[i])
            //{
                //return true;
            //}
            //else
            //{
                //return false; 
           //}
       // }
        //return false;
    //}

    //void upMagnetMovement()
    //{
        //upwards movement
       // if ((inRange == true) && (metalBlock.transform.position != magnetUpRange.range[magnetUpRange.rangeEnd - 1]) && (powerOn == true) && playerState.isPositive == true)
        //{

            
            //StartCoroutine(upMove());

            
                
        ///}
        //else if ((inRange = true) && (metalBlock.transform.position.x < magnetUpRange.range[magnetUpRange.rangeEnd - 1].x) && (metalBlock.transform.position.y > magnetUpRange.range[magnetUpRange.rangeEnd - 1].y) && (powerOn == true) && playerState.isNegative == true)

    //}

    

    //private IEnumerator upMove()
    //{
        //endPosition = new Vector3((metBlockTransform.position.x + -(magnetUpRange.xInc * moveAmount)), (metBlockTransform.position.y + (magnetUpRange.yInc * moveAmount)), 0f);

        //while (metalBlock.transform.position != endPosition)
        //{
            //metalBlockMovement.moveUp();
            //yield return null;
        //}
            
    //}

    //private IEnumerator downMove()
    //{
        //while(metalBlock.transform.position != )
   // }

    void isPowered()
    {
        if (isColliding == true && playerState.isShooting == true) 
        {
            powerOn = true;
        }
        else
        {
            powerOn = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "playerTrigger")
        {
            isColliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "playerTrigger")
        {
            isColliding = false;
        }
    }

    // Update is called once per frame
    //void Update()
    //{
        //if (upCheckRange(metalBlock.transform.position) == true)
        //{
            //inRange = true;
        //}
       // else
        //{
            //inRange = false;
        //}
        
        //isPowered(); 
        //upMagnetMovement();
    //}
}
