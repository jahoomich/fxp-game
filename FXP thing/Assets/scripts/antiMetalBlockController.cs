using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antiMetalBlockController : MonoBehaviour
{
    public Vector3 startPosition;

    void Start() 
    {
        startPosition = this.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
