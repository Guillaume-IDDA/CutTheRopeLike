using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour {

    float timeBeforeDestroy = 7.0f;
    float timeEatSong = 2.0f; //time song eating

    [SerializeField] Candy candy;
    [SerializeField] GameObject endMenuWindow;

    bool endLevel = false;
    float timer = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(endLevel == true)
        {
            timer += Time.deltaTime;
            if(timer > timeEatSong)
            {
                endMenuWindow.SetActive(true);
                GetComponent<Animator>().SetBool("EndAnim", true);
                Time.timeScale = 0f;
                Pause_Button.gameOnPause = true;
                timer = 0;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.tag == "Candy")
        {
            GetComponent<Animator>().SetBool("onEat", true);
            Destroy(obj.gameObject, Time.deltaTime * timeBeforeDestroy);
            candy.Eat = true;
            GetComponent<AudioSource>().enabled = true;
            GetComponent<AudioSource>().Play();
            endLevel = true;
        }
    }

}
