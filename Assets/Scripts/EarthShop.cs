using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthShop : MonoBehaviour
{
    public SpaceShip spaceShip;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        spaceShip = GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceShip>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void BuyBattery()
    {
        if (gameManager.score > 5 && spaceShip.hp < 100)
        {
            gameManager.score -= 5;
            spaceShip.hp += 20;
        }
    }

}
