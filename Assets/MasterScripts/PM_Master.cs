using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_Master : MonoBehaviour
{
    public delegate void PM_HealthHandler(int healthChange);
    public event PM_HealthHandler IncreaseHealthEvent;
    public event PM_HealthHandler DeductHealthEvent;

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
}//end class PM_Master
