using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    bool inBubble = false; // detection time in bubble
    bool onBubbleEnter = false; // detection of the enter
    bool onBubbleExplosion = false; // detection of the explosion
    bool explosionSound = false; // only one play

    [SerializeField] GameObject Candy;
    Vector3 repositioning = Vector3.down * 0.45f; // position the bubble on the center of the candy
    float force = 0.02f; // force added on the candy during time
    Vector2 newVelocityCandy = Vector2.zero; // velocity updated each frame

    AudioSource[] audioBubble;

    public bool InBubble
    {
        get
        {
            return inBubble;
        }

        set
        {
            inBubble = value;
        }
    }


    // Use this for initialization
    void Start()
    {
        audioBubble = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // When candy is in the bubble
        if (InBubble == true)
        {
            newVelocityCandy.x *= 0.99f; // reduction of velocity on x each frame

            Candy.GetComponent<Rigidbody2D>().velocity = newVelocityCandy; // update of velocity
            newVelocityCandy.y = Mathf.Clamp(newVelocityCandy.y + force, 0.0f, 5.0f); // clamp the velocity on y axis
        }
        //When bubble explodes
        else if (onBubbleEnter == true && onBubbleExplosion == false)
        {
            Candy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Physics2D.gravity = new Vector2(0, -9.81f);
            onBubbleExplosion = true; // to enter only one time in this condition
            gameObject.GetComponent<CircleCollider2D>().enabled = false; // desactivate collider onExplosion to evitate another EnterCollision with Candy
            transform.parent = null; // detach bubble from Candy to keep the animation on the good place
        }
        if (onBubbleExplosion == true && explosionSound == false)
        {
            audioBubble[1].enabled = true;
            audioBubble[1].Play();
            explosionSound = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Candy")
        {
            onBubbleEnter = true;
            InBubble = true;
            transform.position = collision.transform.position + repositioning;
            transform.parent = collision.transform; // attach bubble to the candy
            newVelocityCandy = new Vector2(Candy.GetComponent<Rigidbody2D>().velocity.x, Candy.GetComponent<Rigidbody2D>().velocity.y);
            Physics2D.gravity = new Vector2(0, 0f); // cancel the gravity to have only the bubble force applicated on the candy
            audioBubble[0].enabled = true;
            audioBubble[0].Play();
        }
    }
}
