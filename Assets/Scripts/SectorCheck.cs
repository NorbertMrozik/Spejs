using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SectorCheck : MonoBehaviour
{

    public TextMeshProUGUI sectorText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GameArea"))
        {
            sectorText.text = other.gameObject.name;
        }
    }

}
