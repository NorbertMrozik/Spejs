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

    [Space]
    public GameObject minimap;
    public GameObject sectorText;
    bool panelOpen = false;
    [HideInInspector]
    public bool playerInRange = false;

    private void Start()
    {
        spaceShip = GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceShip>();
    }

    

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && panelOpen == false)
        {
            planetPanel.SetActive(true);
            minimap.SetActive(false);
            sectorText.SetActive(false);
            panelOpen = true;
            Time.timeScale = 0f;
        }
        else if (playerInRange && Input.GetKeyDown(KeyCode.Escape) && panelOpen == true)
        {
            panelOpen = false;
            planetPanel.SetActive(false);
            shopPanel.SetActive(false);
            questsPanel.SetActive(false);
            minimap.SetActive(true);
            sectorText.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    public void GoBack()
    {
        planetPanel.SetActive(false);
        minimap.SetActive(true);
        sectorText.SetActive(true);
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
