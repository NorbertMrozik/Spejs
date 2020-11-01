using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D rb;
    float timer;

    public int damage = 25;
    public float speed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= 2f)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Asteroid"))
        {
            Asteroid asteroid = hitInfo.GetComponent<Asteroid>();
            if (asteroid != null)
                asteroid.TakeDamage(damage);
            Destroy(this.gameObject);
        }

    }

}
