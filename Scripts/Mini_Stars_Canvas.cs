using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini_Stars_Canvas : MonoBehaviour {

    Player player;
    [SerializeField] GameObject StarCanvas1;
    [SerializeField] GameObject StarCanvas2;
    [SerializeField] GameObject StarCanvas3;

    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(player.NbStars == 1)
        {
            StarCanvas1.SetActive(true);
        }
        if (player.NbStars == 2)
        {
            StarCanvas1.SetActive(true);
            StarCanvas2.SetActive(true);
        }
        if (player.NbStars == 3)
        {
            StarCanvas1.SetActive(true);
            StarCanvas2.SetActive(true);
            StarCanvas3.SetActive(true);
        }
    }
}
