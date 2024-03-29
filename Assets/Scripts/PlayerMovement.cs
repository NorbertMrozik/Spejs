﻿using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public ParticleSystem thrustEffect;

    public float forwardSpeed;
    public float boostSpeed;
    public TextMeshProUGUI canistersAmount;
    public float maximumFuelCanisters;
    public float fuelCanisters = 1;
    public float fuelAmount;
    private float initialSpeed;
    bool fueldrain = false;
    
    float maxVelo = 3;

    public float rotationSpeed;

    float timer;
    float fuelRefill = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialSpeed = forwardSpeed;
        maximumFuelCanisters = fuelCanisters;
    }


    void Update()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        float boost = Input.GetAxis("Boost");

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

        if (boost > 0 && fuelCanisters > 0)
        {
            var boostEm = thrustEffect.colorOverLifetime;
            boostEm.enabled = true;
            forwardSpeed = boostSpeed;
            fuelAmount -= 0.1f;
            fueldrain = true;
            if (fuelAmount <= 0 && fuelCanisters > 0)
            {
                fuelCanisters--;
                fuelAmount = 100;
                if (fuelCanisters == 0)
                    fuelAmount = 0;
            }
        }
        else
        {
            var boostEm = thrustEffect.colorOverLifetime;
            boostEm.enabled = false;
            forwardSpeed = initialSpeed;
            fueldrain = false;
        }
        if (fuelAmount < 100)
            RefillFuel();
        canistersAmount.text = "x" + fuelCanisters.ToString();
    }


    private void RefillFuel()
    {
        timer += Time.deltaTime;
        if (timer >= fuelRefill && fueldrain == false)
        {
            fuelAmount += 3f;
            timer = 0;
            if (fuelCanisters == 0)
                fuelCanisters++;
            if (fuelCanisters < maximumFuelCanisters && fuelAmount >= 100)
            {
                fuelCanisters++;
                fuelAmount = 0;
            }    
        }
    }

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelo, maxVelo);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelo, maxVelo);

        rb.velocity = new Vector2(x, y);
    }

    private void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount * forwardSpeed;
        rb.AddForce(force);
    }

    private void Rotate(Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }

    private void LateUpdate()
    {
        if (fuelAmount < 0)
            fuelAmount = 0;
        if (fuelAmount > 100)
            fuelAmount = 100;
    }
}
