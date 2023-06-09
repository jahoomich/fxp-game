using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetLeftRange : MonoBehaviour
{
    public int rangeLength;
    [SerializeField] public int rangeInput;


    public Vector3 startPosition;

    public float[] xyIncrements = new float[2];

    public Vector3[] leftRange;

    public GameObject rangeTileSprite;

    public GameObject metalBlock;

    private metalBlockMovement metalBlockMovement;
    

    [SerializeField] public Vector3 magnetBlockPosition;

    public GameObject highlightObject;

    public GameObject magnetBlock;

    public GameObject player;
    private playerState playerState;

    
    public bool isTouching;

    public Vector3 endPosition;

    

    public Vector3 currentPos;
    public bool isValid1, isValid2;

    

    
    

    

    void Start() 
    {

        playerState = player.GetComponent<playerState>();
        

        highlightObject.transform.position = magnetBlockPosition;
        highlightObject.GetComponent<SpriteRenderer>().enabled = false;

        magnetBlock.transform.position = magnetBlockPosition;
        rangeLength = rangeInput;
        xyIncrements[0] = -0.5f;
        xyIncrements[1] = -0.25f;
        startPosition = new Vector3((this.GetComponent<Transform>().position.x + xyIncrements[0]), (this.GetComponent<Transform>().position.y + xyIncrements[1]), 0f);
        leftRange = CalculateLeftRange();
        //for (int x = 0; x < downRange.Length; x++)
        //{
            //Debug.Log(downRange[x]);
        //}
       

        drawRange();
     
    }

    void Update() 
    {

        
        
       

        if(Input.GetMouseButtonDown(0) && checkRange() == true && playerState.isPositive == true && isTouching == true && metalBlock.transform.position != leftRange[leftRange.Length - 1])
        {
            isValid1 = true;
            isValid2 = false;
            moveLeft();
            //move metal block to the left
            
        }
        else
        {
            isValid1 = false;
        }

        if(Input.GetMouseButtonDown(0) && checkRange() == true && playerState.isNegative == true && isTouching == true && metalBlock.transform.position != leftRange[0])
        {
            isValid1 = false;
            isValid2 = true;
            moveRight();
            //move metal block to the right
  
        }
        else
        {
            isValid2 = false;
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


    

    
    


    public Vector3[] CalculateLeftRange()
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
        for (int x = 0; x < leftRange.Length; x++)
        {
            Vector3 position = new Vector3(leftRange[x].x, (leftRange[x].y - 0.5f), 0f);
            Instantiate(rangeTileSprite, position, Quaternion.identity);
        }
    }

    public bool checkRange()
    {
        for (int x = 0; x < leftRange.Length; x++)
        {
            if(metalBlock.GetComponent<Transform>().position == leftRange[x])
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
