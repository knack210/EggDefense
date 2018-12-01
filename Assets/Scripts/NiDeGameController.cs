using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NiDeGameController : MonoBehaviour {
    
    public GameObject[] wizard;
    public GameObject player;
    public GameObject egg;
    public Transform fireSpawn;

    public Text logo;
    public Text startMessage;
    public Text scoreText;
    public Text endMessage;
    public int[] attacks;

    private AudioSource source;
    public AudioClip title;
    public AudioClip weakLaugh;
    public AudioClip strongLaugh;
    public AudioClip throwSound;
    public AudioClip bgm;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip bird;

    private Animator wizAnim;
    private Animator playerAnim;
    private Animator eggAnim;
    private NiDePlayerController playerController;

    private bool gameOver;
    private int score;
    

	// Use this for initialization
	void Start ()
    {
        gameOver = false;
        score = 0;
        scoreText.text = "";
        endMessage.text = "";

        wizAnim = wizard[0].GetComponent<Animator>();
        playerAnim = player.GetComponent<Animator>();
        eggAnim = egg.GetComponent<Animator>();

        playerController = player.GetComponent<NiDePlayerController>();

        source = GetComponent<AudioSource>();

        source.PlayOneShot(title);
        Destroy(logo, 1.5f);
        Destroy(startMessage, 1.5f);
        StartCoroutine(GameFlow());
	}
	
    IEnumerator GameFlow()
    {
        yield return new WaitForSeconds(1.5f);
        playerController.setControl(true);
        UpdateScore();
        source.PlayOneShot(bgm);
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < attacks.Length; i++)
        {
            if (attacks[i] == 0) StartCoroutine(WeakAttack());
            else if (attacks[i] == 1) StartCoroutine(StrongAttack());

            yield return new WaitForSeconds(4);
            if (gameOver) break;
            
        }

        source.Stop();
        playerController.setControl(false);

        if (gameOver)
        {
            source.PlayOneShot(lose);
            playerAnim.SetTrigger("lose");
            wizAnim.SetTrigger("Lose");
        }

        else
        {
            source.PlayOneShot(win);
            source.PlayOneShot(bird);
            eggAnim.SetTrigger("win");
            playerAnim.SetTrigger("win");
            wizAnim.SetTrigger("Win");
        }

    }

    IEnumerator WeakAttack()
    {
        source.PlayOneShot(weakLaugh);
        wizAnim.SetTrigger("Weak");
        yield return new WaitForSeconds(1);
        source.PlayOneShot(throwSound);
        Instantiate(wizard[1], fireSpawn.position, fireSpawn.rotation);
    }

    IEnumerator StrongAttack()
    {
        source.PlayOneShot(strongLaugh);
        wizAnim.SetTrigger("Strong");
        yield return new WaitForSeconds(2);
        source.PlayOneShot(throwSound);
        Instantiate(wizard[2], fireSpawn.position, fireSpawn.rotation);
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
       gameOver = true;
    }
}
