using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiDePlayerController : MonoBehaviour {

    private Animator anim;

    public float coolDown;
    public float activeTime;
    private float nextPunch;

    public GameObject fist;
    public Transform fistSpawn;

	void Start ()
    {
        anim = GetComponent<Animator>();
        nextPunch = 0;
	}
	
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.J) && (Time.time > nextPunch))
        {
            Debug.Log("Punching");
            anim.SetTrigger("punched");
            Destroy(Instantiate(fist, fistSpawn.position, fistSpawn.rotation), activeTime);
            nextPunch = Time.time + coolDown;
        }

        else if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Cooling down");
        }
	}
}
