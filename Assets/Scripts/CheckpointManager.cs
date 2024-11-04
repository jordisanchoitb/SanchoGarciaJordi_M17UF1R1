using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (GameManager.gameManager.levelActivateCheckpoint.Contains(SceneManager.GetActiveScene().buildIndex))
        {
            anim.SetBool("IsActivated", true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!GameManager.gameManager.levelActivateCheckpoint.Contains(SceneManager.GetActiveScene().buildIndex))
            {
                GameManager.gameManager.levelActivateCheckpoint.Add(SceneManager.GetActiveScene().buildIndex);
                GameManager.gameManager.SetCurrentSpawnpoint(collision.transform.position);
                GameManager.gameManager.SetCurrentSpawnpointLevel(SceneManager.GetActiveScene().buildIndex);
                anim.SetBool("IsActivated", true);
            }
        }
    }
}
