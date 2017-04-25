using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_Master : MonoBehaviour
{
    public delegate void PM_HealthHandler(int healthChange);
    public event PM_HealthHandler IncreaseHealthEvent;
    public event PM_HealthHandler DeductHealthEvent;
    public delegate void PM_AttackHandler(bool dirChk);
    public event PM_AttackHandler AttackEvent;
    public delegate void PM_ScoreHandler(int healthChange);
    public event PM_ScoreHandler DeductScoreEvent;
    public event PM_ScoreHandler IncreaseScoreEvent;

    public void CallEventDeductHealth(int healthChange)
    {
        if (DeductHealthEvent != null)
        {
            DeductHealthEvent(healthChange);
        }//end if
    }//end CallEventDecreaseHealth()

    public void CallEventIncreaseHealth(int healthChange)
    {
        if (IncreaseHealthEvent != null)
        {
            IncreaseHealthEvent(healthChange);
        }//end if
    }//end CallEventIncreaseHealth()

    public void CallEventAttack(bool dirChk)
    {
        if (IncreaseHealthEvent != null)
        {
            AttackEvent(dirChk);
        }//end if
    }//end CallEventIncreaseHealth()

    public void CallEventDeductScore(int scoreChange)
    {
        if (DeductScoreEvent != null)
        {
            DeductScoreEvent(scoreChange);
        }//end if
    }//end CallEventDecreaseHealth()

    public void CallEventIncreaseScore(int scoreChange)
    {
        if (IncreaseScoreEvent != null)
        {
            IncreaseScoreEvent(scoreChange);
        }//end if
    }//end CallEventIncreaseHealth()
}//end class PM_Master
