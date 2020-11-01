using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SectorCheck : MonoBehaviour
{

    public TextMeshProUGUI sectorText;

    /* 
     * Alternative: 
     * private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GameArea"))
        {
            sectorText.text = other.gameObject.name;
        }
    }
    */

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("GameArea"))
        {
            sectorText.text = other.gameObject.name;
        }
    }
}
