using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NiDeGameController : MonoBehaviour {
    
    public GameObject[] wizard;
    public Transform fireSpawn;
    public float throwTime;

    public Text logo;
    public Text startMessage;
    public int[] attacks;

    private Animator wizAnim;
    private bool gameOver;
    private bool victory;
    private int score;

	// Use this for initialization
	void Start ()
    {
        gameOver = false;
        victory = false;
        score = 0;
        wizAnim = wizard[0].GetComponent<Animator>();
        Destroy(logo, 2);
        Destroy(startMessage, 2);
        StartCoroutine(GameFlow());
	}
	
    IEnumerator GameFlow()
    {
        yield return new WaitForSeconds(2.5f);
        
        for (int i = 0; i < attacks.Length; i++)
        {
            if (attacks[i] == 0) StartCoroutine(WeakAttack());
            //else if (attacks[i] == 1) StartCoroutine(StrongAttack());
            yield return new WaitForSeconds(2);
        }

    }

    IEnumerator WeakAttack()
    {
        wizAnim.SetTrigger("Weak");
        yield return new WaitForSeconds(1);
        Instantiate(wizard[1], fireSpawn.position, fireSpawn.rotation);
    }

    public void GameOver()
    {
       if (!victory) gameOver = true;
    }

    public void Victory()
    {
        if (!gameOver) victory = true;
    }
}
