using UnityEngine;

public class GM_TogglePause : MonoBehaviour
{
    private GM_Master gameManagerMaster;
    private bool isPaused;

    private void OnEnable()
    {
        SetInitReferences();

        gameManagerMaster.MenuToggleEvent += TogglePause;
        gameManagerMaster.UIEvent += TogglePause;
    }//end OnEnable()

    private void OnDisable()
    {
        gameManagerMaster.MenuToggleEvent -= TogglePause;
        gameManagerMaster.UIEvent -= TogglePause;
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
}//end class GM_TogglePause