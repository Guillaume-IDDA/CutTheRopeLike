using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Button : MonoBehaviour {

    [SerializeField] GameObject PauseMenu;

    public static bool gameOnPause = false;

	public void PauseMenuActivation()
    {
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
        gameOnPause = true;
    }
}
