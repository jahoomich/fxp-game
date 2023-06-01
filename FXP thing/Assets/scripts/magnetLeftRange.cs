using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetLeftRange : MonoBehaviour
{

    public Vector3[] leftRange;
    [SerializeField] public Vector3 magBlockPos;
    [HideInInspector]private Vector3 rangeStart;
    [SerializeField]public int rangeEnd;
    [HideInInspector]public float xInc, yInc; 

    public GameObject scriptController;
    private rangeCalculate rangeCalculate;

    public GameObject rangeTile;

    // Start is called before the first frame update
    void Start()
    {
        rangeCalculate = scriptController.GetComponent<rangeCalculate>();

        int endOfRange = rangeEnd; 
        transform.position = magBlockPos;
        xInc = 0.5f;
        yInc = 0.25f;
        rangeStart = new Vector3((transform.position.x + (xInc)), transform.position.y + (yInc), 0f);
    
        leftRange = (rangeCalculate.rangeCalculateFunc(endOfRange, rangeStart, xInc, yInc));          
    
        rangeCalculate.drawRange(leftRange, rangeTile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
