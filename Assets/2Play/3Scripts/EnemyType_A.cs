using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType_A : MonoBehaviour
{
    Rigidbody2D rigid;
    CapsuleCollider2D enemyCollider;
    SpriteRenderer spriteRender;

    public int nextMove;
    public int speed;
    public int healthPoint;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<CapsuleCollider2D>();
        spriteRender = GetComponent<SpriteRenderer>();

        enemyMove();
    }

    void FixedUpdate()
    {
        //Move
        rigid.velocity = new Vector2(rigid.velocity.x, nextMove) * speed;

        //Check 
        Vector2 verticalVec = new Vector2(rigid.position.x, rigid.position.y + (nextMove* 0.2f));

        Debug.DrawRay(verticalVec, Vector3.up, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(verticalVec, Vector3.up, 1, LayerMask.GetMask("platform"));

        if (rayHit.collider != null)
        {
            turn();
        }
    }

    void enemyMove()
    {
        nextMove = Random.Range(-1, 2);

        float nextMoveTime = Random.Range(2f, 5f);
        Invoke("enemyMove", nextMoveTime);
    }

    void turn()
    {
        nextMove = nextMove * (-1);
        CancelInvoke();
        Invoke("enemyMove", 3);
    }

    public void onDamaged(int damage)
    {
        healthPoint -= damage;

        //Sprite Alpha
        spriteRender.color = new Color(1, 1, 1, 0.4f);

        //collider Disable
        if (healthPoint <= 0)
        {
            enemyCollider.enabled = false;
            //Die effect Jump
            rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            //Destroy
            Invoke("deActive", 3);
        }

       
    }

    void deActive()
    {
        gameObject.SetActive(false);

    }
}
