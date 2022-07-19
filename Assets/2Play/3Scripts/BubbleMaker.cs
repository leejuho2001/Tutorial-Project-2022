using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMaker : MonoBehaviour
{
    public GameObject prefabBubble;

    private void Update()
    {
        generate();
    }



    void generate()
    {
        GameObject airBubble = Instantiate(prefabBubble, transform.position, Quaternion.identity);
        airBubble.transform.position = transform.position;
        Rigidbody2D rigid = airBubble.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up, ForceMode2D.Impulse);

        Bubble bubbleCom = airBubble.GetComponent<Bubble>();
        bubbleCom.isActive = true;

        float spawnTime = Random.Range(1f, 6f);
        Invoke("generate", spawnTime);
    }
}
