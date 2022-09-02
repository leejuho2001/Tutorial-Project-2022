using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    // Start is called before the first frame update

    SpriteRenderer sprite;
    void Awake()
    {
        sprite = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spriteReSize()
    {

    }

    IEnumerator hit(int time)
    {
        Color baseColor = sprite.color;
        Color hitColor = new Color(1, 0, 0);

        float deltaR = (baseColor.r - hitColor.r) / time;
        float deltaG = (baseColor.g - hitColor.g) / time;
        float deltaB = (baseColor.b - hitColor.b) / time;
        sprite.color = hitColor;

        for(int i = 0; i < time; i++)
        {
            yield return new WaitForSeconds(0.1f);
            hitColor.r += deltaR;
            hitColor.g += deltaG;
            hitColor.b += deltaB;

            sprite.color = hitColor;
        }
        sprite.color = baseColor;

    }
    public void hitf(int arg)
    {
        StartCoroutine(hit(arg));
    }

    IEnumerator blink(int blinkTime)
    {
        int repeat = blinkTime * 2;
        Color colorA = sprite.color;
        Color colorB = sprite.color;
        colorA.a = 0.5f;
        for(int i = 0; i < repeat; i++)
        {
            sprite.color = colorA;
            yield return new WaitForSeconds(0.25f);
            sprite.color = colorB;
            yield return new WaitForSeconds(0.25f);
        }
    }// ÀÔ·Â°ª = ±ôºýÀÌ´Â ½Ã°£

    public void blinkf(int arg)
    {
        StartCoroutine(blink(arg));
    }
}
