using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Variables
    public static GameObject player;
    public PM_Movement playerMov;
    public Vector3 offset, temp;
    public float maxOffset, time;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
        playerMov = player.GetComponent<PM_Movement>();
        time = 0;
        maxOffset = 1;
        temp = new Vector3(transform.position.x, transform.position.y, -10);
    }//end Start()
	
	// Update is called once per frame
	void LateUpdate ()
    {
        offset = transform.position - new Vector3(playerMov.playerBody.position.x, playerMov.playerBody.position.y, 0);

        if (offset.x > maxOffset + .01f)
        {
            transform.position = new Vector3(playerMov.playerBody.position.x + maxOffset, transform.position.y, -10);
        }//end if
        else if (offset.x < -maxOffset - .01f)
        {
            transform.position = new Vector3(playerMov.playerBody.position.x - maxOffset, transform.position.y, -10);
        }//end else if

        if (playerMov.playerBody.position.y >= -1)
        {
            if (offset.y > maxOffset + .01f)
            {
                transform.position = new Vector3(transform.position.x, playerMov.playerBody.position.y + maxOffset, -10);
            }//end if
            else if (offset.y < -maxOffset - .01f)
            {
                transform.position = new Vector3(transform.position.x, playerMov.playerBody.position.y - maxOffset, -10);
            }//end else if
        }//end if
    }//end Update()
}//end class CameraMovement
