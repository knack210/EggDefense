using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiDeDestroyByContact : MonoBehaviour
{
    public int scoreValue;
    public GameObject explosion;
    private AudioSource source;
    private NiDeGameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<NiDeGameController>();
        }

        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fist"))
        {
            Destroy(Instantiate(explosion, transform.position, transform.rotation), 1);
            Destroy(gameObject);
            gameController.AddScore(scoreValue);
        }
    }
}
