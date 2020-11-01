using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Earth : MonoBehaviour
{
    SpaceShip spaceShip;

    public GameObject earthPanel;
    public TextMeshProUGUI title;
    bool panelOpen = false;

    private void Start()
    {
        spaceShip = GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceShip>();
    }

    private void Update()
    {
        if (spaceShip.earthInRange == true && Input.GetKeyDown(KeyCode.E) && panelOpen == false)
        {
            earthPanel.SetActive(true);
            panelOpen = true;
        }
        if (spaceShip.earthInRange == true && Input.GetKeyDown(KeyCode.Escape) && panelOpen == true)
        {
            panelOpen = false;
            earthPanel.SetActive(false);
        }
    }

    public void GoBack()
    {
        earthPanel.SetActive(false);
        panelOpen = false;
    }
}
