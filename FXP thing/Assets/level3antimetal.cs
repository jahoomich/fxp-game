using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3antimetal : MonoBehaviour
{
    public GameObject magnetDown;
    private magnetDownRange magnetDownRange;

    public GameObject metalBlock;

    public GameObject magnetRight;
    private magnetRightRange magnetRightRange;
    // Start is called before the first frame update
    void Start()
    {
        magnetRightRange = magnetRight.GetComponent<magnetRightRange>();
        magnetDownRange = magnetDown.GetComponent<magnetDownRange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (metalBlock.GetComponent<SpriteRenderer>().enabled == true && this.transform.position.x != 1f && this.transform.position.y != 0.5f)
        {
            if (magnetDownRange.valid1 == true || magnetRightRange.valid2 == true || magnetRightRange.valid1 == true)
            {
                this.transform.Translate(0.5f, 0.25f, 0f);
   
            }
        }

        if (metalBlock.transform.position == this.transform.position)
        {
            metalBlock.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
