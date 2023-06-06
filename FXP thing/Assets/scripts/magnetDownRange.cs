using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetDownRange : MonoBehaviour
{
    public int rangeLength;

    public Vector3 startPosition;

    public float[] xyIncrements = new float[2];

    public Vector3[] downRange;

    public GameObject rangeTileSprite;

    public GameObject metalBlock;

    void Start() 
    {
        rangeLength = 2;
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
        Debug.Log(checkRange());    
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
}
