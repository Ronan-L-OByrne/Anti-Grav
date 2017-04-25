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

    private void OnCollisionEnter2D(Collision2D collisionOther)
    {
        if (collisionOther.gameObject.name.StartsWith("Enemy"))
        {
            if ((myParent.expectedAngle == 0 && collisionOther.contacts[0].point.y > myParent.playerBody.position.y - 0.3f) || (myParent.expectedAngle == 90 && collisionOther.contacts[0].point.x < myParent.playerBody.position.x + 0.3f))
            {
                player.GetComponent<PM_Master>().CallEventDeductHealth(1);
            }//end if
        }//end if
        else
        {
            player.GetComponent<PM_ScoreInc>().combo = 0;
        }//end else
    }//end OnCollisionEnter

    void OnCollisionStay2D(Collision2D collisionOther)
    {
        if (collisionOther.gameObject.name.StartsWith("Enemy"))
        {
            myParent.canJump = false;
            myParent.jumping = true;
        }//end if
        else
        {
            player.GetComponent<PM_ScoreInc>().scoreMultiplier = 1;
            myParent.canJump = true;
            myParent.jumping = false;
        }//end else

        for (int i = 0; i < collisionOther.contacts.GetLength(0); i++)
        {
            if (collisionOther.gameObject.name.StartsWith("Invis"))
            {
                myParent.canJump = false;
                myParent.jumping = false;
            }//end if
            else
            {
                if (myParent.expectedAngle == 0)
                {
                    if (collisionOther.contacts[i].point.x > myParent.playerBody.position.x + 0.23f && collisionOther.contacts[i].point.y < myParent.playerBody.position.y + 0.25f && collisionOther.contacts[i].point.y > myParent.playerBody.position.y - 0.4f)
                    {
                        //Debug.Log("RIGHT");
                        myParent.jumpHeight = new Vector2(-myParent.moveSpeed * 35, myParent.moveSpeed * 45);
                        break;
                    }//end if
                    else if (collisionOther.contacts[i].point.x < myParent.playerBody.position.x - 0.23f && collisionOther.contacts[i].point.y < myParent.playerBody.position.y + 0.25f && collisionOther.contacts[i].point.y > myParent.playerBody.position.y - 0.4f)
                    {
                        //Debug.Log("LEFT");
                        myParent.jumpHeight = new Vector2(myParent.moveSpeed * 35, myParent.moveSpeed * 45);
                        break;
                    }//end else if
                    else if (collisionOther.contacts[i].point.y > myParent.playerBody.position.y + .28f)
                    {
                        //Debug.Log("TOP");
                        myParent.jumpHeight = new Vector2(0.0f, 0.0f);
                    }//end else if
                    else if (collisionOther.contacts[i].point.y < myParent.playerBody.position.y - 0.435f)
                    {
                        //Debug.Log("BOTTOM");
                        myParent.jumpHeight = new Vector2(0.0f, myParent.moveSpeed * 45);

                        if (collisionOther.gameObject.name.StartsWith("Enemy"))
                        {
                            collisionOther.gameObject.GetComponent<AI_Master>().CallEventDeductHealth(1);
                            player.GetComponent<PM_ScoreInc>().combo++;

                            player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 7.5f);
                        }//end if
                    }//end else if
                }//end if
                else
                {
                    if (collisionOther.contacts[i].point.y > myParent.playerBody.position.y + 0.248f && collisionOther.contacts[i].point.x < myParent.playerBody.position.x + 0.2f && collisionOther.contacts[i].point.x > myParent.playerBody.position.x - 0.2f)
                    {
                        myParent.jumpHeight = new Vector2(-myParent.moveSpeed * 45, -myParent.moveSpeed * 35);
                        break;
                    }//end if
                    else if (collisionOther.contacts[i].point.y < myParent.playerBody.position.y - 0.248f && collisionOther.contacts[i].point.x < myParent.playerBody.position.x + 0.2f && collisionOther.contacts[i].point.x > myParent.playerBody.position.x - 0.2f)
                    {
                        //Debug.Log("LEFT");
                        myParent.jumpHeight = new Vector2(-myParent.moveSpeed * 45, myParent.moveSpeed * 35);
                        break;
                    }//end else if
                    else if (collisionOther.contacts[i].point.x < myParent.playerBody.position.x - 0.335f)
                    {
                        //Debug.Log("TOP");
                        myParent.jumpHeight = new Vector2(0.0f, 0.0f);
                    }//end else if
                    else if (collisionOther.contacts[i].point.x > myParent.playerBody.position.x + 0.435f)
                    {
                        //Debug.Log("BOTTOM");
                        myParent.jumpHeight = new Vector2(-myParent.moveSpeed * 45, 0.0f);

                        if (collisionOther.gameObject.name.StartsWith("Enemy"))
                        {
                            collisionOther.gameObject.GetComponent<AI_Master>().CallEventDeductHealth(1);
                            player.GetComponent<PM_ScoreInc>().combo++;

                            player.GetComponent<Rigidbody2D>().velocity = new Vector2(-7.5f, player.GetComponent<Rigidbody2D>().velocity.y);
                        }//end if
                    }//end else if
                }//end else
            }//end if
        }//end for*/
    }//end OnCollisionStay()
}//end class PlayerCollision
