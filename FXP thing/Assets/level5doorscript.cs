using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level5doorscript : MonoBehaviour
{
    public GameObject metalBlock;

    public GameObject antiMetal;

    

    public bool pass;

    // Start is called before the first frame update
    void Start()
    {
        
        pass = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (metalBlock.transform.position.x == 1f && metalBlock.transform.position.y == 0.5f)
        {
            if (antiMetal.transform.position.x == -2.5f && antiMetal.transform.position.y == 0.25f)
            {
                if (pass == true)
                {
                    SceneManager.LoadScene("level6");
                }
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

