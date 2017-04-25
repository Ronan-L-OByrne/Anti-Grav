using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    //Variables
    private static GameObject player;
    private Rigidbody2D playerMov;
    public Vector3 offset;
    
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        playerMov = player.GetComponent<Rigidbody2D>();
    }//end Start()

    // Update is called once per frame
    void LateUpdate()
    {
        offset = transform.position - new Vector3(playerMov.position.x, playerMov.position.y, 0);
        
        transform.position = new Vector3(playerMov.position.x, transform.position.y, transform.position.z);
    }//end Update()
}//end class FloorMovement
