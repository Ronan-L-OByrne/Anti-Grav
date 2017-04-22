using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.GetComponent<PM_Master>().CallEventIncreaseHealth(1);
        Destroy(this.gameObject);
    }//end OnCollisionEnter2D()
}//end class HealthPickUp
