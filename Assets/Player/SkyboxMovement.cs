using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxMovement : MonoBehaviour
{
    //Variables
    public static GameObject player;
    public PlayerMovement playerMov;
    public Vector3 offset, temp;
    public float maxOffset, time;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        playerMov = player.GetComponent<PlayerMovement>();
        time = 0;
        maxOffset = 1;
        temp = new Vector3(transform.position.x, transform.position.y, 0);
    }//end Start()

    // Update is called once per frame
    void Update()
    {
        offset = transform.position - new Vector3(playerMov.playerBody.position.x, playerMov.playerBody.position.y, 0);

        if (offset.x > maxOffset + .01f)
        {
            transform.position = new Vector3(playerMov.playerBody.position.x + maxOffset, transform.position.y, 0);
        }//end if
        else if (offset.x < -maxOffset - .01f)
        {
            transform.position = new Vector3(playerMov.playerBody.position.x - maxOffset, transform.position.y, 0);
        }//end else if

        if (offset.y > maxOffset + .01f)
        {
            transform.position = new Vector3(transform.position.x, playerMov.playerBody.position.y + maxOffset, 0);
        }//end if
        else if (offset.y < -maxOffset - .01f)
        {
            transform.position = new Vector3(transform.position.x, playerMov.playerBody.position.y - maxOffset, 0);
        }//end else if
    }//end Update()
}// end class SkyboxMovement
