using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM_GoToMainMenu : MonoBehaviour
{
    private GM_Master gameManagerMaster;

    private void OnEnable()
    {
        SetInitReferences();

        gameManagerMaster.GoToMenuSceneEvent += GoToMainMenu;
    }//end onEnable()

    private void OnDisable()
    {
        gameManagerMaster.GoToMenuSceneEvent -= GoToMainMenu;
    }//end OnDisable()

    private void SetInitReferences()
    {
        gameManagerMaster = GetComponent<GM_Master>();
    }//end SetInitReferences()

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }//end GoToMainMenu
}//end class GM_GoToMainMenu
