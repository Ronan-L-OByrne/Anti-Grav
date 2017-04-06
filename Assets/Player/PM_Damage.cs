using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_Damage : MonoBehaviour
{
    private PM_Master playerManagerMaster;
    private PM_Health playerHealth;
    private PM_Movement myParent;

    // Use this for initialization
    void Start ()
    {
        myParent = transform.parent.GetComponent<PM_Movement>();
        playerHealth = transform.parent.GetComponent<PM_Health>();
        playerManagerMaster = transform.parent.GetComponent<PM_Master>();
    }//end Start()

    void OnCollisionEnter2D(Collision2D collisionOther)
    {
        for (int i = 0; i < collisionOther.contacts.GetLength(0); i++)
        {
            myParent.canJump = true;
            if (myParent.expectedAngle == 0)
            {
                if (collisionOther.gameObject.name.StartsWith("Enemy") && collisionOther.contacts[i].point.x > myParent.playerBody.position.x + 0.248f && collisionOther.contacts[i].point.y < myParent.playerBody.position.y + 0.2f && collisionOther.contacts[i].point.y > myParent.playerBody.position.y - 0.2f)
                {
                    //Debug.Log("RIGHT");
                    playerManagerMaster.CallEventDeductHealth(1);
                    break;
                }//end if
                else if (collisionOther.gameObject.name.StartsWith("Enemy") && collisionOther.contacts[i].point.x < myParent.playerBody.position.x - 0.248f && collisionOther.contacts[i].point.y < myParent.playerBody.position.y + 0.2f && collisionOther.contacts[i].point.y > myParent.playerBody.position.y - 0.2f)
                {
                    //Debug.Log("LEFT");
                    playerManagerMaster.CallEventDeductHealth(1);
                    break;
                }//end else if
            }//end for
            else
            {
                if (collisionOther.gameObject.name.StartsWith("Enemy") && collisionOther.contacts[i].point.y > myParent.playerBody.position.y + 0.248f && collisionOther.contacts[i].point.x < myParent.playerBody.position.x + 0.2f && collisionOther.contacts[i].point.x > myParent.playerBody.position.x - 0.2f)
                {
                    //Debug.Log("RIGHT");
                    playerManagerMaster.CallEventDeductHealth(1);
                    break;
                }//end if
                else if (collisionOther.gameObject.name.StartsWith("Enemy") && collisionOther.contacts[i].point.y < myParent.playerBody.position.y - 0.248f && collisionOther.contacts[i].point.x < myParent.playerBody.position.x + 0.2f && collisionOther.contacts[i].point.x > myParent.playerBody.position.x - 0.2f)
                {
                    //Debug.Log("LEFT");
                    playerManagerMaster.CallEventDeductHealth(1);
                    break;
                }//end else if
            }//end else7
        }//end for
    }//end OnCollisionEnter2D

    void OnGUI()
    {
        // Make a background box
        GUI.Box(new Rect(10, 10, 70, 23), "Health: " + playerHealth.playerHealth);
    }//end OnGUI()
}//end class PlayerDamagepublic class GUITest : MonoBehaviour {



