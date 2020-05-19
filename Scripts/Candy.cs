using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    [SerializeField] LoadLevel resetButton;


    bool eat = false; // to not change gameObject when eating

    [SerializeField] GameObject Candy_Broken;

    public bool Eat
    {
        get
        {
            return eat;
        }

        set
        {
            eat = value;
        }
    }

    private void Update()
    {
        if(transform.position.y < -10.0f || transform.position.y > 10.0f || transform.position.x < -10.0f || transform.position.x > 10.0f)
        {
            resetButton.LoadLvl();
        }
    }


    public void DestroyCandy()
    {
        if (eat == false)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).transform.parent = null;
            }
        }

        GameObject candy_broken = Instantiate(Candy_Broken, null);
        candy_broken.transform.position = transform.position;
        candy_broken.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
        candy_broken.GetComponent<AudioSource>().enabled = true;
        candy_broken.GetComponent<AudioSource>().Play();
        Destroy(candy_broken, 4.0f);
        Destroy(gameObject);

    }
}
