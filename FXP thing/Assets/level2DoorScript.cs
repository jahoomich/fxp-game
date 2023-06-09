using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class level2DoorScript : MonoBehaviour
{
    public GameObject teslaCoil;
    private coilControl coilControl;

    public bool passCondition;

    // Start is called before the first frame update
    void Start()
    {
        passCondition = false;
        coilControl = teslaCoil.GetComponent<coilControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coilControl.checkRange() == false && passCondition == true)
        {
            SceneManager.LoadScene("level3");
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            passCondition = true;
        }    
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            passCondition = false;
        }    
    }
}
