using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int score = 0;
    public TextMeshProUGUI[] scoreText;


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < scoreText.Length; i++)
            scoreText[i].text = score.ToString();
    }

}
