using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Properties : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D collid;
    SpriteRenderer sprite;
    SpriteManager manager;

    [SerializeField] GameObject[] connectedObject;
    [SerializeField] float ONTime;

    Color normal;
    Color on;

    private bool isActivated;

    private void Awake()
    {
        collid = gameObject.GetComponent<BoxCollider2D>();
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        manager = gameObject.GetComponent<SpriteManager>();
        isActivated = false;
        normal = new Color(246/255f, 1, 194/255f);
        on = new Color(1, 98/255f, 229/255f);
    }

    void Start()
    {
        Vector3 objectScale = transform.localScale;
        reSize(objectScale);
        manager.spriteReSize();
        sprite.color = normal;
    }

    IEnumerator changeColor(float time)
    {
        sprite.color = on;
        isActivated = true;
        yield return new WaitForSeconds(time);
        sprite.color = normal;
        isActivated = false;
    }

    private void reSize(Vector3 vector)
    {
        Transform trans = transform.parent;
        transform.parent = null;
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.parent = trans;

        Transform sprite = transform.GetChild(0).transform;
        collid.size = new Vector2(vector.x, vector.y);
        sprite.localScale = vector;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            collision.GetComponent<Bullet_Properties>().deActivate();

            /*if (isActivated == false)
            {
                StartCoroutine(changeColor(ONTime));
                for (int i = 0; i < connectedObject.Length; i++)
                {
                    string tag = connectedObject[is.tag;
                    if (tag == "Pipe")
                    {
                        Pipe_Properties property = connectedObject[i].GetComponent<Pipe_Properties>();
                        if (property.givIsOn() == true) property.deActivate();
                        else property.activate();
                    }
                }
            } */// type1

            if (isActivated == true)
            {
                isActivated = false;
                sprite.color = normal;
            }
            else
            {
                isActivated = true;
                sprite.color = on;
            }

            for (int i = 0; i < connectedObject.Length; i++)
            {
                string tag = connectedObject[i].tag;
                if (tag == "Pipe")
                {
                    Pipe_Properties property = connectedObject[i].GetComponent<Pipe_Properties>();
                    if (property.givIsOn() == true)
                        property.deActivate();
                    else
                        property.activate();
                }

                if (tag == "test")
                {
                    TestSwitchObj_Propertiess property = connectedObject[i].GetComponent<TestSwitchObj_Propertiess>();
                    if (property.givIsOn() == true)
                        property.deActivate();
                    else
                        property.activate();
                }
            }
            //type2
        }
    }
}
