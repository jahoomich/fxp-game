using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetUpRange : MonoBehaviour
{
    public Vector3[] upRange;
    [SerializeField] public Vector3 magBlockPos;
    [HideInInspector]private Vector3 rangeStart;
    [SerializeField]public int rangeEnd;
    [HideInInspector]public float xInc, yInc;

    public GameObject scriptController;
    private rangeCalculate rangeCalculate;

    public GameObject rangeTile;
    //public Grid grid;
    //private GridLayout gridLayout;

    // Start is called before the first frame update
    void Start()
    {
        rangeCalculate = scriptController.GetComponent<rangeCalculate>();
        //gridLayout = grid.GetComponent<GridLayout>();

        int endOfRange = rangeEnd; 
        transform.position = magBlockPos;
        xInc = -0.5f;
        yInc = 0.25f;
        rangeStart = new Vector3((transform.position.x + (xInc)), transform.position.y + (yInc), 0f);
        
        upRange = (rangeCalculate.rangeCalculateFunc(endOfRange, rangeStart, xInc, yInc));
        Debug.Log(upRange[rangeEnd - 1]);

        rangeCalculate.drawRange(upRange, rangeTile);
    }

    


    // Update is called once per frame
    void Update()
    {
        //for (int x = 0; x < upRange.Length; x++)
        //{
            //Vector3Int position = gridLayout.WorldToCell(upRange[x]);
            //Debug.Log(position);
        //}
    }
}
