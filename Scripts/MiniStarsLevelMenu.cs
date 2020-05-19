using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniStarsLevelMenu : MonoBehaviour {

    [SerializeField] int nbStarDisplay;
    [SerializeField] int numLevel;

	// Use this for initialization
	void Start ()
    {
		if(DataController.LoadPlayerProgressStars(numLevel) == nbStarDisplay)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
	}
}
