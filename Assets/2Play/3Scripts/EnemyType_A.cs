using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType_A : MonoBehaviour
{
    Rigidbody2D rigid;
    CapsuleCollider2D enemyCollider;
    SpriteRenderer spriteRender;

    public int nextMove;
    public float speed;
    public int healthPoint;
    public string enemyName;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<CapsuleCollider2D>();
        spriteRender = GetComponent<SpriteRenderer>();

        switch (enemyName)
        {
            case "Small":
                healthPoint = 10;
                break;
            case "Large":
                healthPoint = 30;
                break;
        }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            onDamaged(bullet.damage);
            collision.gameObject.SetActive(false);
        }
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

        hittedColor();
        Invoke("changeColor", 0.2f);

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

    public void changeColor()
    {
        spriteRender.color = new Color(1, 1, 1, 1);
    }

    public void hittedColor()
    {
        spriteRender.color = new Color(1, 1, 1, 0.4f);
    }
  
}
