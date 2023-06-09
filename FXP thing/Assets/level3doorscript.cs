using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level3doorscript : MonoBehaviour
{
    public GameObject metalBlock;

   

    public Vector3 desiredPosition;

    [SerializeField] public Vector3 positionInput;

    // Start is called before the first frame update
    void Start()
    {
        desiredPosition = positionInput;
    }

    // Update is called once per frame
    void Update()
    {
        if (metalBlock.transform.position == desiredPosition && metalBlock.GetComponent<SpriteRenderer>().enabled == true)
        {
            SceneManager.LoadScene("level4");
        }
    }
}
