using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
	public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }//end PlayGame()

    public void ExitGame()
    {
        Application.Quit();
    }//end ExitGame()
}//end class MainMenuScript
