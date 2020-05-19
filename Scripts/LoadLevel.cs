using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public string Level;

    public void LoadLvl()
    {
        SceneManager.LoadScene(Level);
        Pause_Button.gameOnPause = false;
        Time.timeScale = 1f;
        Physics2D.gravity = new Vector2(0, -9.81f);
        PlayerPrefs.Save();
    }
}
