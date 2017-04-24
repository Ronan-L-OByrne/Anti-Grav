using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Spawning : MonoBehaviour
{
    private AI_Master AIManagerMaster;
    private GameObject initEnemy_EP;
    private GameObject initEnemy_B;
    private GameObject cameraChk;
    private Random rand;

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
        rand = new Random();
        initEnemy_EP = GameObject.Find("Enemy_EvilPlayer");
        initEnemy_B = GameObject.Find("Enemy_Bird");
        cameraChk = GameObject.Find("Main Camera");
        InvokeRepeating("CallSpawnEnemy_EP", 0.0f, 5.0f);
        InvokeRepeating("CallSpawnEnemy_B", 2.5f, 2.0f);
    }//end Start()

    public void CallSpawnEnemy_EP()
    {
        SpawnEnemy(initEnemy_EP, new Vector3(cameraChk.transform.position.x + 10, -4, initEnemy_EP.transform.position.z));
    }//end CallSpawnEnemy()

    public void CallSpawnEnemy_B()
    {
        SpawnEnemy(initEnemy_B, new Vector3(cameraChk.transform.position.x + 10, Random.Range(-4, 4), initEnemy_B.transform.position.z));
    }//end CallSpawnEnemy()

    public void SpawnEnemy(GameObject curEnemy, Vector3 spawnPos)
    {
        GameObject newEnemy = Object.Instantiate(curEnemy, spawnPos, Quaternion.Euler(0, 0, 0));
        newEnemy.transform.parent = gameObject.transform;
        this.gameObject.SetActive(true);
    }//end SpawnEnemy()
}//end class AI_Spawning
