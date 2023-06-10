using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetRightRange : MonoBehaviour
{
    public int rangeLength;

    [SerializeField] public int rangeInput;

    public Vector3 startPosition;

    public float[] xyIncrements = new float[2];

    public Vector3[] rightRange;

    public GameObject rangeTileSprite;

    public GameObject metalBlock;

    public GameObject magnetBlock;

    [SerializeField] public Vector3 magnetBlockPosition;

    public GameObject highlightObject;

    public Vector3 endPosition;
   

    public int hertzNumber;

    public GameObject player;
    private playerState playerState;

    
    

    public bool isTouching, valid1, valid2;




    void Start() 
    {

        playerState = player.GetComponent<playerState>();

        

        highlightObject.transform.position = magnetBlockPosition;
        highlightObject.GetComponent<SpriteRenderer>().enabled = false;

        magnetBlock.transform.position = magnetBlockPosition;
        rangeLength = rangeInput;
        xyIncrements[0] = 0.5f;
        xyIncrements[1] = 0.25f;
        startPosition = new Vector3((this.GetComponent<Transform>().position.x + xyIncrements[0]), (this.GetComponent<Transform>().position.y + xyIncrements[1]), 0f);
        rightRange = CalculateRightRange();
        //for (int x = 0; x < downRange.Length; x++)
        //{
            //Debug.Log(downRange[x]);
        //}

        drawRange();
    }

    void Update() 
    {
       
        
        

        if(Input.GetMouseButtonDown(0) && checkRange() == true && metalBlock.transform.position != rightRange[rightRange.Length - 1] && isTouching == true && playerState.isPositive == true)
        {
            valid1 = true;
            valid2 = false;

            //moves the metal block to the right
            moveRight();
            
        }
        else
        {
            valid1 = false;
        }

        if(Input.GetMouseButtonDown(0) && checkRange() == true && metalBlock.transform.position != rightRange[0] && playerState.isNegative == true && isTouching == true)
        {
            valid1 = false;
            valid2 = true;
            //moves metal block to the left
            moveLeft();
        }
        else
        {
            valid2 = false;
        }


          
    }

    public void moveRight()
    {
        metalBlock.transform.Translate(0.5f, 0.25f, 0f);
    }
    public void moveLeft()
    {
        metalBlock.transform.Translate(-0.5f, -0.25f, 0f);
    }
    


    public Vector3[] CalculateRightRange()
    {
        Vector3[] range = new Vector3[rangeLength];
        for (int x = 0; x < rangeLength; x++)
        {
            range[x] = new Vector3((startPosition.x + (xyIncrements[0] * x)),(startPosition.y + (xyIncrements[1] * x)),0f);
        }
        return range;
    }

    public void drawRange()
    {
        for (int x = 0; x < rightRange.Length; x++)
        {
            Vector3 position = new Vector3(rightRange[x].x, (rightRange[x].y - 0.5f), 0f);
            Instantiate(rangeTileSprite, position, Quaternion.identity);
        }
    }

    public bool checkRange()
    {
        for (int x = 0; x < rightRange.Length; x++)
        {
            if(metalBlock.GetComponent<Transform>().position == rightRange[x])
            {
                return true;
            }
        }
        return false;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "playerTrigger")
        {
            isTouching = true;
            highlightObject.GetComponent<SpriteRenderer>().enabled = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "playerTrigger")
        {
            isTouching = false;
            highlightObject.GetComponent<SpriteRenderer>().enabled = false;

        }
    }
}
    

