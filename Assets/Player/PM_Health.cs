using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PM_Health : MonoBehaviour
{
    private GM_Master gameManagerMaster;
    private PM_Master playerManagerMaster;
    public int playerHealth;
    private int maxHealth;
    public int InvisFrames;

    private void OnEnable()
    {
        SetInitReferences();
        
        playerManagerMaster.DeductHealthEvent += DeductHealth;
        playerManagerMaster.IncreaseHealthEvent += IncreaseHealth;
    }//end OnEnable()

    private void OnDisable()
    {
        playerManagerMaster.DeductHealthEvent -= DeductHealth;
        playerManagerMaster.IncreaseHealthEvent -= IncreaseHealth;
    }//end OnDisable()

    private void SetInitReferences()
    {
        gameManagerMaster = GameObject.Find("GameManager").GetComponent<GM_Master>();
        playerManagerMaster = GameObject.Find("Player").GetComponent<PM_Master>();
    }//end setInitReferences()

    IEnumerator TestDeduction()
    {
        yield return new WaitForSeconds(2);
        DeductHealth(5);
    }//end TestDeduction

    public void DeductHealth(int healthChange)
    {
        playerHealth -= healthChange;
        InvisFrames = 1;

        if (playerHealth <= 0)
        {
            playerHealth = 0;
            gameManagerMaster.CallEventGameOver();
        }//end if()
    }//end Deduct Health

    public void IncreaseHealth(int healthChange)
    {
        playerHealth += healthChange;

        if (playerHealth >= maxHealth)
        {
            playerHealth = maxHealth;
        }//end if()
    }//end IncreaseHealth

    void OnGUI()
    {
        // Make a background box
        GUI.Box(new Rect(10, 10, 70, 23), "Health: " + playerHealth);
    }//end OnGUI()
}//end class Player_Health
