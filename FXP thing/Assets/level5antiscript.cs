using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level5antiscript : MonoBehaviour
{
    public GameObject magnetDown;

    public GameObject magnetLeft;

    private magnetLeftRange magnetLeftRange;
    private magnetDownRange magnetDownRange;

    // Start is called before the first frame update
    void Start()
    {
        magnetLeftRange = magnetLeft.GetComponent<magnetLeftRange>();
        magnetDownRange = magnetDown.GetComponent<magnetDownRange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x != -2.5f && this.transform.position.y != 0.25f)
        {
            if (magnetDownRange.valid1 == true)
            {
                this.transform.Translate(-0.5f, 0.25f, 0f);
            }

            else if (magnetDownRange.valid2 == true)
            {
            this.transform.Translate(0.5f, -0.25f, 0f);
            }

            if (magnetLeftRange.isValid1 == true)
            {
            this.transform.Translate(-0.5f, -0.25f, 0f);
            }
            else if (magnetLeftRange.isValid2 == true)
            {
            this.transform.Translate(0.5f, 0.25f, 0f);
            }

         
         
        }
      
    }
}
