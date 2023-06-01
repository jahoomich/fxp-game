using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeCalculate : MonoBehaviour
{

    public Vector3[] rangeCalculateFunc(int rangeEndFunc, Vector3 rangeStartFunc, float xIncFunc, float yIncFunc)
    {
        Vector3[] range = new Vector3[rangeEndFunc];
        for (int i = 0; i < rangeEndFunc; i++)
        {
            range[i] = new Vector3(rangeStartFunc.x + (xIncFunc * i), (rangeStartFunc.y + (yIncFunc * i)), 0f);
        }
        return range;
    }

    public void drawRange(Vector3[] range, GameObject tile)
    {
        
        for (int x = 0; x < range.Length; x++)
        {
            Vector3 position = new Vector3(range[x].x, (range[x].y - 0.5f), 0f);
            Instantiate(tile, position, Quaternion.identity);

        }
    }

    

}
