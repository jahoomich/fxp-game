using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerState : MonoBehaviour
{

    public bool isPositive;
    public bool isNegative;

    public bool isShooting;

    // Start is called before the first frame update
    void Start()
    {
        isPositive = false;
        isNegative = false;

        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            isPositive = true;
            isNegative = false;
            
        }
        else if (Input.GetKeyDown("2"))
        {
            isPositive = false;
            isNegative = true;
            
        }

        if (Input.GetMouseButton(0))
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }
        
    }
}
