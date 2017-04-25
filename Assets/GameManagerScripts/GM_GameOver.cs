using System.Collections;
using System.Collections.Generic;
//using UnityEngine.UI;
using UnityEngine;

public class GM_GameOver : MonoBehaviour
{
    private GM_Master gameManagerMaster;
    public GameObject panelGameOver;
    //public PM_ScoreInc scoreChk;

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

    private void Start()
    {
        //scoreChk = GameObject.Find("Player").GetComponent<PM_ScoreInc>();
        //panelGameOver = GameObject.Find("GameOverPanel");
    }//end Start()

    public void DisplayGameOver()
    {
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true);
        }//end if()
        
        Text myText = panelGameOver.AddComponent<Text>();
    }//end DisplayGameOver()
}//end class GM_GameOver
