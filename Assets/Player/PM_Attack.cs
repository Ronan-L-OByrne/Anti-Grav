using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_Attack : MonoBehaviour
{
    private PM_Master playerManagerMaster;
    public Rigidbody2D playerFist;
    public GameObject player;
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
        if (!attackingChk)
        {
            attackingChk = true;
            attackSpeed = 25;
        }//end if
    }//end PlayerAttack

    private void Start()
    {
        attackingChk = false;
        attackSpeed = 0;
        playerFist = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        Physics2D.IgnoreCollision(GameObject.Find("ColliderDetection").GetComponent<EdgeCollider2D>(), GetComponent<EdgeCollider2D>());
    }//end Start()

    private void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, player.GetComponent<PM_Movement>().curAngle);
        if (attackingChk && attackSpeed > -25)
        {
            playerFist.velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x + attackSpeed, player.GetComponent<Rigidbody2D>().velocity.y);
            attackSpeed--;
        }//end if
        else if (playerFist.position.x != player.GetComponent<Rigidbody2D>().position.x || playerFist.position.y != player.GetComponent<Rigidbody2D>().position.y)
        {
            attackingChk = false;
            playerFist.position = new Vector2(player.GetComponent<Rigidbody2D>().position.x, player.GetComponent<Rigidbody2D>().position.y);
        }//end else if
        else
        {
            attackingChk = false;
        }//end else
    }//end Update()
}//end class PM_Attack
