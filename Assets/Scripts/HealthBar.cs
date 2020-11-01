using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public Sprite[] hearts;
    public UnityEngine.UI.Image healthImage;
    public SpaceShip spaceShip;
    private float hp;

    // Start is called before the first frame update
    void Start()
    {
        spaceShip = GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceShip>();
        healthImage = this.gameObject.GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spaceShip.hp == 100)
        {
            healthImage.sprite = hearts[0];
        }
        if (spaceShip.hp == 80)
        {
            healthImage.sprite = hearts[1];
        }
        if (spaceShip.hp == 60)
        {
            healthImage.sprite = hearts[2];
        }
        if (spaceShip.hp == 40)
        {
            healthImage.sprite = hearts[3];
        }
        if (spaceShip.hp == 20)
        {
            healthImage.sprite = hearts[4];
        }
        if (spaceShip.hp == 0)
        {
            healthImage.sprite = hearts[5];
        }
    }
}
