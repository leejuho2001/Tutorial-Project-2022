using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType_C : MonoBehaviour
{
    Rigidbody2D rigid;
    CapsuleCollider2D enemyCollider;
    SpriteRenderer spriteRender;

    public int nextMove;
    public int curSpeed;
    public int healthPoint;

    public float distance;
    public float chaseRange;

    public Transform target;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<CapsuleCollider2D>();
        spriteRender = GetComponent<SpriteRenderer>();

        enemyMove();
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);
    }
    void FixedUpdate()
    {
        if (distance > chaseRange)
        {
            enemyMove();
        }
        else if (distance <= chaseRange)
        {
            chase();
        }
    }

    void enemyMove()
    {
        nextMove = Random.Range(-1, 2);
        //Move
        rigid.velocity = new Vector2(rigid.velocity.x, nextMove) * curSpeed;

        //Check 
        Vector2 verticalVec = new Vector2(rigid.position.x, rigid.position.y + (nextMove * 0.2f));
        Debug.DrawRay(verticalVec, Vector3.up, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(verticalVec, Vector3.up, 1, LayerMask.GetMask("platform"));

        if (rayHit.collider != null)
        {
            turn();
        }

        float nextMoveTime = Random.Range(2f, 5f);
        Invoke("enemyMove", nextMoveTime);
    }

    void chase()
    {
        Vector3 dirVec = target.position - transform.position;
        transform.Translate(dirVec * curSpeed * Time.deltaTime);
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
