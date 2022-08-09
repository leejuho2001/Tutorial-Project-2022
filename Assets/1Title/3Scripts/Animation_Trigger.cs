using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Trigger : MonoBehaviour
{
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _animator.SetBool("IsOpen",true);
        }

        else if (Input.GetKeyUp(KeyCode.P))
        {
            _animator.SetBool("IsOpen",false);
        }
    }
}
