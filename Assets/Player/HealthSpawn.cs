using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawn : MonoBehaviour
{
    public GameObject healthTemplate;
    public GameObject cameraChk;
    private bool spawnChk;

    private void Start()
    {
        healthTemplate = GameObject.Find("HealthUp");
        cameraChk = GameObject.Find("Main Camera");
        spawnChk = true;
        //InvokeRepeating("CallSpawnHealth", 0.0f, 5.0f);
    }//end Start()

    private void Update()
    {
        //Debug.Log(cameraChk.transform.position.x % 100 + " - " + cameraChk.transform.position.x % 100);
        if(cameraChk.transform.position.x % 100 < 5 && cameraChk.transform.position.x % 100 > -5)
        {
            if (spawnChk)
            {
                CallSpawnHealth();
                spawnChk = false;
            }//end if
        }//end if
        else
        {
            spawnChk = true;
        }//end else
    }//end Update()

    private void CallSpawnHealth()
    {
        SpawnHealth(new Vector3(cameraChk.transform.position.x + 10, -3.5f, healthTemplate.transform.position.z));
    }//end CallSpawnHealth()

    private void SpawnHealth(Vector3 spawnPos)
    {
        GameObject newHealthPk = Object.Instantiate(healthTemplate, spawnPos, Quaternion.Euler(0, 0, 0));
        newHealthPk.transform.parent = gameObject.transform;
        this.gameObject.SetActive(true);
    }//end SpawnHealth()
}//end class HealthSpawn
