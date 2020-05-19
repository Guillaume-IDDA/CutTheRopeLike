using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


static public class DataController
{
    static int nbLevels = 10;

    static Level[] datalevel = new Level[11];

    public static Player player;

    public static int LoadPlayerProgressStars(int numLevel)
    {
        return PlayerPrefs.GetInt("numberOfStars to level" + numLevel,0);       
    }

    public static int LoadPlayerProgessUnlockLevel(int numlevel)
    {
        return PlayerPrefs.GetInt("unlocked to level" + numlevel, 0);
    }


    public static void SavePlayerProgress()
    {
        if(player.NbStars >= PlayerPrefs.GetInt("numberOfStars to level" + SceneManager.GetActiveScene().buildIndex, 0))
        {
            PlayerPrefs.SetInt("numberOfStars to level" + SceneManager.GetActiveScene().buildIndex, player.NbStars);
            datalevel[SceneManager.GetActiveScene().buildIndex].nbStarsCollected = player.NbStars;
            PlayerPrefs.Save();
        }

        PlayerPrefs.SetInt("unlocked to level" + (SceneManager.GetActiveScene().buildIndex+1), 1);
        datalevel[SceneManager.GetActiveScene().buildIndex].LevelUnlocked = true;
        PlayerPrefs.Save();
    }

    public static void ResetGame()
    {

        for (int i = 1; i < nbLevels + 1; i++)
        {
            PlayerPrefs.SetInt("numberOfStars to level" + i, 0);
            PlayerPrefs.Save();
        }
        for (int j = 2; j < nbLevels+1; j++)
        {
            PlayerPrefs.SetInt("unlocked to level" + j, 0);
            PlayerPrefs.Save();
        }

        PlayerPrefs.SetFloat("MasterVolume_value", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("AmbientVolume_value", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("EffectsVolume_value", 0);
        PlayerPrefs.Save();
    }

}