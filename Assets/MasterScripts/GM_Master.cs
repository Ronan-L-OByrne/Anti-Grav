using UnityEngine;

public class GM_Master : MonoBehaviour
{
    public delegate void GM_EventHandler();
    public event GM_EventHandler MenuToggleEvent;
    public event GM_EventHandler UIEvent;
    public event GM_EventHandler RestartLevelEvent;
    public event GM_EventHandler GoToMenuSceneEvent;
    public event GM_EventHandler GameOverEvent;

    public bool GameOver = false;
    public bool InventoryUIOn;
    public bool MenuOn;

    public void CallEventMenuToggle()
    {
        if(MenuToggleEvent != null)
        {
            MenuToggleEvent();
        }//end if
    }//end CallEventMenuToggle()
    
    public void CallEventUI()
    {
        if (UIEvent != null)
        {
            UIEvent();
        }//end if
    }//end CallUIEvent()

    public void CallEventRestartLevel()
    {
        if (RestartLevelEvent != null)
        {
            RestartLevelEvent();
        }//end if
    }//end CallRestartLevelEvent()

    public void CallEventGoToMenuScene()
    {
        if (GoToMenuSceneEvent != null)
        {
            GoToMenuSceneEvent();
        }//end if
    }//end CallGoToMenuSceneEvent()

    public void CallEventGameOver()
    {
        if (GameOverEvent != null)
        {
            GameOver = true;
            GameOverEvent();
        }//end if
    }//end CallGoToMenuSceneEvent()
}//end class GM_Master
