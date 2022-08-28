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
    public int jumpPower;

    public GameObject shootingInk;
    public Transform pos;
    public float cooltime;
    private float curtime;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<CapsuleCollider2D>();
        spriteRender = GetComponent<SpriteRenderer>();

        enemyMove();
    }

    void FixedUpdate()
    {
        Invoke("Jump", 5);
    }

    void Update()
    {
        if(curtime >= cooltime)
        {
            shooting();
            curtime = 0;
        }

        curtime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Bullet_Properties bullet = collision.gameObject.GetComponent<Bullet_Properties>();
            onDamaged(bullet.damage);
            collision.gameObject.SetActive(false);
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
        hittedColor();
        Invoke("changeColor", 0.2f);

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

    void Jump()
    {
        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }
    public void shooting()
    {
        Instantiate(shootingInk, pos.position, transform.rotation);
    }

    void DeActive()
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
