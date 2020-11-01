using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public ParticleSystem thrustEffect;
    

    float maxVelo = 3;

    public float rotationSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        if (yAxis > 0)
        {
            var thrustEm = thrustEffect.emission;
            thrustEm.enabled = true;
        }
        else
        {
            var thrustEm = thrustEffect.emission;
            thrustEm.enabled = false;
        }
        ThrustForward(yAxis);
        Rotate(transform, -xAxis * rotationSpeed);
    }

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelo, maxVelo);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelo, maxVelo);

        rb.velocity = new Vector2(x, y);
    }

    private void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount;
        rb.AddForce(force);
    }

    private void Rotate(Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }

}
