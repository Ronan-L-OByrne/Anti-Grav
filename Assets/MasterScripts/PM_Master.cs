using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_Master : MonoBehaviour
{
    public delegate void PM_HealthHandler(int healthChange);
    public event PM_HealthHandler IncreaseHealthEvent;
    public event PM_HealthHandler DeductHealthEvent;
    public delegate void PM_AttackHandler();
    public event PM_AttackHandler AttackEvent;

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

    public void CallEventAttack()
    {
        if (IncreaseHealthEvent != null)
        {
            AttackEvent();
        }//end if
    }//end CallEventIncreaseHealth()
}//end class PM_Master
