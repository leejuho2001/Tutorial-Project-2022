using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSwitchObj_Propertiess : MonoBehaviour
{
    [SerializeField] private bool isOn;

    // Start is called before the first frame update
    SpriteRenderer sprite;

    Color off = new Color(0, 0, 0);
    Color on = new Color(100/255f, 194/255f, 255/255f);
    public void Awake()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
        if (isOn == true) activate();
        else deActivate();
    }
    public bool givIsOn()
    {
        return isOn;
    }

    // Update is called once per frame
    public void activate()
    {
        isOn = true;
        sprite.color = on;
    }

    public void deActivate()
    {
        isOn = false;
        sprite.color = off;
    }
}
