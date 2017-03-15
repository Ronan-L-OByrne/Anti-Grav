using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start ()
    {
        offset = transform.position - player.transform.position;
    }//end Start()
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.position = new Vector3((player.transform.position.x + offset.x), 0, -10);
    }//end Update()
}//end class CameraMovement
