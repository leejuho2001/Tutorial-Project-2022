using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Properties : MonoBehaviour
{
    [SerializeField] float velocity;

    GameObject mainCamera;
    Rigidbody2D rigid;
    Monster_Base monsterBase;

    bool activated;
    // Start is called before the first frame update
    private void Awake()
    {
        activated = false;
        mainCamera = GameObject.Find("Main Camera");
        rigid = gameObject.GetComponent<Rigidbody2D>();
        monsterBase = gameObject.GetComponent<Monster_Base>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x
            - gameObject.transform.lossyScale.x / 2
            -640
            - mainCamera.transform.position.x < 50
            && ! activated)
        {
            activate();
        }
        if (monsterBase.givHP() == 0) deActivate();
    }

    void activate()
    {
        Debug.Log("Fish activated");
        activated = true;
        Vector3 v = new Vector3(-velocity, 0f, 0f);
        rigid.velocity = v;
    }

    void deActivate()
    {
        Vector3 stop = new Vector3(0, 0, 0);
        Vector3 disabled = new Vector3(-600, -1000, 0);
        
        rigid.velocity = stop;
        rigid.transform.position = disabled;
    }
}
