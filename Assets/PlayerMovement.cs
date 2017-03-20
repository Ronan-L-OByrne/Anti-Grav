using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float moveSpeed;
    public Vector2 jumpHeight;
    public bool canJump, jumping;
    public bool spriteFlip;
    public Rigidbody2D playerBody;
    private SpriteRenderer mySprite;
    public int expectedAngle;
    public float curAngle;
    public float time;


    // Use this for initialization
    void Start ()
    {
        moveSpeed  = 0.2f;
        jumpHeight = new Vector2(0, 7.5f);
        canJump = false;
        jumping = true;
        playerBody = GetComponent<Rigidbody2D>();
        playerBody.velocity = new Vector2(playerBody.velocity.x, playerBody.velocity.y-0.2f);
        mySprite = GetComponent<SpriteRenderer>();
        expectedAngle = 0;
        spriteFlip = false;
        curAngle = 0;
        time = 0;
    }//end Start()

    //When the Player collides with an object
    private void OnCollisionStay2D(Collision2D collision)
    {
        canJump = true;
        jumping = false;
    }//end OnTriggerEnter

    //When the Player stops colliding with an object
    private void OnCollisionExit2D(Collision2D Platforms)
    {
        canJump = false;
        jumping = true;
    }//end OnTriggerEnter

    // Update is called once per frame
    void Update()
    {
        if (curAngle != expectedAngle && expectedAngle == 90)
        {
            curAngle = Mathf.Lerp(0, 90, time);
            time += 4.0f * Time.deltaTime;
        }//end if
        else if (curAngle != expectedAngle && expectedAngle == 0)
        {
            curAngle = Mathf.Lerp(90, 0, time);
            time += 4.0f * Time.deltaTime;
        }//end if
        else
        {
            time = 0;
        }//end else

        checkKeys();

        if (expectedAngle == 0)
        {
            if (jumping && playerBody.velocity.y > -10.0f)
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, playerBody.velocity.y - moveSpeed);
            }//end if
            else
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, playerBody.velocity.y - moveSpeed/4);
            }//end else

            if (playerBody.velocity.x > 0.5f)
            {
                // flip the sprite
                mySprite.flipX = true;
            }//end if
            else if (playerBody.velocity.x < -0.5f)
            {
                // flip the sprite
                mySprite.flipX = false;
            }//end else if
        }//end if
        else if (expectedAngle == 90)
        {
            if (jumping && playerBody.velocity.x < 10.0f)
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x + moveSpeed, playerBody.velocity.y);
            }//end if
            else
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x + moveSpeed / 4, playerBody.velocity.y);
            }//end else

            if (playerBody.velocity.y > 0.5f)
            {
                // flip the sprite
                mySprite.flipX = true;
            }//end if
            else if (playerBody.velocity.y < -0.5f)
            {
                // flip the sprite
                mySprite.flipX = false;
            }//end else if
        }//end if
        
        transform.eulerAngles = new Vector3(0, 0, curAngle);
    }//end Update()

    void checkKeys()
    {
        if (expectedAngle == 0)
        {
            if (Input.GetKeyDown(KeyCode.W) && canJump)
            {
                playerBody.velocity += jumpHeight;
            }//end if

            if (Input.GetKey(KeyCode.A) && playerBody.velocity.x > -5)
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x - moveSpeed, playerBody.velocity.y);
            }//end if

            if (Input.GetKey(KeyCode.D) && playerBody.velocity.x < 5)
            {
                 playerBody.velocity = new Vector2(playerBody.velocity.x + moveSpeed, playerBody.velocity.y);
            }//end if

            if (Input.GetKeyDown(KeyCode.Space))
            {
                expectedAngle = 90;
                jumpHeight = new Vector2(-jumpHeight.y, jumpHeight.x);
            }//end if
        }//end if
        else if(expectedAngle == 90)
        {
            if (Input.GetKeyDown(KeyCode.A) && canJump)
            {
                playerBody.velocity += jumpHeight;
            }//end if

            if (Input.GetKey(KeyCode.S) && playerBody.velocity.y > -5)
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, playerBody.velocity.y - moveSpeed);
            }//end if

            if (Input.GetKey(KeyCode.W) && playerBody.velocity.y < 5)
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, playerBody.velocity.y + moveSpeed);
            }//end if

            if (Input.GetKeyDown(KeyCode.Space))
            {
                expectedAngle = 0;
                jumpHeight = new Vector2(jumpHeight.y, -jumpHeight.x);
            }//end if
        }//end else if
    }//end checkKeys()
}//end class PlayerMovement
