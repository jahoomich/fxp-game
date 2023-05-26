using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tileMove : MonoBehaviour
{

    [SerializeField] public Tilemap tilemap;
    [SerializeField] public Vector3Int position;
    Matrix4x4 matrix = Matrix4x4.Translate(new Vector3(0.5f,0.29f,0f));
    //public bool click;
    private int number;
    private int x;
    private int y;


    // Start is called before the first frame update
    void Start()
    {
        number = 0;
        //x = System.Convert.ToInt32(0.5);
        //y = System.Convert.ToInt32(0.29);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && number < 3)
        {
            tilemap.SetTransformMatrix(position,matrix);
            tilemap.SetTransformMatrix(new Vector3Int(3,2,0), matrix);
            //position.x = position.x + 1;
            //position.y = position.y + y;
            //number = number + 1;
            //Debug.Log(number);
        }
        
    }
}
