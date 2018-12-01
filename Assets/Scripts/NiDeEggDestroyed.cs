using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiDeEggDestroyed : MonoBehaviour {

    private NiDeGameController gameController;
    private Animator eggAnim;
    private AudioSource sizzle;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<NiDeGameController>();
        }

        eggAnim = GetComponent<Animator>();
        sizzle = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            eggAnim.SetTrigger("lose");
            sizzle.Play();

            gameController.GameOver();
        }
    }
}
