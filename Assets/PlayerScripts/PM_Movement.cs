using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_Movement : MonoBehaviour
{
    //Game Manager Variable
    private GM_Master gameManagerMaster;
    private PM_Master playerManagerMaster;

    //Variables
    public float moveSpeed, maxSpeed;
    public Vector2 jumpHeight;
    public bool canJump, jumping;
    public Rigidbody2D playerBody;
    private SpriteRenderer mySprite;
    public int expectedAngle;
    public float curAngle;
    public float time;


    // Use this for initialization
    void Start ()
    {
        gameManagerMaster = GameObject.Find("GameManager").GetComponent<GM_Master>();
        playerManagerMaster = GetComponent<PM_Master>();
        moveSpeed = 0.2f;
        maxSpeed = moveSpeed*100;
        jumpHeight = new Vector2(0, 18.75f);
        canJump = false;
        jumping = true;
        playerBody = GetComponent<Rigidbody2D>();
        playerBody.velocity = new Vector2(playerBody.velocity.x, playerBody.velocity.y-0.2f);
        mySprite = GetComponent<SpriteRenderer>();
        expectedAngle = 0;
        curAngle = 0.0f;
        time = 0.0f;
    }//end Start()

    //When the Player collides with an object
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.name.StartsWith("Enemy"))
        {
            canJump = true;
            jumping = false;
        }//end if
        else
        {
            canJump = false;
            jumping = true;
        }//end else
    }//end OnCollisionStay2D

    //When the Player stops colliding with an object
    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
        jumping = true;
    }//end OnCollisionExit2D

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
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
            }//end else if
            else
            {
                time = 0;
            }//end else

            CheckKeys();

            if (expectedAngle == 0)
            {
                if (jumping && playerBody.velocity.y > -maxSpeed * 3)
                {
                    playerBody.velocity = new Vector2(playerBody.velocity.x, playerBody.velocity.y - moveSpeed);
                }//end if
                else
                {
                    playerBody.velocity = new Vector2(playerBody.velocity.x, playerBody.velocity.y - moveSpeed / 2);
                }//end else

                if (playerBody.velocity.x > 0.5f)
                {
                    mySprite.flipX = true;
                }//end if
                else if (playerBody.velocity.x < -0.5f)
                {
                    mySprite.flipX = false;
                }//end else if
            }//end if
            else if (expectedAngle == 90)
            {
                if (jumping && playerBody.velocity.x < maxSpeed * 3)
                {
                    playerBody.velocity = new Vector2(playerBody.velocity.x + moveSpeed, playerBody.velocity.y);
                }//end if
                else
                {
                    playerBody.velocity = new Vector2(playerBody.velocity.x + moveSpeed / 2, playerBody.velocity.y);
                }//end else

                if (playerBody.velocity.y > 0.5f)
                {
                    mySprite.flipX = true;
                }//end if
                else if (playerBody.velocity.y < -0.5f)
                {
                    mySprite.flipX = false;
                }//end else if
            }//end if

            transform.eulerAngles = new Vector3(0, 0, curAngle);

            if (transform.position.y <= -6)
            {
                gameManagerMaster.CallEventGameOver();
            }//end if()
        }//end if
    }//end Update()

    void CheckKeys()
    {
        if (expectedAngle == 0)
        {
            if (Input.GetKeyDown(KeyCode.W) && canJump)
            {
                playerBody.velocity += jumpHeight;
            }//end if

            if (Input.GetKey(KeyCode.A) && playerBody.velocity.x > -maxSpeed)
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x - moveSpeed, playerBody.velocity.y);
            }//end if

            if (Input.GetKey(KeyCode.D) && playerBody.velocity.x < maxSpeed)
            {
                 playerBody.velocity = new Vector2(playerBody.velocity.x + moveSpeed, playerBody.velocity.y);
            }//end if

            if (Input.GetKeyDown(KeyCode.Space))
            {
                expectedAngle = 90;
                jumpHeight = new Vector2(-jumpHeight.y, jumpHeight.x);
            }//end if

            if (Input.GetMouseButtonDown(0))
            {
                playerManagerMaster.CallEventAttack(mySprite.flipX);
            }//end if
        }//end if
        else if(expectedAngle == 90)
        {
            if (Input.GetKeyDown(KeyCode.A) && canJump)
            {
                playerBody.velocity += jumpHeight;
            }//end if

            if (Input.GetKey(KeyCode.S) && playerBody.velocity.y > -maxSpeed)
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, playerBody.velocity.y - moveSpeed);
            }//end if

            if (Input.GetKey(KeyCode.W) && playerBody.velocity.y < maxSpeed)
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, playerBody.velocity.y + moveSpeed);
            }//end if

            if (Input.GetKeyDown(KeyCode.Space))
            {
                expectedAngle = 0;
                jumpHeight = new Vector2(jumpHeight.y, -jumpHeight.x);
            }//end if

            if (Input.GetMouseButtonDown(0))
            {
                playerManagerMaster.CallEventAttack(mySprite.flipX);
            }//end if
        }//end else if
    }//end checkKeys()
}//end class PlayerMovement
