using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue_Button : MonoBehaviour {

	public void ContinueGame()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        Pause_Button.gameOnPause = false;
        Time.timeScale = 1f;
    }
}
