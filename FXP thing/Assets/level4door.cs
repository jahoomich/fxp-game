using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level4door : MonoBehaviour
{

    public GameObject metalBlock;
    
    

    public bool pass;

   
    // Start is called before the first frame update
    void Start()
    {
        pass = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (metalBlock.transform.position.x == 0.5f && metalBlock.transform.position.y == -1.75f)
        {
            if (pass == true)
            {
                SceneManager.LoadScene("level5");
   
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            pass = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            pass = false;
        }
    }
}
