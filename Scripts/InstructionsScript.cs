using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsScript : MonoBehaviour {

    float timeLeft = 30;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("X") || Input.GetButtonDown("Circle") || Input.GetButtonDown("Square") || Input.GetButtonDown("Triangle")) {
            this.gameObject.SetActive(false);
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
