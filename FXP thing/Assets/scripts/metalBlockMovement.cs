using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metalBlockMovement : MonoBehaviour
{
    //reference to the metal block (the tilemap specifically)
    [SerializeField] public GameObject metalBlockTilemap;
    //reference to the metal block's starting position.
    public Vector3 initialPosition;
    //reference to where the metal block will end up.
    public Vector3 endPosition;

    public Vector3 startPosition;
    //reference to how far the block will move. 
    public int moveAmount;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = new Vector3(0f, 0f, 0f);
        
        moveAmount = 2;
        
    }

    public void moveBlockForward()
    {
        startPosition = initialPosition;
        
        endPosition = new Vector3((startPosition.x + (moveAmount * -0.5f)), (startPosition.y + (moveAmount * 0.25f)), 0f);
        

       if(metalBlockTilemap.transform.position != endPosition)
        {
            metalBlockTilemap.transform.Translate(-0.005f,0.0025f,0f);
            
        } 
    }

    public void moveBlockBackward()
    {
        startPosition = metalBlockTilemap.transform.position;
        
        endPosition = new Vector3((startPosition.x + (moveAmount * 0.5f)), (startPosition.y + (moveAmount * -0.25f)), 0f);
        
        if ((metalBlockTilemap.transform.position != endPosition) && (metalBlockTilemap.transform.position != initialPosition))
        {
            metalBlockTilemap.transform.Translate(0.005f, -0.0025f, 0f);
        }
    }

    
}
