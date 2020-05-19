using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Vector2 oldPos = new Vector2(-1.0f, -1.0f);
    Vector2 newPos = new Vector2(-1.0f, -1.0f);
    Vector2 direction;
    Vector2 cursorPos;
    TrailRenderer trail;
    float length;
    int count;
    int nbStars =0;


    [SerializeField] LayerMask maskCol;
    Bubble bubble;

    public int NbStars
    {
        get
        {
            return nbStars;
        }

        set
        {
            nbStars = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        DataController.player = this;
        Cursor.visible = false;
        trail = GetComponentInChildren<TrailRenderer>();
        trail.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Slice();
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        if(Input.GetMouseButtonUp(0))
        {
            trail.enabled = false;
        }
    }
    
    
    void Slice()
    {
        if(Pause_Button.gameOnPause == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                trail.enabled = true;
                oldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // Detection if click on Bubble
                RaycastHit2D hit = Physics2D.Raycast(oldPos, oldPos, length, maskCol);
                if (hit)
                {
                    GameObject target = hit.collider.gameObject;
                    if (target.tag == "Bubble")
                    {
                        bubble = target.GetComponent<Bubble>();
                        //Test if Candy is in the Bubble
                        if (target.transform.parent.tag == "Candy")
                        {
                            bubble.InBubble = false; // reverse physics on Candy
                            target.GetComponent<Animator>().SetBool("onExplosion", true); // change animation and Destroy Bubble gameObject at the end of the animation
                        }
                    }
                }
            }


            if (Input.GetButton("Fire1"))
            {
                newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // position of the click of mouse
                transform.position = newPos; // position of cursor

                Debug.DrawRay(oldPos, (newPos - oldPos), Color.red);

                direction = (newPos - oldPos).normalized; // sens of slice
                length = (newPos - oldPos).magnitude; //distance of slice

                //test collision between mouse slice and rope
                RaycastHit2D hit = Physics2D.Raycast(oldPos, direction, length, maskCol);
                if (hit)
                {
                    GameObject target = hit.collider.gameObject;
                    if (target.tag == "Maillon")
                    {
                        Destroy(target.transform.parent.gameObject); // Destroy all Maillon composing the rope
                    }
                }

                if (count > 10) // Contribute to the size of the slice 
                {
                    oldPos = newPos;
                    count = 0;
                }
                else
                {
                    count++;
                }
            }
        }       
    }
}
