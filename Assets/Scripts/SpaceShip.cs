using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public Animator anim;

    public float hp;
    private float collisionCD = Mathf.FloorToInt(3 % 60);
    bool cdActive = false;
    bool astroCollision = false;
    [HideInInspector]
    public bool earthInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
    }

    private void Update()
    {

        if (astroCollision == true && collisionCD == Mathf.FloorToInt(3 % 60))
        {
            hp -= 20;
            anim.SetTrigger("playerHit");
            cdActive = true;
        }

        if (cdActive)
        {
            collisionCD -= Time.deltaTime;
            if (collisionCD <= 0)
            {
                cdActive = false;
                collisionCD = Mathf.FloorToInt(3 % 60);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Asteroid"))
        {
            astroCollision = true;
        }
        if(other.gameObject.name == "Earth")
        {
            earthInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Asteroid"))
        {
            astroCollision = false;
        }
        if (other.gameObject.name == "Earth")
        {
            earthInRange = false;
        }
    }

    private void LateUpdate()
    {
        if (hp >= 100)
        {
            hp = 100;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

}
