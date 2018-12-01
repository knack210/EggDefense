using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiDeFireball : MonoBehaviour {

    public float speed;

	void Start ()
    {
		
	}
	
	void LateUpdate ()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
