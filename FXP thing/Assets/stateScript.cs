using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class stateScript : MonoBehaviour
{
    public TextMeshProUGUI textElement;
    public GameObject player;
    private playerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        playerState = player.GetComponent<playerState>();
        textElement.text = "State = neutral";
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState.isPositive == true)
        {
            textElement.text = "State = Positive";
        }
        else if (playerState.isNegative == true)
        {
            textElement.text = "State = Negative";
        }
    }
}
