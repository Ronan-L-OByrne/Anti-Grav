using UnityEngine;

public class PM_ScoreInc : MonoBehaviour
{
    private PM_Master playerManagerMaster;
    public int playerScore;
    public float scoreMultiplier;
    public int combo;
//    private bool healthChk;

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
        GUI.Box(new Rect(Screen.width - 100, 10, 90, 23), "Score: " + playerScore);
        GUI.Box(new Rect(Screen.width - 100, 33, 90, 25), "Multiplier: " + scoreMultiplier.ToString("F1"));
    }//end OnGUI()

    private void Start()
    {
        playerScore = 0;
        scoreMultiplier = 1;
        combo = 0;
        //healthChk = true;
        InvokeRepeating("DecrementScoreTime", 1.0f, 1.0f);
    }//end Start()

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            if (playerScore < 0)
            {
                playerScore = 0;
            }//end if

            scoreMultiplier += 0.005f;
        }//end if
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
