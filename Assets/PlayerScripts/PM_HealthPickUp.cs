using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_HealthPickUp : MonoBehaviour
{
    public GameObject player;
    private GameObject cameraChk;

    private void Start()
    {
        player = GameObject.Find("Player");
        cameraChk = GameObject.Find("Main Camera");
    }//end Start()

    private void OnCollisionEnter2D(Collision2D collisionOther)
    {
        if (collisionOther.gameObject.name == "Player" && player.GetComponent<PM_Health>().playerHealth < player.GetComponent<PM_Health>().maxHealth)
        {
            player.GetComponent<PM_Master>().CallEventIncreaseHealth(1);
            Destroy(this.gameObject);
        }//end if
    }//end OnCollisionEnter2D()

    private void Update()
    {
        if (this.transform.position.x <= cameraChk.transform.position.x - 8.25 && this.gameObject.name.Contains("Clone"))
        {
            Destroy(this.gameObject);
        }//end if
    }//end Update()
}//end class HealthPickUp
