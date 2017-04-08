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
    public int invFrames;

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

    public void DeductHealth(int healthChange)
    {
        if (invFrames <= 0)
        {
            playerHealth -= healthChange;
        }//end if

        invFrames = 300;

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

    private void Update()
    {
    }//end Update()
}//end class Player_Health
