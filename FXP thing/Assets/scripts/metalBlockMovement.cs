using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metalBlockMovement : MonoBehaviour
{
    public GameObject metalBlock;
    [SerializeField] public Vector3 blockPosition;
    public float moveSpeed;

    void moveLeft()
    {
        metalBlock.transform.Translate((-0.5f * moveSpeed), (-0.25f * moveSpeed), 0f);
    }

    void moveDown()
    {
        metalBlock.transform.Translate((0.5f * moveSpeed), (-0.25f * moveSpeed), 0f);
    }

    void moveRight()
    {
        metalBlock.transform.Translate((0.5f * moveSpeed), (0.25f * moveSpeed), 0f);
    }

    void moveUp()
    {
        metalBlock.transform.Translate((-0.5f * moveSpeed), (0.25f * moveSpeed), 0f);
    }
    
    void Start()
    {
        moveSpeed = 0.01f;
        blockPosition = new Vector3 (1.5f, -0.75f, 0f);
        metalBlock.transform.position = blockPosition;
    }

    void Update() 
    {
        moveDown();
    }

    
}
