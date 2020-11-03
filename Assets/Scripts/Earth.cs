using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Earth : MonoBehaviour
{
    SpaceShip spaceShip;

    public GameObject planetPanel;
    public GameObject shopPanel;
    public GameObject questsPanel;
    bool panelOpen = false;

    private void Start()
    {
        spaceShip = GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceShip>();
    }

    private void Update()
    {
        if (spaceShip.earthInRange == true && Input.GetKeyDown(KeyCode.E) && panelOpen == false)
        {
            planetPanel.SetActive(true);
            panelOpen = true;
            Time.timeScale = 0f;
        }
        if (spaceShip.earthInRange == true && Input.GetKeyDown(KeyCode.Escape) && panelOpen == true)
        {
            panelOpen = false;
            planetPanel.SetActive(false);
            shopPanel.SetActive(false);
            questsPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void GoBack()
    {
        planetPanel.SetActive(false);
        panelOpen = false;
        Time.timeScale = 1f;
    }

    public void EnterShop()
    {
        shopPanel.SetActive(true);
    }

    public void LeaveShop()
    {
        shopPanel.SetActive(false);
    }

    public void EnterQuests()
    {
        questsPanel.SetActive(true);
    }
    
    public void LeaveQuests()
    {
        questsPanel.SetActive(false);
    }
}
