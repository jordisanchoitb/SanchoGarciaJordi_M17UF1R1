using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float speed;
    [SerializeField] private bool shotLeft;
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        SetVelocityCannonBall(this.shotLeft);
    }

    public void SetVelocityCannonBall(bool shotLeft)
    {
        if (shotLeft)
            rigidbody2D.velocity = new Vector2(-speed, 0);
        else
            rigidbody2D.velocity = new Vector2(speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SpawnCannonBall.spawner.Push(this.gameObject);
    }
}
