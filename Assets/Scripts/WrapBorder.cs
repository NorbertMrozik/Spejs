using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapBorder : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            this.transform.position += (Vector3)other.GetComponent<Border>().pos;
        }
    }

}
