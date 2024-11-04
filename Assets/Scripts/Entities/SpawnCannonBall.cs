using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCannonBall : MonoBehaviour
{
    public static SpawnCannonBall spawner;
    public GameObject canonBall;
    public GameObject canonBallSpawnPoint;
    private Stack<GameObject> canonBallPool;

    void Start()
    {
        if (SpawnCannonBall.spawner != null && SpawnCannonBall.spawner != this)
            Destroy(gameObject);
        SpawnCannonBall.spawner = this;
        canonBallPool = new Stack<GameObject>();
    }

    public void Push(GameObject canonBall)
    {
        canonBall.SetActive(false);
        canonBallPool.Push(canonBall);
    }

    public GameObject Pop()
    {
        GameObject obj = canonBallPool.Pop();
        obj.SetActive(true);
        obj.transform.position = canonBallSpawnPoint.transform.position;
        return obj;
    }

    public GameObject Peek()
    {
        return canonBallPool.Peek();
    }

    private void ShotBall()
    {
        if (canonBallPool.Count != 0)
        {
            this.Pop();
        }
        else
        {
            Instantiate(canonBall, canonBallSpawnPoint.transform.position, Quaternion.identity);
        }
    }

    private void SoundShotBall()
    {
        AudioManager.audioManager.PlaySoundEffectShotBall();
    }
}
