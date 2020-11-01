using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroSpawn : MonoBehaviour
{

    public Vector3 size;
    public Vector3 center;
    [Space]
    public int amountOfAstro;


    [HideInInspector]
    public Vector3 screenBounds;
    private Vector3 spawnBounds;


    public GameObject asteroid;

    // Start is called before the first frame update
    private void Start()
    {
        center = this.gameObject.transform.position;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        spawnBounds = size;
        for (int i=0; i<=amountOfAstro; i++)
        {
            StartCoroutine(countdown());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
          //  SpawnAsteroid();
    }


    IEnumerator countdown()
    {
        SpawnAsteroid();
        yield return new WaitForSeconds(30f);
        StartCoroutine(countdown());
    }

    void SpawnAsteroid()
    {
        Vector3 pos = center + new Vector3(Random.Range(-spawnBounds.x / 2, spawnBounds.x / 2), (Random.Range(-spawnBounds.y / 2, spawnBounds.y / 2)), 1f);
        Instantiate(asteroid, pos, Quaternion.identity, this.transform);
        this.transform.parent = gameObject.transform;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size);
    }

}
