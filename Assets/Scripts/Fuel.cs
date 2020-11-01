using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{

    PlayerMovement pMove;
    public RectTransform fuelPos;

    private void Start()
    {
        pMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        fuelPos.anchoredPosition = new Vector3(0, -100 + pMove.fuelAmount, 0);
    }
}
