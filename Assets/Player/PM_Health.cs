using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    private GM_Master gameManagerMaster;
    private PM_Master playerManagerMaster;
    public int playerHealth;
    public int maxHealth;
    public Text healthText;

    private void Start()
    {
        maxHealth = 5;
        playerHealth = maxHealth;
        //StartCoroutine(TestDeduction());
    }//end Start()

    private void OnEnable()
    {
        SetInitReferences();

        SetUI();
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
        yield return new WaitForSeconds(5);
    }//end TestDeduction

    public void DeductHealth(int healthChange)
    {
        playerHealth -= healthChange;

        if (playerHealth <= 0)
        {
            playerHealth = 0;
            gameManagerMaster.CallEventGameOver();
        }//end if()

        SetUI();
    }//end Deduct Health

    public void IncreaseHealth(int healthChange)
    {
        playerHealth += healthChange;

        if (playerHealth >= maxHealth)
        {
            playerHealth = maxHealth;
        }//end if()

        SetUI();
    }//end IncreaseHealth

    public void SetUI()
    {
        if(healthText != null)
        {
            healthText.text = playerHealth.ToString();
        }//end if
    }//end setUI()
}//end class Player_Health
