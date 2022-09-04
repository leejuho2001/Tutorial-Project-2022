using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalin : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer ab;
    public GameObject go1;
    [SerializeField] SceneChanger _scenechanger;
    


    private void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        ab = go1.GetComponent<SpriteRenderer>();
        StartCoroutine("FadeOut");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Invoke("Scenechange", 3);
            StartCoroutine("FadeIn");
        }
    }

    void Scenechange()
    {
        _scenechanger.ChangeSceneByName_B();
    }

    IEnumerator FadeIn()
    {
        for (int i = 0; i <= 3; i++)
        {
            float f = i / 3.0f;
            Color c = ab.material.color;
            c.a = f;
            ab.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FadeOut()
    {
        for (int i = 3; i >= 0; i--)
        {
            float f = i / 3.0f;
            Color c = ab.material.color;
            c.a = f;
            ab.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
