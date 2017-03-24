using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    //Variables
    public Rigidbody2D AIBody;
    private SpriteRenderer AISprite;
    public static GameObject player;
    public PlayerMovement playerMov;
    public float AISpeed;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("PlayerTemp");
        playerMov = player.GetComponent<PlayerMovement>();
        AIBody = GetComponent<Rigidbody2D>();
        AIBody.velocity = new Vector2(AIBody.velocity.x, AIBody.velocity.y - 0.2f);
        AISprite = GetComponent<SpriteRenderer>();
        AISpeed = 3.0f;
	}//end Start()

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other = "PlayerTemp")
        {
            AISpeed = -AISpeed;
        }//end if
    }//end OnCollisionEnter

    // Update is called once per frame
    void Update ()
    {
        AIBody.velocity = new Vector2(AISpeed, AIBody.velocity.y);

        transform.eulerAngles = new Vector3(0, 0, 0);


        if (AISpeed > 0)
        {
            AISprite.flipX = true;
        }//end if
        else if (AISpeed < 0)
        {
            AISprite.flipX = false;
        }//end else if
    }//end Update()
}//end class AI_Movement
