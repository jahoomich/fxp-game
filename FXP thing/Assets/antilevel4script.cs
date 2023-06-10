using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antilevel4script : MonoBehaviour
{
    public GameObject magnetDown;
    private magnetDownRange magnetDownRange;

    // Start is called before the first frame update
    void Start()
    {
        magnetDownRange = magnetDown.GetComponent<magnetDownRange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (magnetDownRange.valid1 == true)
        {
            this.transform.Translate(-0.5f, 0.25f, 0f);
        }
        else if (magnetDownRange.valid2 == true)
        {
            this.transform.Translate(0.5f, -0.25f, 0f);
        }
    }
}
