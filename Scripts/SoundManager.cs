using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

    [SerializeField] AudioMixer audioMixer;
    [Header("CLIPS =======================")]
    [SerializeField] AudioClip menuAmbientMusic;
    [SerializeField] AudioClip levelAmbientMusic;

    static SoundManager instance = null;


    AudioSource audioSource;

    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        getClip();
        audioMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume_value", 0));
        audioMixer.SetFloat("AmbientVolume", PlayerPrefs.GetFloat("AmbientVolume_value", 0));
        audioMixer.SetFloat("EffectsVolume", PlayerPrefs.GetFloat("EffectsVolume_value", 0));

        if(SceneManager.GetActiveScene().buildIndex != 12)
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                instance.transform.position = transform.position;
                instance.transform.rotation = transform.rotation;
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        getClip();
    }

    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("MasterVolume", value);
        PlayerPrefs.SetFloat("MasterVolume_value", value);
        Debug.Log("load slider global " + PlayerPrefs.GetFloat("MasterVolume_value", 0));
    }

    public void SetAmbientVolume(float value)
    {
        audioMixer.SetFloat("AmbientVolume", value);
        PlayerPrefs.SetFloat("AmbientVolume_value", value);
    }

    public void SetEffectsVolume(float value)
    {
        audioMixer.SetFloat("EffectsVolume", value);
        PlayerPrefs.SetFloat("EffectsVolume_value", value);
        Debug.Log("load slider effects" + PlayerPrefs.GetFloat("EffectsVolume_value", 0));
    }

    private void getClip()
    {
        if (SceneManager.GetActiveScene().buildIndex >=1 && SceneManager.GetActiveScene().buildIndex <= 10)
        {
            if (audioSource.clip != levelAmbientMusic)
            {
                audioSource.clip = levelAmbientMusic;
                audioSource.Play();
            }
        }
        else if ((SceneManager.GetActiveScene().buildIndex==0 || SceneManager.GetActiveScene().buildIndex==11) &&  audioSource.clip != menuAmbientMusic)
        {
                audioSource.clip = menuAmbientMusic;
                audioSource.Play();
        }
    }
}
