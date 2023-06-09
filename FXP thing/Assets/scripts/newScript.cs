using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newScript : MonoBehaviour
{
    public GameObject aAblock;
    private antiMetalBlockController antiMetalBlockController;

    public GameObject magnetUp;

    public GameObject metalBlock;

    private magnetUpRange magnetUpRange;

    public GameObject magnetLeft;
    private magnetLeftRange magnetLeftRange;

    // Start is called before the first frame update
    void Start()
    {
        magnetLeftRange = magnetLeft.GetComponent<magnetLeftRange>();
        magnetUpRange = magnetUp.GetComponent<magnetUpRange>();
        antiMetalBlockController = aAblock.GetComponent<antiMetalBlockController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (magnetUpRange.valid2 == true)
        {
            aAblock.transform.position = new Vector3(antiMetalBlockController.startPosition.x + 0.5f * magnetUpRange.hertzNumber, antiMetalBlockController.startPosition.y + 0.25f * magnetUpRange.hertzNumber, 0f);
        }
        else if (magnetUpRange.valid1 == true)
        {
            aAblock.transform.position = new Vector3((antiMetalBlockController.startPosition.x + 0.5f * magnetUpRange.hertzNumber) - 0.5f, (antiMetalBlockController.startPosition.y + 0.25f * magnetUpRange.hertzNumber) - 0.25f, 0f);
        }

        if (magnetLeftRange.isValid1 == true)
        {
            aAblock.transform.position = new Vector3(antiMetalBlockController.startPosition.x + 0.5f * magnetUpRange.hertzNumber, antiMetalBlockController.startPosition.y + 0.25f * magnetUpRange.hertzNumber, 0f);

        }
        else if (magnetLeftRange.isValid2 == true)
        {
            aAblock.transform.position = new Vector3(antiMetalBlockController.startPosition.x + 0.5f * magnetUpRange.hertzNumber, antiMetalBlockController.startPosition.y + 0.25f * magnetUpRange.hertzNumber, 0f);

        }
        
        if (metalBlock.transform.position == aAblock.transform.position)
        {
            metalBlock.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("Metal block has been destoyed");
        }
    } 
}
