using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ink_Properties : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 baseSize;
    Vector3 startSize;

    private void Awake()
    { 
    }
    void Start()
    {
        Vector3 baseSize = gameObject.transform.localScale;
        Vector3 startSize = new Vector3(10, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator inkOn(int time)
    {
        Vector3 delta = (baseSize - startSize);
        delta.x /= (float)time;
        delta.y /= (float)time;
        gameObject.transform.localScale = startSize;
        for (int i = 0; i < time; i++)
        {
            Vector3 nowSize = gameObject.transform.localScale;
            yield return new WaitForSeconds(0.05f);
            nowSize.x += delta.x;
            nowSize.y += delta.y;
            gameObject.transform.localScale = nowSize;
        }
    }

    IEnumerator fadeout(int time)
    {
        float delta = -1 / time;
        for(int i = 0; i < time; i++)
        {
            Color nowColor = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
            nowColor.a -= delta;
            yield return new WaitForSeconds(0.1f);
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = nowColor;
        }
    }
}
