using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seaurchin_Properties : MonoBehaviour
{
    Rigidbody2D rigid;
    CircleCollider2D collid;
    Monster_Base monsterBase;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        collid = gameObject.GetComponent<CircleCollider2D>();
        monsterBase = gameObject.GetComponent<Monster_Base>();
    }

    private void Start()
    {
        monsterBase.set_Invincible();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
        {
            other.GetComponent<Bullet_Properties>().deActivate();
        }
    }
}
