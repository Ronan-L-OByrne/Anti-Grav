using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_TogglePause : MonoBehaviour
{
    private GM_Master gameManagerMaster;
    private bool isPaused;

    private void OnEnable()
    {

    }//end OnEnable()

    private void OnDisable()
    {

    }//end OnDisable()

    private void SetInitReferences()
    {
        gameManagerMaster = GetComponent<GM_Master>();
    }//end SetInitReferences()
    
    private void TogglePause()
    {
        if(isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }//end if()
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }//end else
    }//end TogglePause()
}//end class GameManager_TogglePause