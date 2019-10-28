using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour {

    float speed = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
