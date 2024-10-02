using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isGrounded;
    private bool isIdle;
    void Start()
    {
        isGrounded = false;
        isIdle = true;
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(2f, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-2f, 0) * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            this.GetComponent<Rigidbody2D>().gravityScale *= -1;

        }

    }
}
