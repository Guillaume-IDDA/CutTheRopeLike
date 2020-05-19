using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy_Broken : MonoBehaviour {


    LoadLevel resetButton;

    Vector3 rotation = new Vector3(0, 0, 10);

	// Use this for initialization
	void Start ()
    {
        resetButton = GameObject.FindObjectOfType<LoadLevel>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotation);
        if (transform.position.y < -10.0f || transform.position.y > 10.0f || transform.position.x < -10.0f || transform.position.x > 10.0f)
        {
            resetButton.LoadLvl();
        }
    }
}