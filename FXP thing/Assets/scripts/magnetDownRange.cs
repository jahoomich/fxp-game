using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetDownRange : MonoBehaviour
{
    public int rangeLength;

    [SerializeField] public int rangeLengthInput;

    public Vector3 startPosition;

    public float[] xyIncrements = new float[2];

    public Vector3[] downRange;

    public GameObject rangeTileSprite;

    public GameObject metalBlock;

    [SerializeField] public Vector3 magnetBlockPosition;

    public GameObject highlightObject;
    public GameObject magnetBlock;
    public Vector3 endPosition;
    

    

    public GameObject player;
    private playerState playerState;

    

    private metalBlockMovement metalBlockMovement;

    public bool isTouching, valid1, valid2;




    void Start() 
    {
        metalBlockMovement = metalBlock.GetComponent<metalBlockMovement>();
        playerState = player.GetComponent<playerState>();

        

        highlightObject.transform.position = magnetBlockPosition;
        highlightObject.GetComponent<SpriteRenderer>().enabled = false;

        magnetBlock.transform.position = magnetBlockPosition;
        rangeLength = rangeLengthInput;
        xyIncrements[0] = 0.5f;
        xyIncrements[1] = -0.25f;
        startPosition = new Vector3((this.GetComponent<Transform>().position.x + xyIncrements[0]), (this.GetComponent<Transform>().position.y + xyIncrements[1]), 0f);
        downRange = CalculateDownRange();
        //for (int x = 0; x < downRange.Length; x++)
        //{
            //Debug.Log(downRange[x]);
        //}

        drawRange();
    }

    void Update() 
    {
        
        
       

        if(Input.GetMouseButtonDown(0) && checkRange() == true && playerState.isPositive == true && isTouching == true && metalBlock.transform.position != downRange[downRange.Length - 1])
        {
            valid1 = true;
            valid2 = false;
            moveDown();
            //moves metal block downwards
            
        }
        else
        {
            valid1 = false;
        }

        if(Input.GetMouseButtonDown(0) && checkRange() == true && playerState.isNegative == true && isTouching == true && metalBlock.transform.position != downRange[0])
        {
            valid1 = false;
            valid2 = true;
            moveUp();
            //moves metal block upwards
  
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


    public Vector3[] CalculateDownRange()
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
        for (int x = 0; x < downRange.Length; x++)
        {
            Vector3 position = new Vector3(downRange[x].x, (downRange[x].y - 0.5f), 0f);
            Instantiate(rangeTileSprite, position, Quaternion.identity);
        }
    }

    public bool checkRange()
    {
        for (int x = 0; x < downRange.Length; x++)
        {
            if(metalBlock.GetComponent<Transform>().position == downRange[x])
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
