using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EarthShop : MonoBehaviour
{
    public SpaceShip spaceShip;
    public PlayerMovement playerMovement;
    public GameManager gameManager;

    [Space]
    public float fuelUpCost = 25f;
    public TextMeshProUGUI fuelUpCostText;
    // Start is called before the first frame update
    void Start()
    {
        spaceShip = GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceShip>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void BuyHPBattery()
    {
        if (gameManager.score >= 5 && spaceShip.hp < 100)
        {
            gameManager.score -= 5;
            spaceShip.hp += 20;
        }
    }

    public void FuelUpgrade()
    {
        if (gameManager.score >= fuelUpCost)
        {
            gameManager.score -= (int)fuelUpCost;
            playerMovement.maximumFuelCanisters++;
            fuelUpCost += 25f;
            fuelUpCostText.text = "Cost: " + fuelUpCost.ToString() + "Sp";
        }
    }

}
