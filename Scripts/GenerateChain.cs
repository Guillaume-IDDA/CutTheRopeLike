using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChain : MonoBehaviour {

    [SerializeField] GameObject prefabMaillon;
    GameObject lastMaillon, newMaillon;

    //int nbMaillons=10;
    Vector3 directionChainCreated; // direction of the chain from gameObject to candy
    Vector3 directionChainCreatedNormalized; // direction normalized
    float lengthChain; // the length of the rope
    float posMaillon = 0.2f; // position of the anchor, of the hinge Joint, from the center of the object
    [SerializeField] int nbMaillons =1; // number of maillons (link) if not automatic generation
    [SerializeField] bool automaticMaillons = true; // number of maillons (link) minimum necessary to create the rope



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


        if (collision.gameObject.tag == "Candy")
        {
            // Creation of the empty gameObject "rope"
            GameObject rope = new GameObject("@rope");
            rope.transform.position = new Vector2(0, 0);

            directionChainCreated = collision.transform.position - gameObject.transform.position;
            lengthChain = directionChainCreated.magnitude;
            directionChainCreatedNormalized = (collision.transform.position - gameObject.transform.position).normalized;

            //generate the number of maillons (link) minimum necessary to create the rope
            if (automaticMaillons == true)
            {
                for (int i = 0; i < (int)(lengthChain / posMaillon) + 1; i++)
                {
                    if (i == 0)
                    {
                        // Creation of the first maillon (link)
                        newMaillon = Instantiate(prefabMaillon, transform.position, transform.rotation); // Place the first maillon at the position of gameobject
                    }
                    else if (i > 0)
                    {
                        // Instantiate a new maillon and joint it to the before maillon
                        newMaillon = Instantiate(prefabMaillon, lastMaillon.transform.position + directionChainCreatedNormalized * 0.2f, lastMaillon.transform.rotation);
                        newMaillon.GetComponent<HingeJoint2D>().connectedBody = lastMaillon.GetComponent<Rigidbody2D>();
                    }
                    if (i == (int)(lengthChain / posMaillon))
                    {
                        // joint the candy to the last maillon
                        HingeJoint2D tmp = collision.gameObject.AddComponent<HingeJoint2D>();
                        tmp.connectedBody = newMaillon.GetComponent<Rigidbody2D>();
                    }

                    newMaillon.transform.parent = rope.transform;
                    lastMaillon = newMaillon;
                }
            }
            else // same than the automatic method but with a number of maillon (link) defined
            {
                for (int i = 0; i < nbMaillons + 1; i++)
                {
                    if (i == 0)
                    {
                        newMaillon = Instantiate(prefabMaillon, transform.position, transform.rotation);
                    }
                    else if (i > 0)
                    {
                        newMaillon = Instantiate(prefabMaillon, lastMaillon.transform.position + directionChainCreatedNormalized * 0.2f, lastMaillon.transform.rotation);
                        newMaillon.GetComponent<HingeJoint2D>().connectedBody = lastMaillon.GetComponent<Rigidbody2D>();
                    }
                    if (i == nbMaillons)
                    {
                        HingeJoint2D tmp = collision.gameObject.AddComponent<HingeJoint2D>();
                        tmp.connectedBody = newMaillon.GetComponent<Rigidbody2D>();
                    }

                    newMaillon.transform.parent = rope.transform;
                    lastMaillon = newMaillon;
                }
            }       
            Destroy(this); // destroy the script to stop the generation and create only one rope
        }
    }
}
