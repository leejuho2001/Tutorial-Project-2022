using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SeaShell : MonoBehaviour
{
    Rigidbody2D rigid;
    CapsuleCollider2D enemyCollider;
    SpriteRenderer spriteRender;

    float curTime;
    float coolTime;

    public int nextMove;
    public int curSpeed;
    public int healthPoint;
    public float distance;
    public float Range;

    public Transform target;
    public Transform pos;
    public Vector2 boxSize;
    public Vector3 dif;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<CapsuleCollider2D>();
        spriteRender = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame

    private void Update()
    {
        coolDown();

        distance = Vector3.Distance(transform.position, target.position);
        //dif = transform.positio - target.position
    }
    void FixedUpdate()
    {

        if (distance <= Range && curTime >= coolTime)
        {
            attack();
        }
    }


    void coolDown()
    {
        curTime += Time.deltaTime;
    }
    public void attack()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach (Collider2D collider in colliders)
        {

        }

        curTime = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}
