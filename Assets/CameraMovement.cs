using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static GameObject player;
    public PlayerMovement playerMov = player.GetComponent<PlayerMovement>();
    public Vector3 offset, temp;
    public float maxOffset, time;

	// Use this for initialization
	void Start ()
    {
        time = 0;
        maxOffset = 1;
        temp = new Vector3(transform.position.x, transform.position.y, -10);
        //offset = transform.position - player.transform.position;
    }//end Start()
	
	// Update is called once per frame
	void LateUpdate ()
    {
        offset = transform.position - new Vector3(playerMov.playerBody.position.x, playerMov.playerBody.position.y, 0);


        if (offset.x > maxOffset || offset.x < -maxOffset || offset.y > maxOffset || offset.y < -maxOffset)
        {
            if (offset.x > maxOffset)
            {
                transform.position = new Vector3(playerMov.playerBody.position.x + maxOffset, transform.position.y, -10);
            }//end if
            else if (offset.x < -maxOffset)
            {
                transform.position = new Vector3(playerMov.playerBody.position.x - maxOffset, transform.position.y, -10);
            }//end else if

            if (offset.y > maxOffset)
            {
                transform.position = new Vector3(transform.position.x, playerMov.playerBody.position.y + maxOffset, -10);
            }//end else if
            else if (offset.y < -maxOffset)
            {
                transform.position = new Vector3(transform.position.x, playerMov.playerBody.position.y - maxOffset, -10);
            }//end else if

            temp = new Vector3(transform.position.x, transform.position.y, -10);
            time = 0;

            Debug.Log("If");
        }//end if
        else
        {
            transform.position = new Vector3(Mathf.Lerp(temp.x, playerMov.playerBody.position.x, time), Mathf.Lerp(temp.y, playerMov.playerBody.position.y, time), -10);
            time += .01f;

            if(time >= 1)
            {
                temp = new Vector3(transform.position.x, transform.position.y, -10);
                time = 0;
            }//end if

            Debug.Log("Else");
        }//end else
    }//end Update()
}//end class CameraMovement
