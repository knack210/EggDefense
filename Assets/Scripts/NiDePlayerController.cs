using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiDePlayerController : MonoBehaviour {

    private Animator anim;
    private AudioSource grunt;
    private bool control;

    public float coolDown;
    public float activeTime;
    private float nextPunch;

    public GameObject fist;
    public Transform fistSpawn;

	void Start ()
    {
        control = false;
        anim = GetComponent<Animator>();
        grunt = GetComponent<AudioSource>();
        nextPunch = 0;
	}
	
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.J) && (Time.time > nextPunch) && control)
        {
            Debug.Log("Punching");
            anim.SetTrigger("punched");
            grunt.Play();
            Destroy(Instantiate(fist, fistSpawn.position, fistSpawn.rotation), activeTime);
            nextPunch = Time.time + coolDown;
        }

        else if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Cooling down");
        }
	}

    public void setControl(bool controlValue)
    {
        control = controlValue;
    }
}
