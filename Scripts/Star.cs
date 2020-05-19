using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    Player Player;
    private void Start()
    {
        Player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if(collision.gameObject.tag == "Candy")
            {
                GetComponent<Animator>().SetBool("onExplosion", true);
                GetComponent<AudioSource>().enabled = true;
                GetComponent<AudioSource>().Play();
            Player.NbStars++;
        }
    }
}