using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI[] scoreText;

    public GameObject map;
    bool mapOpen = false;


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < scoreText.Length; i++)
            scoreText[i].text = score.ToString() + " "+ "Sp";

        if (Input.GetKeyDown(KeyCode.M) && mapOpen == false)
        {
            Time.timeScale = 0f;
            map.SetActive(true);
            mapOpen = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && mapOpen == true)
        {
            Time.timeScale = 1f;
            mapOpen = false;
            map.SetActive(false);
        }

    }

}
