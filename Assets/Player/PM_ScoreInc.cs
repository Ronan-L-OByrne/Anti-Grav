using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_ScoreInc : MonoBehaviour
{
    private PM_Master playerManagerMaster;
    public int playerScore;
    public float scoreMultiplier;
    public int combo;

    private void OnEnable()
    {
        SetInitReferences();

        playerManagerMaster.DeductScoreEvent += DeductScore;
        playerManagerMaster.IncreaseScoreEvent += IncreaseScore;
    }//end OnEnable()

    private void OnDisable()
    {
        playerManagerMaster.DeductScoreEvent -= DeductScore;
        playerManagerMaster.IncreaseScoreEvent -= IncreaseScore;
    }//end OnDisable()

    private void SetInitReferences()
    {
        playerManagerMaster = GameObject.Find("Player").GetComponent<PM_Master>();
    }//end setInitReferences()

    public void DeductScore(int scoreChange)
    {
        playerScore -= scoreChange;

        if(playerScore < 0)
        {
            playerScore = 0;
        }//end if
    }//end IncreaseHealth

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width - 80, 10, 70, 23), "Score: " + playerScore);
    }//end OnGUI()

    private void Start()
    {
        playerScore = 0;
        scoreMultiplier = 1;
        combo = 0;
        InvokeRepeating("DecrementScoreTime", 1.0f, 1.0f);
    }//end Start()

    private void Update()
    {
        if (playerScore < 0)
        {
            playerScore = 0;
        }//end if

        scoreMultiplier += 0.005f;
    }//end Update()

    public void DecrementScoreTime()
    {
        playerScore--;
    }//end DecrementScore()

    public void IncreaseScore(int scoreChange)
    {
        playerScore += (int)(scoreChange * scoreMultiplier);
    }//end IncreaseHealth
}//end class PM_ScoreInc
