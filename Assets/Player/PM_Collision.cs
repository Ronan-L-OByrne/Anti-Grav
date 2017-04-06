using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_Collision : MonoBehaviour
{
    public PM_Movement myParent;

    private void Start()
    {
        myParent = transform.parent.GetComponent<PM_Movement>();
    }//end Start()

    void OnCollisionStay2D(Collision2D collisionOther)
    {
        //Collider2D collider = collisionOther.collider;
        //Vector3 center = collider.bounds.center;
        
        for (int i = 0; i < collisionOther.contacts.GetLength(0); i++)
        {
            myParent.canJump = true;
            if (myParent.expectedAngle == 0)
            {
                if (collisionOther.contacts[i].point.x > myParent.playerBody.position.x + 0.248f && collisionOther.contacts[i].point.y < myParent.playerBody.position.y + 0.2f && collisionOther.contacts[i].point.y > myParent.playerBody.position.y - 0.2f)
                {
                    //Debug.Log("RIGHT"); 0.5
                    myParent.jumpHeight = new Vector2(-myParent.moveSpeed * 35, myParent.moveSpeed * 45);
                    break;
                }//end if
                else if (collisionOther.contacts[i].point.x < myParent.playerBody.position.x - 0.248f && collisionOther.contacts[i].point.y < myParent.playerBody.position.y + 0.2f && collisionOther.contacts[i].point.y > myParent.playerBody.position.y - 0.2f)
                {
                    //Debug.Log("LEFT");
                    myParent.jumpHeight = new Vector2(myParent.moveSpeed * 35, myParent.moveSpeed * 45);
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
                    myParent.jumpHeight = new Vector2(0.0f, myParent.moveSpeed * 45);
                }//end else if
            }//end if
            else
            {
                if (collisionOther.contacts[i].point.y > myParent.playerBody.position.y + 0.248f && collisionOther.contacts[i].point.x < myParent.playerBody.position.x + 0.2f && collisionOther.contacts[i].point.x > myParent.playerBody.position.x - 0.2f)
                {
                    //Debug.Log("RIGHT");
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
                else if (collisionOther.contacts[i].point.x > myParent.playerBody.position.x + 0.4f)
                {
                    //Debug.Log("BOTTOM");
                    myParent.jumpHeight = new Vector2(-myParent.moveSpeed * 45, 0.0f);
                }//end else if
            }//end else
        }//end for*/
    }//end OnCollisionStay()
}//end class PlayerCollision
