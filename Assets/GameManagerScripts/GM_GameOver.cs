using System.Collections;
using System.Collections.Generic;
//using UnityEngine.UI;
using UnityEngine;

public class GM_GameOver : MonoBehaviour
{
    private GM_Master gameManagerMaster;
    public GameObject panelGameOver;

    public void OnEnable()
    {
        SetInitReferences();

        gameManagerMaster.GameOverEvent += DisplayGameOver;
    }//end OnEnable()

    public void OnDisable()
    {
        gameManagerMaster.GameOverEvent -= DisplayGameOver;
    }//end OnDisable()

    public void SetInitReferences()
    {
        gameManagerMaster = GetComponent<GM_Master>();
    }//end SetInitReferences()

    public void DisplayGameOver()
    {
        if (panelGameOver != null)
        {
            //Debug.Log("GameOver");
            panelGameOver.SetActive(true);
        }//end if()
    }//end DisplayGameOver()
}//end class GM_GameOver
