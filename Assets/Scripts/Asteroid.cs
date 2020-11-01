using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D rb;
    public GameManager gameManager;
    public Transform playerTransform;

    public float accelerationTime = 2f;
    public float maxSpeed = 5f;
    private Vector2 movement;
    private float timeLeft;

    private Vector3 scale;



    [Range(0, 1)]
    public float rMove = 0.2f;

    int health = 100;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();

        float randomFloat = Random.Range(0.3f, 1);
        scale = new Vector3(randomFloat, randomFloat, randomFloat);
        transform.localScale = scale;
    }


    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-rMove, rMove), Random.Range(-rMove, rMove));
            timeLeft += accelerationTime;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            gameManager.score++;
        }
    }

}
