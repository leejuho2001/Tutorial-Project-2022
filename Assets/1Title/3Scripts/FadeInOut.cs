using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    SpriteRenderer sr;
    public GameObject go;
    void Start()
    {
        sr = go.GetComponent<SpriteRenderer>();
        StartCoroutine("FadeOut");
    }

    void Update()
    {
     
    }

    IEnumerator FadeOut()
    {
        for(int i = 10; i >= 0; i--)
        {
            float f = i / 10.0f;
            Color c = sr.material.color;
            c.a = f;
            sr.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
