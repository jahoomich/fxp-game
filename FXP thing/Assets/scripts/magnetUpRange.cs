using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetUpRange : MonoBehaviour
{
    public int rangeLength;

    [SerializeField] public int rangeLengthInput;

    public Vector3 startPosition;

    public float[] xyIncrements = new float[2];

    public Vector3[] upRange;

    public GameObject rangeTileSprite;

    public GameObject metalBlock;

    public GameObject highlightObject;

    public GameObject magnetBlock;

    [SerializeField] public Vector3 magnetBlockPosition;

    

    

    public int hertzNumber;

    public GameObject player;
    private playerState playerState;

    
    

    public bool isTouching;

    public bool valid1;
    public bool valid2;

    


    void Start() 
    {

        playerState = player.GetComponent<playerState>();

        

        highlightObject.transform.position = magnetBlockPosition;
        highlightObject.GetComponent<SpriteRenderer>().enabled = false;

        magnetBlock.transform.position = magnetBlockPosition;
        rangeLength = rangeLengthInput;
        xyIncrements[0] = -0.5f;
        xyIncrements[1] = 0.25f;
        startPosition = new Vector3((this.GetComponent<Transform>().position.x + xyIncrements[0]), (this.GetComponent<Transform>().position.y + xyIncrements[1]), 0f);
        upRange = CalculateUpRange();
        //for (int x = 0; x < downRange.Length; x++)
        //{
            //Debug.Log(downRange[x]);
        //}
        drawRange();
    }

    void Update() 
    {
        
        if(Input.GetMouseButtonDown(0) && checkRange() == true && metalBlock.transform.position != upRange[upRange.Length - 1] && isTouching == true && playerState.isPositive == true)
        {
            
            valid1 = true;
            valid2 = false;
            
            moveUp();
            
            
            // move metal block upwards
            
        }
        else
        {
            valid1 = false;
        }

        if(Input.GetMouseButtonDown(0) && checkRange() == true && metalBlock.transform.position != upRange[0] && playerState.isNegative == true && isTouching == true)
        {
            valid1 = false;
            valid2 = true;
            moveDown();
        
            //move metal block downwards
            
  
        }
        else
        {
            valid2 = false;
        }

       
        
    }

    public void moveUp()
    {
        metalBlock.transform.Translate(-0.5f, 0.25f, 0f);
        
    }

    public void moveDown()
    {
        metalBlock.transform.Translate(0.5f, -0.25f, 0f);
    }

   

    public Vector3[] CalculateUpRange()
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
        for (int x = 0; x < upRange.Length; x++)
        {
            Vector3 position = new Vector3(upRange[x].x, (upRange[x].y - 0.5f), 0f);
            Instantiate(rangeTileSprite, position, Quaternion.identity);
        }
    }

    public bool checkRange()
    {
        for (int x = 0; x < upRange.Length; x++)
        {
            if(metalBlock.GetComponent<Transform>().position == upRange[x])
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

