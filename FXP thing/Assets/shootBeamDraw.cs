using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBeamDraw : MonoBehaviour
{
    

    

    

    


    public void shootBeamDrawFunc(bool isShooting, bool direction, GameObject square)
    {
        if (isShooting == true && direction == true)
        {
            square.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if(isShooting == false && direction == false)
        {
            square.GetComponent<SpriteRenderer>().enabled = false;

        }
        
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
}
