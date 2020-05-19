using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    [SerializeField] SoundType type;
    Slider slider;
    public enum SoundType
    {
        Master, Ambient, Effects
    }

	// Use this for initialization
	void Start ()
    {
        slider = GetComponent<Slider>();

        switch (type)
        {
            case SoundType.Master:
                slider.value = PlayerPrefs.GetFloat("MasterVolume_value", 0);
                break;
            case SoundType.Ambient:
                slider.value = PlayerPrefs.GetFloat("AmbientVolume_value", 0);
                break;
            case SoundType.Effects:
                slider.value = PlayerPrefs.GetFloat("EffectsVolume_value", 0);
                break;
            default:
                break;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
