using UnityEngine;

public class PM_Health : MonoBehaviour
{
    public GM_Master gameManagerMaster;
    private PM_Master playerManagerMaster;
    public int playerHealth;
    public int maxHealth;
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
        playerManagerMaster = GameObject.Find("Player").GetComponent<PM_Master>();
    }//end setInitReferences()

    public void DeductHealth(int healthChange)
    {
        if (invFrames <= 0)
        {
            playerHealth -= healthChange;
            invFrames = 100;
        }//end if
        
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
        GUIStyle myStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = (int)((Screen.width + Screen.height) * (.008f))
        };

        GUI.Box(new Rect(5, 1, Screen.width * (.1f), Screen.height * (.035f)), "Health: " + playerHealth, myStyle);
    }//end OnGUI()

    private void Update()
    {
        if (invFrames > 0)
        {
            invFrames -= 1;
        }//end if
    }//end Update()

    private void Start()
    {
        playerHealth = 5;
        maxHealth = 10;
    }//end Start()
}//end class Player_Health
