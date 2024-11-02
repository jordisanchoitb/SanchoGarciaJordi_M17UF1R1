using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    [SerializeField] private GameObject startMove, endMove;
    private float speed = 2f;
    private bool moveRight = true;
    private Coroutine moveCoroutine;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveCoroutine = StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Move()
    {
        while (true)
        {
            if (moveRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, endMove.transform.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startMove.transform.position, speed * Time.deltaTime);
            }
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EndMove")
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            moveRight = false;
        }

        if (collision.gameObject.name == "StartMove")
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            moveRight = true;
        }

    }
}
