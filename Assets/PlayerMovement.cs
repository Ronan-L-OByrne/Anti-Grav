using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float expectedAngle = 0.0f;
    public Vector2 Velocity, tempVelocity1;
    public bool canJump;
    public bool jumping;
    public bool[] right, bottom, left, top;
    private SpriteRenderer mySpriteRenderer;
    public float curRotation = 0.0f;

    static float time = 0.0f;

    // Use this for initialization
    void Start ()
    {
        Velocity.Set(0, -1);
        jumping = true;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }//end Start()

    //When the Player collides with an object
    private void OnCollisionStay2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        int i = 0;
        right = new bool[20];
        left = new bool[20];
        top = new bool[20];
        bottom = new bool[20];

        foreach (ContactPoint2D contacts in collision.contacts)
        {
            Vector3 contactPoint = collision.contacts[i].point;
            if (expectedAngle == 0.0f)
            {
                right[i]  = (contactPoint.x > transform.position.x + .1 && contactPoint.y > transform.position.y + .45 &&  mySpriteRenderer.flipX);
                left[i]   = (contactPoint.x < transform.position.x - .1 && contactPoint.y > transform.position.y + .45 && !mySpriteRenderer.flipX);
                bottom[i] = (contactPoint.y < transform.position.y - .25);
                top[i]    = (contactPoint.y > transform.position.y + .25);
                //Debug.Log(contactPoint.x + "    " + transform.position.y + "\n" + contactPoint.x + "   " + contactPoint.y + "   " + i);
            }//end if
            else if (expectedAngle == 90.0f)
            {
                right[i]  = (contactPoint.y > transform.position.x + .1 && contactPoint.x > transform.position.y + .45 && mySpriteRenderer.flipX);
                left[i]   = (contactPoint.y < transform.position.x - .1 && contactPoint.x > transform.position.y + .45 && !mySpriteRenderer.flipX);
                bottom[i] = (contactPoint.x > transform.position.y + .25);
                top[i]    = (contactPoint.x < transform.position.y - .25);
                //Debug.Log(contactPoint.x + "    " + transform.position.y + "\n" + contactPoint.x + "   " + contactPoint.y + "   " + i);
            }//end else*/

            i++;
        }//end foreach
        
        for(i = 0; i < 20; i++)
        {
            if (!((bottom[i] && right[i]) || (bottom[i] && left[i]) || (top[i] && right[i]) || (top[i] && left[i])))
            {
                if (bottom[i])
                {
                    bottom[0] = true;
                    Debug.Log("Bottom[" + i + "]");
                }//end if
                if (top[i])
                {
                    top[0] = true;
                    Debug.Log("Top[" + i + "]");
                }//end if
            }//end if

            if (right[i])
            {
                right[0] = true;
                Debug.Log("Right[" + i + "]");
            }//end if
            if (left[i])
            {
                left[0] = true;
                Debug.Log("Left[" + i + "]");
            }//end if
        }//end for

        if(bottom[0] && top[0])
        {
            bottom[0] = false;
        }//end for
        
        if(bottom[0])
        {
            canJump = true;
            jumping = false;
            Velocity.y = 0;
        }//end if
        else if(top[0])
        {
            canJump = false;
            jumping = true;
            Velocity.y = -0.25f;
        }//end else if

        if (right[0] || left[0])
        {
            Velocity.y = -.25f;
            Velocity.x = 0;
        }//end else if

        for (i = 0; i < 20; i++)
        {
            bottom[i] = false;
            top[i]    = false;
            left[i]   = false;
            right[i]  = false;
        }//end for

        checkKeys();
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
        transform.Translate(Velocity.x * Time.deltaTime, Velocity.y * Time.deltaTime, 0);

        if(transform.rotation.eulerAngles.z > 180)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }//end if
        else if (transform.rotation.eulerAngles.z > expectedAngle + 2 || transform.rotation.eulerAngles.z < expectedAngle - 2)
        {
            if (expectedAngle == 90)
            {
                Velocity.x = Mathf.Lerp(tempVelocity1.x, tempVelocity1.y, time);
            }//end if
            else
            {
                Velocity.x = Mathf.Lerp(tempVelocity1.x, -tempVelocity1.y, time);
            }//end if

            transform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(transform.rotation.eulerAngles.z, expectedAngle, time));

            time += 0.05f;
        }//end if
        else
        { 
            transform.eulerAngles = new Vector3(0, 0, expectedAngle);
        }//end else

        checkKeys();

        if (jumping)
        {
            if (Velocity.y > -50)
            {
                Velocity.y -= .1f;
            }//end if
        }//end if 

        if(Velocity.x >= .05f)
        {
            if (!jumping)
            {
                Velocity.x -= .05f;
            }//end if
            else
            {
                Velocity.x -= .025f;
            }//end else

            // if the variable isn't empty (we have a reference to our SpriteRenderer)
            if (mySpriteRenderer != null)
            {
                mySpriteRenderer.flipX = true;
            }//end if
        }//end if
        else if (Velocity.x <= -.05f)
        {
            if (!jumping)
            {
                Velocity.x += .05f;
            }//end if
            else
            {
                Velocity.x += .01f;
            }//end else

            // if the variable isn't empty (we have a reference to our SpriteRenderer)
            if (mySpriteRenderer != null)
            {
                mySpriteRenderer.flipX = false;
            }//end if
        }//end else if
        else if (Velocity.x >= -.05f && Velocity.x <= .05f)
        {
            Velocity.x = 0;
        }//end else if
    }//end Update()

    void checkKeys()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (expectedAngle == 0)
            {
                expectedAngle = 90;
            }//end if
            else if (expectedAngle == 90)
            {
                expectedAngle = 0;
            }//end if

            curRotation = transform.rotation.eulerAngles.z;
            tempVelocity1 = Velocity;
            //Velocity.x = Velocity.y;
            Velocity.y = 0;
            time = 0.0f;
        }//end if

        if (Input.GetKey(KeyCode.D) && Velocity.x < 5)
        {
            if (jumping)
            {
                Velocity.x += 0.05f;
            }//end if
            else
            {
                Velocity.x += 0.2f;
            }//end else
        }//end if

        if (Input.GetKey(KeyCode.A) && Velocity.x > -5)
        {
            if (jumping)
            {
                Velocity.x -= 0.05f;
            }//end if
            else
            {
                Velocity.x -= 0.2f;
            }//end else
        }//end if

        if (Input.GetKeyDown(KeyCode.W) && canJump)
        {
            Velocity.y = 5;
        }//end if
    }//end checkKeys()
}//end class PlayerMovement
