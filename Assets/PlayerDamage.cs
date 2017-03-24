using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    //Variables
    public int playerHealth;
    PlayerMovement myParent;

    // Use this for initialization
    void Start ()
    {
        playerHealth = 5;
        myParent = transform.parent.GetComponent<PlayerMovement>();
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
                    playerHealth--;
                    break;
                }//end if
                else if (collisionOther.gameObject.name.StartsWith("Enemy") && collisionOther.contacts[i].point.x < myParent.playerBody.position.x - 0.248f && collisionOther.contacts[i].point.y < myParent.playerBody.position.y + 0.2f && collisionOther.contacts[i].point.y > myParent.playerBody.position.y - 0.2f)
                {
                    //Debug.Log("LEFT");
                    playerHealth--;
                    break;
                }//end else if
            }//end for
            else
            {
                if (collisionOther.gameObject.name.StartsWith("Enemy") && collisionOther.contacts[i].point.y > myParent.playerBody.position.y + 0.248f && collisionOther.contacts[i].point.x < myParent.playerBody.position.x + 0.2f && collisionOther.contacts[i].point.x > myParent.playerBody.position.x - 0.2f)
                {
                    //Debug.Log("RIGHT");
                    playerHealth--;
                    break;
                }//end if
                else if (collisionOther.gameObject.name.StartsWith("Enemy") && collisionOther.contacts[i].point.y < myParent.playerBody.position.y - 0.248f && collisionOther.contacts[i].point.x < myParent.playerBody.position.x + 0.2f && collisionOther.contacts[i].point.x > myParent.playerBody.position.x - 0.2f)
                {
                    //Debug.Log("LEFT");
                    playerHealth--;
                    break;
                }//end else if
            }//end else7
        }//end for
    }//end OnCollisionEnter2D

    private void Update()
    {
        if(playerHealth <= 0)
        {
            myParent.playerBody.position = new Vector3(0,0, -2);
            playerHealth = 5;
        }//end if
    }//end Update()

    void OnGUI()
    {
        // Make a background box
        GUI.Box(new Rect(10, 10, 70, 23), "Health: " + playerHealth);
    }//end OnGUI()
}//end class PlayerDamagepublic class GUITest : MonoBehaviour {



