using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    //Variables
    public Rigidbody2D AIBody;
    private SpriteRenderer AISprite;
    private GameObject cameraChk;
    public float AISpeed;

    // Use this for initialization
    void Start ()
    {
        AIBody.velocity = new Vector2(AIBody.velocity.x, AIBody.velocity.y - 0.2f);
        cameraChk = GameObject.Find("Main Camera");
        AISprite = GetComponent<SpriteRenderer>();
        AISpeed = 3.0f;
	}//end Start()

    private void OnCollisionEnter2D(Collision2D collisionOther)
    {
        AISpeed = -AISpeed;
    }//end OnCollisionEnter()

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

        if(this.transform.position.x <= cameraChk.transform.position.x-8.1 && this.gameObject.name.Contains("Clone"))
        {
            Destroy(this.gameObject);
        }//end if
    }//end Update()
}//end class AI_Movement
