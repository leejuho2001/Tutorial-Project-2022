using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public bool isActive;


    // Update is called once per frame
    void Awake()
    {
        destorySelf();
    }

    void destorySelf()
    {
        if (isActive)
        {
            Destroy(gameObject, 5);
        }
        else
        {
            return;
        }
    }
}
