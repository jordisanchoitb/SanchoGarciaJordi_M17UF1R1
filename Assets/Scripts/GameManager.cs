using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private Vector3 currentSpawnpoint;
    private int currentSpawnpointLevel;
    public List<int> levelActivateCheckpoint = new();

    public List<List<Vector3>> scenePositions = new List<List<Vector3>> 
    { 
        new List<Vector3> { new Vector3(0, 0), new Vector3(8.8f, -3.99f) },
        new List<Vector3> { new Vector3(-8.8f, -4.06f), new Vector3(8.8f, -4.06f) },
        new List<Vector3> { new Vector3(-8.8f, -4.06f), new Vector3(8.8f, -4.06f) },
        new List<Vector3> { new Vector3(-8.8f, -4.06f), new Vector3(8.8f, -4.06f) },
        new List<Vector3> { new Vector3(-8.8f, -4.06f), new Vector3(0, 0) }
    };

    private void Start()
    {
        if (GameManager.gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            GameManager.gameManager = this;
            this.currentSpawnpoint = GameObject.Find("Player").transform.position;
            this.currentSpawnpointLevel = 1;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCurrentSpawnpoint(Vector3 spawnpoint)
    {
        this.currentSpawnpoint = spawnpoint;
    }

    public Vector3 GetCurrentSpawnpoint()
    {
        return this.currentSpawnpoint;
    }

    public void SetCurrentSpawnpointLevel(int level)
    {
        this.currentSpawnpointLevel = level;
    }

    public int GetCurrentSpawnpointLevel()
    {
        return this.currentSpawnpointLevel;
    }
}
