using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionStay2D(Collision2D collisionOther)
    {
        PlayerMovement myParent = transform.parent.GetComponent<PlayerMovement>();
        Collider2D collider = collisionOther.collider;
        Vector3 center = collider.bounds.center;
        
        for (int i = 0; i < collisionOther.contacts.GetLength(0); i++)
        {
            myParent.canJump = true;
            if (myParent.expectedAngle == 0)
            {
                if (collisionOther.contacts[i].point.x > myParent.playerBody.position.x + 0.248f && collisionOther.contacts[i].point.y < myParent.playerBody.position.y + 0.2f && collisionOther.contacts[i].point.y > myParent.playerBody.position.y - 0.2f)
                {
                    //Debug.Log("RIGHT");
                    myParent.jumpHeight = new Vector2(-6.0f, 7.5f);
                    break;
                }//end if
                else if (collisionOther.contacts[i].point.x < myParent.playerBody.position.x - 0.248f && collisionOther.contacts[i].point.y < myParent.playerBody.position.y + 0.2f && collisionOther.contacts[i].point.y > myParent.playerBody.position.y - 0.2f)
                {
                    //Debug.Log("LEFT");
                    myParent.jumpHeight = new Vector2(6.0f, 7.5f);
                    break;
                }//end else if
                else if (collisionOther.contacts[i].point.y > myParent.playerBody.position.y + 0.335f)
                {
                    //Debug.Log("TOP");
                    myParent.jumpHeight = new Vector2(0.0f, 0.0f);
                }//end else if
                else if (collisionOther.contacts[i].point.y < myParent.playerBody.position.y - 0.4f)
                {
                    //Debug.Log("BOTTOM");
                    myParent.jumpHeight = new Vector2(0.0f, 7.5f);
                }//end else if
            }//end if
            else
            {
                if (collisionOther.contacts[i].point.y > myParent.playerBody.position.y + 0.248f && collisionOther.contacts[i].point.x < myParent.playerBody.position.x + 0.2f && collisionOther.contacts[i].point.x > myParent.playerBody.position.x - 0.2f)
                {
                    //Debug.Log("RIGHT");
                    myParent.jumpHeight = new Vector2(-7.5f, -6.0f);
                    break;
                }//end if
                else if (collisionOther.contacts[i].point.y < myParent.playerBody.position.y - 0.248f && collisionOther.contacts[i].point.x < myParent.playerBody.position.x + 0.2f && collisionOther.contacts[i].point.x > myParent.playerBody.position.x - 0.2f)
                {
                    //Debug.Log("LEFT");
                    myParent.jumpHeight = new Vector2(-7.5f, 6.0f);
                    break;
                }//end else if
                else if (collisionOther.contacts[i].point.x < myParent.playerBody.position.x - 0.335f)
                {
                    //Debug.Log("TOP");
                    myParent.jumpHeight = new Vector2(0.0f, 0.0f);
                }//end else if
                else if (collisionOther.contacts[i].point.x > myParent.playerBody.position.x + 0.4f)
                {
                    //Debug.Log("BOTTOM");
                    myParent.jumpHeight = new Vector2(-7.5f, 0.0f);
                }//end else if
            }//end else
        }//end for*/
    }//end OnCollisionStay()
}//end PlayerCollision
