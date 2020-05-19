using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevelSelectMenu : MonoBehaviour {

    [SerializeField] int numLevel;

    // Use this for initialization
    void Start ()
    {
        if(gameObject.transform.parent.gameObject.name == "CanvasLock")
        {
            if (DataController.LoadPlayerProgessUnlockLevel(numLevel) == 1)
            {
                gameObject.SetActive(false);
            }
        }
        else if (gameObject.transform.parent.gameObject.name == "Canvas")
        {
            if (DataController.LoadPlayerProgessUnlockLevel(numLevel) == 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
