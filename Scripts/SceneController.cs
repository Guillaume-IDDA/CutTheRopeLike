using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

    [SerializeField] Slider GlobalSlider;
    [SerializeField] Slider AmbientSlider;
    [SerializeField] Slider EffectsSlider;

    public void SaveStars()
    {
        DataController.SavePlayerProgress();
    }

    public void ResetGame()
    {
        DataController.ResetGame();
        GlobalSlider.value = PlayerPrefs.GetFloat("MasterVolume_value", 0);
        AmbientSlider.value = PlayerPrefs.GetFloat("MasterVolume_value", 0);
        EffectsSlider.value = PlayerPrefs.GetFloat("MasterVolume_value", 0);
    }
}
