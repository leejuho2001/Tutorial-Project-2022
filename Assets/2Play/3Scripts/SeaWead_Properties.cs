using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWead_Properties : MonoBehaviour
{


    // Start is called before the first frame update
    public GameObject prefab;

    GameObject bubble1;
    GameObject bubble2;
    GameObject bubble3;

    private void Awake()
    {
        bubble1 = Instantiate(prefab);
        bubble2 = Instantiate(prefab);
        bubble3 = Instantiate(prefab);
    }

    private void Start()
    {
        bubbleSetting();
    }

    void bubbleSetting()
    {
        bubble1.GetComponent<Bubble_Properties>().Activate(gameObject, 0.2f, 0.45f);
        bubble2.GetComponent<Bubble_Properties>().Activate(gameObject, 0.5f, 0.8f);
        bubble3.GetComponent<Bubble_Properties>().Activate(gameObject, 0.85f, 0.65f);
    }
}
