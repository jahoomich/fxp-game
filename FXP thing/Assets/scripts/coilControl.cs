using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coilControl : MonoBehaviour
{

    public int rangeLength;

    [SerializeField] public int rangeInput;
    [SerializeField] public Vector3 startPosition;

    public GameObject electricRay;

    public Vector3[] coilRange;

    public GameObject metalBlock;

    
    

    
    // Start is called before the first frame update
    void Start()
    {
        rangeLength = rangeInput;
        startPosition = new Vector3(this.GetComponent<Transform>().position.x + 0.5f, this.GetComponent<Transform>().position.y + 0.25f, 0f);
        Debug.Log(startPosition);
        coilRange = calculateCoilRange();
        drawRange();
    }

    // Update is called once per frame
    void Update()
    {
        

        removeRay();
    }

    public Vector3[] calculateCoilRange()
    {
        Vector3[] range = new Vector3[rangeLength];
        for (int x = 0; x < rangeLength; x++)
        {
            range[x] = new Vector3(startPosition.x + (0.5f * x), startPosition.y + (0.25f * x), 0f);

        }
        return range;
    }

    public bool checkRange()
    {
        for (int x = 0; x < coilRange.Length; x++)
        {
            if (metalBlock.transform.position == coilRange[x] || GameObject.FindGameObjectWithTag("anti").transform.position == coilRange[x])
            {
                return true;
            }
            
                
        }
        return false;
    }

    public void drawRange()
    {
        for (int x = 0; x < coilRange.Length; x++)
        {
            Vector3 position = new Vector3(coilRange[x].x, coilRange[x].y, 0f);
            Instantiate(electricRay, position, Quaternion.identity);
        }
    }

    


    public void removeRay()
    {
        GameObject[] electricRays = GameObject.FindGameObjectsWithTag("electricRay");

        if (checkRange() == true)
        {
            for (int x = 0; x < electricRays.Length; x++)
            {
                electricRays[x].GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else
        {
            for (int x = 0; x < electricRays.Length; x++)
            {
                electricRays[x].GetComponent<SpriteRenderer>().enabled = true;

            }

        }
    }
}
