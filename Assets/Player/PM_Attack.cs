using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_Attack : MonoBehaviour
{
    private PM_Master playerManagerMaster;
    public Rigidbody2D playerFist;
    public Rigidbody2D playerBody;
    private bool attackingChk;
    private int attackSpeed;

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
        attackingChk = true;
        attackSpeed = 10;
    }//end PlayerAttack

    private void Start()
    {
        attackingChk = false;
        attackSpeed = 0;
        playerFist = GetComponent<Rigidbody2D>();
        playerBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }//end Start()

    private void Update()
    {
        if (attackingChk && attackSpeed > 0)
        {
            playerFist.velocity = new Vector2(0.5f, 0);
            attackSpeed--;
        }//end if
        else if(playerFist.position.x != playerBody.position.x || playerFist.position.y != playerBody.position.y)
        {
            if (playerFist.position.x > playerBody.position.x)
            {
                playerFist.velocity = new Vector2(-0.5f, 0);
            }//end if
            else if (playerFist.position.x < playerBody.position.x)
            {
                playerFist.velocity = new Vector2(0.5f, 0);
            }//end if

            if (playerFist.position.y > playerBody.position.y)
            {
                playerFist.velocity = new Vector2(0, -0.5f);
            }//end if
            else if (playerFist.position.y < playerBody.position.y)
            {
                playerFist.velocity = new Vector2(0, 0.5f);
            }//end if
        }//end else if
    }//end Update()
}//end class PM_Attack
