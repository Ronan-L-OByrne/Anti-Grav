using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_Attack : MonoBehaviour
{
    private PM_Master playerManagerMaster;
    public Rigidbody2D playerFist;
    private GameObject player;
    private bool attackingChk;
    private float attackSpeed;
    public float attackDist;

    private float startTime;
    private float journeyLength;
    private Transform startMarker;
    private Transform endMarker;

    private void OnEnable()
    {
        SetInitReferences();

        playerManagerMaster.AttackEvent += PlayerAttack;
    }//end OnEnable()

    private void OnDisable()
    {
        playerManagerMaster.AttackEvent += PlayerAttack;
    }//end OnDisable()

    private void SetInitReferences()
    {
        playerManagerMaster = GameObject.Find("Player").GetComponent<PM_Master>();
    }//end setInitReferences()

    private void OnCollisionEnter2D(Collision2D collisionOther)
    {
        if (collisionOther.gameObject.name.StartsWith("Enemy"))
        {
            //Debug.Log("Hit");
            collisionOther.gameObject.GetComponent<AI_Master>().CallEventDeductHealth(1);
        }//end if
    }//end OnCollisionEnter2D()

    private void PlayerAttack(bool dirChk)
    {
        if (!attackingChk && attackSpeed == 0)
        {
            startTime = Time.time;
            attackingChk = true;
            this.GetComponent<SpriteRenderer>().flipX = dirChk;

            if (dirChk)
            {
                attackDist = 2;
                //Debug.Log(attackDist);
            }//end if
            else if (!dirChk)
            {
                attackDist = -2;
                //Debug.Log(attackDist);
            }//end if
            
            if (player.GetComponent<PM_Movement>().curAngle == 0)
            {
                journeyLength = Vector2.Distance(transform.position, new Vector2(player.transform.position.x + attackDist, player.transform.position.y));
            }//end if
            else
            {
                journeyLength = Vector2.Distance(transform.position, new Vector2(player.transform.position.x, player.transform.position.y + attackDist));
            }//end else
        }//end if
    }//end PlayerAttack()

    private void Start()
    {
        attackingChk = false;
        attackSpeed = 0;
        playerFist = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        Physics2D.IgnoreLayerCollision(9, 8, true);
    }//end Start()

    private void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, player.GetComponent<PM_Movement>().curAngle);

        if (player.GetComponent<PM_Movement>().curAngle == 0)
        {
            if (attackingChk)
            {
                float distCovered = (Time.time - startTime) * .5f;
                float fracJourney = distCovered / journeyLength;

                if (attackDist > 0)
                {
                    //Debug.Log((player.transform.position.x + (attackDist + (player.GetComponent<Rigidbody2D>().velocity.x / attackDist))));
                    transform.position = Vector2.Lerp(transform.position, new Vector2((player.transform.position.x + (attackDist + (player.GetComponent<Rigidbody2D>().velocity.x / attackDist))), player.transform.position.y), fracJourney);
                }//end i
                else if (attackDist < 0)
                {
                    //Debug.Log(attackDist - (player.GetComponent<Rigidbody2D>().velocity.x / attackDist));
                    transform.position = Vector2.Lerp(transform.position, new Vector2((player.transform.position.x + (attackDist - Mathf.Abs(Mathf.Abs(player.GetComponent<Rigidbody2D>().velocity.x) / Mathf.Abs(attackDist)))), player.transform.position.y), fracJourney);
                }//end else
                attackSpeed += 1;

                if (attackSpeed >= 25)
                {
                    startTime = Time.time;
                    attackingChk = false;
                    journeyLength = Vector2.Distance(transform.position, new Vector2(player.transform.position.x - attackDist/2, player.transform.position.y));
                }//end if
            }//end if
            else if (!attackingChk && attackSpeed > 0)
            {
                float distCovered = (Time.time - startTime) * .5f;
                float fracJourney = distCovered / journeyLength;
                transform.position = Vector2.Lerp(transform.position, new Vector2((player.transform.position.x), player.transform.position.y), fracJourney);
                attackSpeed -= 1;
            }//end else if
            else if (playerFist.position.x != player.transform.position.x || playerFist.position.y != player.transform.position.y)
            {
                attackSpeed = 0;
                transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
            }//end else if
            else
            {
                attackingChk = false;
                attackDist = 0;
            }//end else
        }//end if
        else
        {
            if (attackingChk)
            {
                float distCovered = (Time.time - startTime) * .5f;
                float fracJourney = distCovered / journeyLength;
                transform.position = Vector2.Lerp(transform.position, new Vector2((player.transform.position.x), player.transform.position.y + (attackDist / 2) * (attackDist + (player.GetComponent<Rigidbody2D>().velocity.y / Mathf.Abs(attackDist)))), fracJourney);
                attackSpeed += 1;

                if (attackSpeed >= 25)
                {
                    startTime = Time.time;
                    attackingChk = false;
                    journeyLength = Vector2.Distance(transform.position, new Vector2(player.transform.position.x, player.transform.position.y - attackDist/2));
                }//end if
            }//end if
            else if (!attackingChk && attackSpeed > 0)
            {
                float distCovered = (Time.time - startTime) * .5f;
                float fracJourney = distCovered / journeyLength;
                transform.position = Vector2.Lerp(transform.position, new Vector2((player.transform.position.x), player.transform.position.y), fracJourney);
                attackSpeed -= 1;
            }//end else if
            else if (playerFist.position.x != player.transform.position.x || playerFist.position.y != player.transform.position.y)
            {
                attackSpeed = 0;
                transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
            }//end else if
            else
            {
                attackingChk = false;
                attackDist = 0;
            }//end else
        }//end else
    }//end Update()
}//end class PM_Attack
