using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    
    void Update()
    {
        if (gameObject.GetComponent<PauseManager>().gamePause)
        {
            gameManager.GamePause = true;
        }
        else
        {
            gameManager.GamePause = false;
        }
    }
}
