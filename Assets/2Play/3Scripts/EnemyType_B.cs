using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType_B : MonoBehaviour
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
        rigid.velocity = new Vector2(nextMove,rigid.velocity.y) * speed;

        //Check 
        Vector2 HorizonVector = new Vector2(rigid.position.x + (nextMove * 0.2f), rigid.position.y );
        Debug.DrawRay(HorizonVector, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(HorizonVector, Vector3.down, 1, LayerMask.GetMask("platform"));

        if (rayHit.collider == null)
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
            Invoke("DeActive", 3);
        }


    }

    void DeActive()
    {
        gameObject.SetActive(false);

    }
}
