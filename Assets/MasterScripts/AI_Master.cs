using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Master : MonoBehaviour
{
    public delegate void AI_HealthHandler(int healthChange);
    public event AI_HealthHandler DeductHealthEvent;

    public void CallEventDeductHealth(int healthChange)
    {
        if (DeductHealthEvent != null)
        {
            DeductHealthEvent(healthChange);
        }//end if
    }//end CallEventDecreaseHealth()
}//end class AI_Master
