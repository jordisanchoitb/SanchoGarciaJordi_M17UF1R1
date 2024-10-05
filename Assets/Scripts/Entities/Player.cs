using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float PLAYERSPEED = 2.5f;

    private bool isRunning;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        isRunning = false;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 0.2f);

        Debug.DrawRay(transform.position, transform.position - transform.up * 0.2f, Color.red);
        Debug.Log(hit.collider.gameObject.name);

        if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            Debug.Log(hit.collider.gameObject.layer);*/

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-PLAYERSPEED, 0) * Time.deltaTime;
            spriteRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(PLAYERSPEED, 0) * Time.deltaTime;
            spriteRenderer.flipX = false;
        }


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            isRunning = true;
            animator.SetBool("isRunning", isRunning);
        }
        else
        {
            isRunning = false;
            animator.SetBool("isRunning", isRunning);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody2D>().gravityScale *= -1;
            if (spriteRenderer.flipY)
                spriteRenderer.flipY = false;
            else
                spriteRenderer.flipY = true;
        }

    }
}
