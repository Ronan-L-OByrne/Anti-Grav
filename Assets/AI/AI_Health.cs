using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Health : MonoBehaviour
{
    private AI_Master AIManagerMaster;
    public int aiHealth;
    private int maxHealth;

    private void OnEnable()
    {
        SetInitReferences();

        AIManagerMaster.DeductHealthEvent += DeductHealth;
    }//end OnEnable()

    private void OnDisable()
    {
        AIManagerMaster.DeductHealthEvent -= DeductHealth;
    }//end OnDisable()

    private void SetInitReferences()
    {
        AIManagerMaster = this.GetComponent<AI_Master>();
    }//end setInitReferences()

    public void DeductHealth(int healthChange)
    {
        this.aiHealth -= healthChange;

        if (this.aiHealth <= 0)
        {
            this.aiHealth = 0;
            Destroy(this.gameObject);
        }//end if()
    }//end Deduct Healths

    private void Start()
    {
        aiHealth = 1;
    }//end Start()
}//end class AI_Health
