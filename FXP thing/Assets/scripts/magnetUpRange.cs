using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetUpRange : MonoBehaviour
{
    public Vector3[] range;
    [SerializeField] public Vector3 magBlockPos;
    [HideInInspector]private Vector3 rangeStart;
    public int rangeEnd;
    [HideInInspector]public float xInc, yInc;

    // Start is called before the first frame update
    void Start()
    {
        rangeEnd = 8; 
        transform.position = magBlockPos;
        xInc = 0.5f;
        yInc = 0.25f;
        rangeStart = new Vector3((transform.position.x + -(xInc)), transform.position.y + (yInc), 0f);
        range = new Vector3[rangeEnd];
        rangeCalc();
    }

    void rangeCalc()
    {
        for (int i = 0; i < rangeEnd; i++)
        {
            range[i] = new Vector3((rangeStart.x + -(xInc * i)), (rangeStart.y + (yInc * i)), 0f);
        }
        
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
