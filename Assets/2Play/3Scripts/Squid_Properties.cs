using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squid_Properties : MonoBehaviour
{
    [SerializeField] float baseVelocity;

    bool activated;
    Rigidbody2D rigid;
    CircleCollider2D collid;

    // Start is called before the first frame update

    private void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        collid = gameObject.GetComponent<CircleCollider2D>();
        activated = true;
    }
    void Start()
    {
        StartCoroutine(moving());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator moving()
    {
        Debug.Log("squid activated");
        while (activated == true)
        {
            rigid.velocity = new Vector3(0, baseVelocity, 0);
            yield return new WaitForSeconds(0.5f);
            rigid.velocity = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(0.15f);
            rigid.velocity = new Vector3(0, -(baseVelocity/5), 0);
            yield return new WaitForSeconds(2.5f);
            rigid.velocity = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(0.15f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

        }
    }
}
