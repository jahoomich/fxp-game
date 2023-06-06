using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBeamDraw : MonoBehaviour
{
    

    

    

    


    public void shootBeamDrawFunc(bool isShooting, bool[] direction, GameObject[] square)
    {
        for (int x = 0; x < direction.Length; x++)
        {
            if (isShooting == true && direction[x] == true)
            {
                square[x].GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                square[x].GetComponent<SpriteRenderer>().enabled = false;
 
            }
        }        
        
    
        
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
}
