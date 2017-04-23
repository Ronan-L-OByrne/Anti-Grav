using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Variables
    private static GameObject player;
    private PM_Movement playerMov;
    private Vector3 offset;
    private float maxOffset;
    private int zPos;


	// Use this for initialization
	void Start ()
    {
        if (this.name == "SkyBox")
        {
            zPos = 0;
        }//end if
        else if (this.name == "Main Camera")
        {
            zPos = -10;
        }//end else if

        player = GameObject.Find("Player");
        playerMov = player.GetComponent<PM_Movement>();
        maxOffset = 1;
    }//end Start()
	
	// Update is called once per frame
	void LateUpdate ()
    {
        offset = transform.position - new Vector3(playerMov.playerBody.position.x, playerMov.playerBody.position.y, 0);

        /*if (offset.x > maxOffset + .01f)
        {
            transform.position = new Vector3(playerMov.playerBody.position.x + maxOffset, transform.position.y, zPos);
        }//end if
        else*/
        if (offset.x < -maxOffset - .01f)
        {
            transform.position = new Vector3(playerMov.playerBody.position.x - maxOffset, transform.position.y, zPos);
        }//end else if

        if (playerMov.playerBody.position.y >= -1)
        {
            if (offset.y > maxOffset + .01f)
            {
                transform.position = new Vector3(transform.position.x, playerMov.playerBody.position.y + maxOffset, zPos);
            }//end if
            else if (offset.y < -maxOffset - .01f)
            {
                transform.position = new Vector3(transform.position.x, playerMov.playerBody.position.y - maxOffset, zPos);
            }//end else if
        }//end if
    }//end Update()
}//end class CameraMovement
