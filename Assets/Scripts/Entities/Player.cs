using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player player;
    public static bool IsPaused = false;

    private const float PLAYERSPEED = 4f;

    private bool isDead;
    private bool isRunning;
    private bool isJumping;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private RaycastHit2D currentraycastHit2D;
    private CapsuleCollider2D collider2D;

    private void Awake()
    {
        if (Player.player == null)
        {
            DontDestroyOnLoad(gameObject);
            Player.player = this;
            Time.timeScale = 1;
            IsPaused = false;

            isRunning = false;
            isJumping = false;
            isDead = false;

            collider2D = GetComponent<CapsuleCollider2D>();
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (IsPaused)
            return;

        currentraycastHit2D = Physics2D.Raycast(transform.position + new Vector3(0, collider2D.size.y*2, 0), Vector2.down, collider2D.size.y * 4);
        Debug.DrawRay(transform.position + new Vector3(0, collider2D.size.y*2, 0), Vector2.down * (collider2D.size.y * 4), Color.red);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            IsPaused = true;
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        }

        if (!isDead)
        {
            Move();
            InvertGravity();
        }
    }

    private void Move()
    {
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
    }
    private void InvertGravity()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentraycastHit2D.collider != null)
        {
            this.GetComponent<Rigidbody2D>().gravityScale *= -1;
            animator.SetBool("isJump", true);
            if (spriteRenderer.flipY)
                spriteRenderer.flipY = false;
            else
                spriteRenderer.flipY = true;
        }
    }
    public void ResetPlayer()
    {
        isDead = false;
        isJumping = false;
        isRunning = false;
        animator.SetBool("isHit", isDead);
        animator.SetBool("isJump", isJumping);
        animator.SetBool("isRunning", isRunning);

        Debug.Log(SceneManager.GetActiveScene().buildIndex);

        if (!IsSpawnpointInCurrentLevel())
            SceneManager.LoadScene(GameManager.gameManager.GetCurrentSpawnpointLevel());

        transform.position = GameManager.gameManager.GetCurrentSpawnpoint();
    }

    private bool IsSpawnpointInCurrentLevel()
    {
        return SceneManager.GetActiveScene().buildIndex == GameManager.gameManager.GetCurrentSpawnpointLevel();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Proyectile") || collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Enemy"))
        {
            isDead = true;
            animator.SetBool("isHit", isDead);
            AudioManager.audioManager.PlaySoundEffectDead();
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("isJump", isJumping);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "NextScene")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Player.player.transform.position = GameManager.gameManager.scenePositions[SceneManager.GetActiveScene().buildIndex][0];
        }
        
        if ( collision.gameObject.name == "AboveScene")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Player.player.transform.position = GameManager.gameManager.scenePositions[SceneManager.GetActiveScene().buildIndex-2][1];
        }
    }
}
