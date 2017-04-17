using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    //Variables
    public Rigidbody2D AIBody;
    private SpriteRenderer AISprite;
    //public static GameObject player;
    //public PM_Movement playerMov;
    public float AISpeed;

    // Use this for initialization
    void Start ()
    {
        //player = GameObject.Find("Player");
        //playerMov = player.GetComponent<PM_Movement>();
        AIBody.velocity = new Vector2(AIBody.velocity.x, AIBody.velocity.y - 0.2f);
        AISprite = GetComponent<SpriteRenderer>();
        AISpeed = 3.0f;
	}//end Start()

    private void OnCollisionEnter2D(Collision2D collisionOther)
    {
        AISpeed = -AISpeed;

        if (collisionOther.gameObject.name.StartsWith("Player"))
        {
            this.GetComponent<AI_Master>().CallEventDeductHealth(1);
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
