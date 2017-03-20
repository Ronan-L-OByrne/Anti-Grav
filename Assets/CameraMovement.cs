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
	void Update ()
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
    }//end Update()
}//end class CameraMovement
