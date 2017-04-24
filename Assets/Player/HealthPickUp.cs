using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }//end Start()

    private void OnCollisionEnter2D(Collision2D collisionOther)
    {
        if (collisionOther.gameObject.name == "Player")
        {
            player.GetComponent<PM_Master>().CallEventIncreaseHealth(1);
            Destroy(this.gameObject);
        }//end if
    }//end OnCollisionEnter2D()
}//end class HealthPickUp
