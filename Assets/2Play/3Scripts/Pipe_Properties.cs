using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Properties : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool isOn;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public bool givIsOn()
    {
        return isOn;
    }

    public void activate()
    {
        isOn = true;
    }

    public void deActivate()
    {
        isOn = false;
    }
}
