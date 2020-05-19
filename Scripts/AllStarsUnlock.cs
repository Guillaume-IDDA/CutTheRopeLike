using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllStarsUnlock : MonoBehaviour {

    [SerializeField] Text score;
    int nbTotalStars =0;


	// Use this for initialization
	void Start ()
    {

        for (int i = 1; i < 11; i++)
        {
            nbTotalStars += DataController.LoadPlayerProgressStars(i);
        }

        score.text = nbTotalStars + " / 30";

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
