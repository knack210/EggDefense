using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiDeDestroyByContact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fist"))
        {
            Destroy(gameObject);
        }
    }
}
