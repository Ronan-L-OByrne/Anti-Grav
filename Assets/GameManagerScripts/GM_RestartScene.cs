using UnityEngine;
using UnityEngine.SceneManagement;

public class GM_RestartScene : MonoBehaviour
{
    private GM_Master gameManagerMaster;

    private void OnEnable()
    {
        SetInitReferences();

        gameManagerMaster.GoToMenuSceneEvent += RestartScene;
    }//end onEnable()

    private void OnDisable()
    {
        gameManagerMaster.GoToMenuSceneEvent -= RestartScene;
    }//end OnDisable()

    private void SetInitReferences()
    {
        gameManagerMaster = GetComponent<GM_Master>();
    }//end SetInitReferences()

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }//end GoToMainMenu
}//end class GM_GoToMainMenu
