using UnityEngine;

public class PM_Collision : MonoBehaviour
{
    public PM_Movement myParent;
    private GameObject player;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        player = GameObject.Find("Player");
        myParent = player.GetComponent<PM_Movement>();
    }//end Start()

    void OnCollisionEnter2D(Collision2D collisionOther)
    {
        for (int i = 0; i < collisionOther.contacts.GetLength(0); i++)
        {
            if (myParent.expectedAngle == 0)
            {
                if (collisionOther.contacts[i].point.x > myParent.playerBody.position.x + 0.248f && collisionOther.contacts[i].point.y < myParent.playerBody.position.y + 0.395f && collisionOther.contacts[i].point.y > myParent.playerBody.position.y - 0.335f)
                {
                    //Debug.Log("RIGHT");
                    myParent.jumpHeight = new Vector2(-myParent.moveSpeed * 35, myParent.moveSpeed * 45);

                    if (collisionOther.gameObject.name.StartsWith("Enemy"))
                    {
                        player.GetComponent<PM_Master>().CallEventDeductHealth(1);
                    }//end if
                    break;
                }//end if
                else if (collisionOther.contacts[i].point.x < myParent.playerBody.position.x - 0.248f && collisionOther.contacts[i].point.y < myParent.playerBody.position.y + 0.395f && collisionOther.contacts[i].point.y > myParent.playerBody.position.y - 0.335f)
                {
                    //Debug.Log("LEFT");
                    myParent.jumpHeight = new Vector2(myParent.moveSpeed * 35, myParent.moveSpeed * 45);

                    if (collisionOther.gameObject.name.StartsWith("Enemy"))
                    {
                        player.GetComponent<PM_Master>().CallEventDeductHealth(1);
                    }//end if
                    break;
                }//end else if
                else if (collisionOther.contacts[i].point.y > myParent.playerBody.position.y + 0.335f)
                {
                    //Debug.Log("TOP");
                    myParent.jumpHeight = new Vector2(0.0f, 0.0f);

                    if (collisionOther.gameObject.name.StartsWith("Enemy"))
                    {
                        player.GetComponent<PM_Master>().CallEventDeductHealth(1);
                    }//end if
                    break;
                }//end else if
                else if (collisionOther.contacts[i].point.y < myParent.playerBody.position.y - 0.395f)
                {
                    //Debug.Log("BOTTOM");
                    myParent.jumpHeight = new Vector2(0.0f, myParent.moveSpeed * 45);

                    if (collisionOther.gameObject.name.StartsWith("Enemy"))
                    {
                        collisionOther.gameObject.GetComponent<AI_Master>().CallEventDeductHealth(1);
                        player.GetComponent<PM_ScoreInc>().combo++;

                        player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 7.5f);
                    }//end if
                    break;
                }//end else if
            }//end if
            else
            {
                if (collisionOther.contacts[i].point.y > myParent.playerBody.position.y + 0.248f && collisionOther.contacts[i].point.x < myParent.playerBody.position.x + 0.395f && collisionOther.contacts[i].point.x > myParent.playerBody.position.x - 0.335f)
                {
                    //Debug.Log("RIGHT");
                    myParent.jumpHeight = new Vector2(-myParent.moveSpeed * 45, -myParent.moveSpeed * 35);

                    if (collisionOther.gameObject.name.StartsWith("Enemy"))
                    {
                        player.GetComponent<PM_Master>().CallEventDeductHealth(1);
                    }//end if
                    break;
                }//end if
                else if (collisionOther.contacts[i].point.y < myParent.playerBody.position.y - 0.248f && collisionOther.contacts[i].point.x < myParent.playerBody.position.x + 0.395f && collisionOther.contacts[i].point.x > myParent.playerBody.position.x - 0.335f)
                {
                    //Debug.Log("LEFT");
                    myParent.jumpHeight = new Vector2(-myParent.moveSpeed * 45, myParent.moveSpeed * 35);

                    if (collisionOther.gameObject.name.StartsWith("Enemy"))
                    {
                        player.GetComponent<PM_Master>().CallEventDeductHealth(1);
                    }//end if
                    break;
                }//end else if
                else if (collisionOther.contacts[i].point.x < myParent.playerBody.position.x - 0.335f)
                {
                    //Debug.Log("TOP");
                    myParent.jumpHeight = new Vector2(0.0f, 0.0f);

                    if (collisionOther.gameObject.name.StartsWith("Enemy"))
                    {
                        player.GetComponent<PM_Master>().CallEventDeductHealth(1);
                    }//end if
                    break;
                }//end else if
                else if (collisionOther.contacts[i].point.x > myParent.playerBody.position.x + 0.395f)
                {
                    //Debug.Log("BOTTOM");
                    myParent.jumpHeight = new Vector2(-myParent.moveSpeed * 45, 0.0f);

                    if (collisionOther.gameObject.name.StartsWith("Enemy"))
                    {
                        collisionOther.gameObject.GetComponent<AI_Master>().CallEventDeductHealth(1);
                        player.GetComponent<PM_ScoreInc>().combo++;

                        player.GetComponent<Rigidbody2D>().velocity = new Vector2(-7.5f, player.GetComponent<Rigidbody2D>().velocity.y);
                    }//end if
                    else
                    {
                        player.GetComponent<PM_ScoreInc>().combo = 0;
                        player.GetComponent<PM_ScoreInc>().scoreMultiplier = 1;
                    }//end else
                    break;
                }//end else if
            }//end if
        }//end for
    }//end OnCollisionEnter()

    private void OnCollisionStay2D(Collision2D collisionOther)
    {
        if (collisionOther.gameObject.name.StartsWith("Enemy"))
        {
            myParent.canJump = false;
            myParent.jumping = true;
        }//end if
        else if (collisionOther.gameObject.name.StartsWith("Invis"))
        {
            myParent.canJump = false;
            myParent.jumping = true;
        }//end if
        else
        {
            myParent.canJump = true;
            myParent.jumping = false;
        }//end else
    }//end OnCollisionStay2D()

    private void OnCollisionExit2D(Collision2D collisionOther)
    {
        myParent.canJump = false;
        myParent.jumping = true;
    }//end OnCollisionExit2D()
}//end class PlayerCollision
