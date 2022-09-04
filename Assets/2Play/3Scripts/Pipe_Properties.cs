using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Properties : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool isOn;
    [SerializeField] bool wallMode;

    GameObject body;
    GameObject area;


    private void Awake()
    {
        body = gameObject.transform.GetChild(0).gameObject;
        area = gameObject.transform.GetChild(1).gameObject;
    }

    void Start()
    {
        if (isOn == true) activate();
        else deActivate();

        BoxCollider2D collid = area.GetComponent<BoxCollider2D>();
        if (wallMode == true) collid.isTrigger = false;
        else collid.isTrigger = true;
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
        Debug.Log("Pipe activated");
        isOn = true;
        area.SetActive(true);

    }

    public void deActivate()
    {
        Debug.Log("Pipe deactivated");
        isOn = false;
        area.SetActive(false);
    }
}
