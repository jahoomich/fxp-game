using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetUpRange : MonoBehaviour
{
    [SerializeField] public int rangeLength;

    public Vector3 startPosition;

    public float[] xyIncrements = new float[2];

    public Vector3[] upRange;

    public GameObject rangeTileSprite;

    public GameObject metalBlock;

    public GameObject highlightObject;

    public GameObject magnetBlock;

    [SerializeField] public Vector3 magnetBlockPosition;

    public Vector3 endPosition;

    public GameObject hertz;
    private hertzController hertzController;

    public int hertzNumber;

    public GameObject player;
    private playerState playerState;

    public GameObject antiMetalBlock;
    private metalBlockMovement metalBlockMovement;

    public bool isTouching;

    


    void Start() 
    {
        metalBlockMovement = metalBlock.GetComponent<metalBlockMovement>();

        playerState = player.GetComponent<playerState>();

        hertzController = hertz.GetComponent<hertzController>();

        highlightObject.transform.position = magnetBlockPosition;
        highlightObject.GetComponent<SpriteRenderer>().enabled = false;

        magnetBlock.transform.position = magnetBlockPosition;
        rangeLength = 2;
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
        hertzNumber = hertzController.hertzNum;
        
        if (hertzNumber >= upRange.Length)
        {
            hertzNumber = (upRange.Length - 1);
        }

        if(playerState.isShooting == true && checkRange() == true && playerState.isPositive == true && isTouching == true && metalBlock.transform.position != upRange[upRange.Length - 1])
        {

            StartCoroutine(moveUp());
            
        }

        else if(playerState.isShooting == true && checkRange() == true && playerState.isNegative == true && isTouching == true && metalBlock.transform.position != upRange[0])
        {
            StartCoroutine(moveDown());
            //metalBlock.transform.position = endNegativePosition();
  
        }

        if (metalBlock.transform.position == antiMetalBlock.transform.position)
        {
            metalBlock.GetComponent<SpriteRenderer>().enabled = false;
        }
   
        
    }
    IEnumerator moveDown()
    {
        
        endPosition = new Vector3(upRange[upRange.Length - 1].x + (0.5f * hertzNumber), upRange[upRange.Length - 1].y + (-0.25f * hertzNumber), 0f);
        while(metalBlock.transform.position != endPosition && metalBlock.transform.position != upRange[0])
        {
            metalBlockMovement.moveDown();
            antiMetalBlock.transform.Translate(0.5f, -0.25f, 0f);
            if (metalBlock.transform.position == endPosition || metalBlock.transform.position == upRange[0])
            {
                break;
            }
            
            yield return null;
        }
    }

    IEnumerator moveUp()
    {
        
        endPosition = new Vector3(upRange[0].x + (-0.5f * hertzNumber), upRange[0].y + (0.25f * hertzNumber), 0f);
        while(metalBlock.transform.position != endPosition && metalBlock.transform.position != upRange[upRange.Length - 1])
        {
            metalBlockMovement.moveUp();
            antiMetalBlock.transform.Translate(0.5f, -0.25f, 0f);
            if (metalBlock.transform.position == endPosition || metalBlock.transform.position == upRange[upRange.Length - 1])
            {
                break;
            }
            
            yield return null;
        }
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

