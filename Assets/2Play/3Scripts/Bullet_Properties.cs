using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Properties : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletHold;
    [SerializeField] public int damage;

    Vector3 disabled;
    Rigidbody2D rigid;
    GameObject character;
    GameObject gun;
    // Start is called before the first frame update
    private void Awake()
    {
        gun = GameObject.Find("Gun");
        character = GameObject.Find("character");
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        disabled = new Vector3(-1000f, -1000f, 0);
        deActivate();
    }


    public void Activate(int comp, int x, int y)
    {
        //Debug.Log("Activated");
        Vector3 basePosition = character.transform.position;
        Vector3 addVector = new Vector3((float)x, (float)y, 0);
        rigid.transform.position = basePosition + addVector;
        rigid.velocity = new Vector3(comp * bulletSpeed, 0f, 0f);
        StartCoroutine(hold());
    }

    IEnumerator hold()
    {
        yield return new WaitForSeconds(bulletHold);
        deActivate();
    }

    public void deActivate()
    {
        //Debug.Log("deActivated");
        rigid.transform.position = disabled;
        rigid.velocity = new Vector3(0f, 0f, 0f);
        gun.GetComponent<BulletManager>().cylinder.Enqueue(gameObject);
    }
}

