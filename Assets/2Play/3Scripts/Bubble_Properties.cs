using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble_Properties : MonoBehaviour
{

    Vector3 disabled;

    Rigidbody2D rigid;
    CircleCollider2D collid;
    SpriteManager spriteManager;
    // Start is called before the first frame update

    private void Awake()
    {
        collid = gameObject.GetComponent<CircleCollider2D>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        spriteManager = gameObject.GetComponent<SpriteManager>();
    }
    void Start()
    {
        disabled = new Vector3(-800f, -1000f, 0);
        spriteManager.spriteReSize();
    }

    public void Activate(GameObject seeWeed, float x, float y)
    {
        Debug.Log("Bubble Activated");
        Vector3 basePosition = seeWeed.transform.position;
        Vector3 pivot = new Vector3(
            basePosition.x - seeWeed.transform.lossyScale.x / 2,
            basePosition.y - seeWeed.transform.lossyScale.y / 2,
            basePosition.z);

        Vector3 addVector = new Vector3(
            seeWeed.transform.lossyScale.x * x,
            seeWeed.transform.lossyScale.y * y, 
            0);

        rigid.transform.position = pivot + addVector;

    }


    public void deActivate()
    {
        Debug.Log("Bubble deActivated");
        rigid.transform.position = disabled;
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<playable.CharacterSpec>().p_Heal(3);
            deActivate();
        }
    }
}
