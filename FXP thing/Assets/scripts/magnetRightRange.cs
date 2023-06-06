using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetRightRange : MonoBehaviour
{

    public Vector3[] rightRange;
    [SerializeField] public Vector3 magBlockPos;
    [HideInInspector]private Vector3 rangeStart;
    [SerializeField]public int rangeEnd;
    [HideInInspector]public float xInc, yInc; 

    public bool inRange;

    public GameObject scriptController;
    private rangeCalculate rangeCalculate;

    public GameObject metalBlock;

    public GameObject rangeTile;


    // Start is called before the first frame update
    void Start()
    {
        rangeCalculate = scriptController.GetComponent<rangeCalculate>();

        int endOfRange = rangeEnd; 
        transform.position = magBlockPos;
        rangeStart = new Vector3((transform.position.x + (xInc)), transform.position.y + (yInc), 0f);
    
        rightRange = (rangeCalculate.rangeCalculateFunc(endOfRange, rangeStart, rangeCalculate.xyIncrements[0], rangeCalculate.xyIncrements[3]));
    
        rangeCalculate.drawRange(rightRange, rangeTile);
    }

    // Update is called once per frame
    void Update()
    {
       for (int x = 0; x < rightRange.Length; x++)
        {
            if(metalBlock.GetComponent<Transform>().position == rightRange[x])
            {
                inRange = true;
            }
            else
            {
                inRange = false;
            }
        } 
    }
}
