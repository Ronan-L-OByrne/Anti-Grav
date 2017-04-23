using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Spawning : MonoBehaviour
{
    private AI_Master AIManagerMaster;
    private GameObject initEnemy;
    private GameObject cameraChk;

    private void OnEnable()
    {
        SetInitReferences();

        AIManagerMaster.SpawnEnemyEvent += SpawnEnemy;
    }//end OnEnable()

    private void OnDisable()
    {
        AIManagerMaster.SpawnEnemyEvent -= SpawnEnemy;
    }//end OnDisable()

    private void SetInitReferences()
    {
        AIManagerMaster = GameObject.Find("Enemy_EvilPlayer").GetComponent<AI_Master>();
    }//end setInitReferences()

    private void Start()
    {
        initEnemy = GameObject.Find("Enemy_EvilPlayer");
        cameraChk = GameObject.Find("Main Camera");
        InvokeRepeating("CallSpawnEnemy", 0.0f, 5.0f);
    }//end Start()

    public void CallSpawnEnemy()
    {
        SpawnEnemy(new Vector3(cameraChk.transform.position.x + 10, -4, initEnemy.transform.position.z));
    }//end CallSpawnEnemy()

    public void SpawnEnemy(Vector3 spawnPos)
    {
        GameObject newEnemy = Object.Instantiate(initEnemy, spawnPos, Quaternion.Euler(0, 0, 0));
        newEnemy.transform.parent = gameObject.transform;
        this.gameObject.SetActive(true);
    }//end SpawnEnemy()
}//end class AI_Spawning
