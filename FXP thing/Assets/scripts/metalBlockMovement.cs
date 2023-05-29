using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metalBlockMovement : MonoBehaviour
{
    public GameObject metalBlock;
    [SerializeField] public Vector3 blockPosition;
    public float moveSpeed;

    public void moveLeft()
    {
        metalBlock.transform.Translate((-0.5f * moveSpeed), (-0.25f * moveSpeed), 0f);
    }

    public void moveDown()
    {
        metalBlock.transform.Translate((0.5f * moveSpeed), (-0.25f * moveSpeed), 0f);
    }

    public void moveRight()
    {
        metalBlock.transform.Translate((0.5f * moveSpeed), (0.25f * moveSpeed), 0f);
    }

    public void moveUp()
    {
        metalBlock.transform.Translate((-0.5f * moveSpeed), (0.25f * moveSpeed), 0f);
    }
    
    public void Start()
    {
        moveSpeed = 0.01f;
        metalBlock.transform.position = blockPosition;
    }

    void Update() 
    {
        
    }

    
}
