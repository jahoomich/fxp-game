using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    [SerializeField] public GameObject upper;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        upper.transform.Translate(0.3f,0.3f,0);
    }

    //void OnCollisionEnter2D(Collision2D other) 
    //{
        //if (other.gameObject.tag == "Player")
        //{
            //upper.transform.Translate(1,1,0);
        //}
    //}
}
