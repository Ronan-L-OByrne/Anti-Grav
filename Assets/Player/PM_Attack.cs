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

    void PlayerAttack()
    {
        if (!attackingChk && attackSpeed == 0)
        {
            startTime = Time.time;
            attackingChk = true;
            journeyLength = Vector2.Distance(transform.position, new Vector2(player.transform.position.x + 2, player.transform.position.y));
            //attackSpeed = 1;
        }//end if
    }//end PlayerAttack

    private void Start()
    {
        attackingChk = false;
        attackSpeed = 0;
        playerFist = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        Physics2D.IgnoreCollision(GameObject.Find("ColliderDetection").GetComponent<EdgeCollider2D>(), GetComponent<BoxCollider2D>());
    }//end Start()

    private void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, player.GetComponent<PM_Movement>().curAngle);
        if (attackingChk)
        {
            float distCovered = (Time.time - startTime) * .5f;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector2.Lerp(transform.position, new Vector2((player.transform.position.x + 2), player.transform.position.y), fracJourney);
            attackSpeed += 1;

            if(attackSpeed >= 25)
            {
                startTime = Time.time;
                attackingChk = false;
                journeyLength = Vector2.Distance(transform.position, new Vector2(player.transform.position.x - 1, player.transform.position.y));
            }//end if
        }//end if
        else if(!attackingChk && attackSpeed > 0)
        {
            float distCovered = (Time.time - startTime) * .5f;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector2.Lerp(transform.position, new Vector2((player.transform.position.x - 1), player.transform.position.y), fracJourney);
            attackSpeed -= 1;
        }//end else if
        else if (playerFist.position.x != player.transform.position.x || playerFist.position.y != player.transform.position.y)
        {
            //Debug.Log("else if");
            //attackingChk = false;
            attackSpeed = 0;
            transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
        }//end else if
        else
        {
            attackingChk = false;
        }//end else
    }//end Update()
}//end class PM_Attack
