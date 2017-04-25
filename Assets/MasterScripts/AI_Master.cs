using UnityEngine;

public class AI_Master : MonoBehaviour
{
    public delegate void AI_HealthHandler(int healthChange);
    public event AI_HealthHandler DeductHealthEvent;
    public delegate void AI_SpawnHandler(GameObject curEnemy, Vector3 spawnPos);
    public event AI_SpawnHandler SpawnEnemyEvent;

    public void CallEventDeductHealth(int healthChange)
    {
        if (DeductHealthEvent != null)
        {
            DeductHealthEvent(healthChange);
        }//end if
    }//end CallEventDecreaseHealth()

    public void CallEventSpawnEnemy(GameObject curEnemy, Vector3 spawnPos)
    {
        if (SpawnEnemyEvent != null)
        {
            SpawnEnemyEvent(curEnemy, spawnPos);
        }//end if
    }//end CallEventDecreaseHealth()
}//end class AI_Master
