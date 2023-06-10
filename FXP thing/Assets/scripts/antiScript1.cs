using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antiScript1 : MonoBehaviour
{
    public GameObject magnet;
    private magnetUpRange magnetUpRange;

    // Start is called before the first frame update
    void Start()
    {
        magnetUpRange = magnet.GetComponent<magnetUpRange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (magnetUpRange.valid2 == true)
        {
            this.transform.Translate(0.5f, -0.25f, 0f);
        }
        else if (magnetUpRange.valid1 == true)
        {
            this.transform.Translate(-0.5f, 0.25f, 0f);
        }
    }
}
