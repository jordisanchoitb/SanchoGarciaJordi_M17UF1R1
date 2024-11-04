using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    private float speed = 2f;
    private bool moveRight = true;
    private Coroutine moveCoroutine;
    private BoxCollider2D collider2D;
    private RaycastHit2D hitGround, hitSpike;

    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        moveCoroutine = StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        hitGround = Physics2D.Raycast(transform.position - new Vector3(0, collider2D.size.y * 2, 0), Vector2.right, 1.5f);
        Debug.DrawRay(transform.position - new Vector3(0, collider2D.size.y * 2, 0), Vector2.right * 1.5f, Color.red);

        hitSpike = Physics2D.Raycast(transform.position - new Vector3(0, collider2D.size.y * 2, 0), Vector2.left, 1.2f);
        Debug.DrawRay(transform.position - new Vector3(0, collider2D.size.y *2, 0), Vector2.left * 1.2f, Color.green);

    }

    private IEnumerator Move()
    {
        while (true)
        {

            if (moveRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, Vector3.left * 16f, speed * Time.deltaTime);
                if (hitSpike.collider != null)
                {
                    if (hitSpike.collider.CompareTag("Spike"))
                    {
                        transform.eulerAngles = new Vector3(0, 180, 0);
                        moveRight = false;
                    }
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, Vector3.right * 16f, speed * Time.deltaTime);
                if (hitGround.collider != null)
                {
                    if (hitGround.collider.CompareTag("Ground"))
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        moveRight = true;
                    }
                }
                
            }
            yield return null;
        }
    }
}
