using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hertzController : MonoBehaviour
{

    public TextMeshProUGUI hertz;

    public int hertzNum = 0;
    public int max = 5;
    public int min = 0;
    // Start is called before the first frame update
    void Start()
    {
        hertz.text = hertzNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        hertz.text = hertzNum.ToString();


        if (Input.GetKeyDown("3"))
        {
            Add();
        }
        else if (Input.GetKeyDown("4"))
        {
            Subtract();
        }
    }

    void Add()
    {
        if (hertzNum < max)
        {
            hertzNum++;
        }
    }

    void Subtract()
    {
        if (hertzNum > min)
        {
            hertzNum--;
        }
    }
}
