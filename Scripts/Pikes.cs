using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pikes : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Candy")
        {
            collision.gameObject.GetComponent<Candy>().DestroyCandy();
        }
        if(collision.tag == "Bubble")
        {
            collision.gameObject.GetComponent<Bubble>().InBubble = false; // reverse physics on Candy
            collision.gameObject.GetComponent<Animator>().SetBool("onExplosion", true); // change animation and Destroy Bubble gameObject at the end of the animation
        }
    }
}
