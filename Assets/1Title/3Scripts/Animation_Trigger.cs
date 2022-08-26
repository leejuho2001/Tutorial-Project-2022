using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation_Trigger : MonoBehaviour
{
    Animator _animator;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }
    
    void Update()
    {
     
    }

    bool _IsOpen = false;
    public void SwitchOpen()
    {
        if (_IsOpen == false)
        {
            _animator.SetBool("IsOpen", true);
            _IsOpen = true;
        }

        else if (_IsOpen == true)
        {
            _animator.SetBool("IsOpen", false);
            _IsOpen = false;
        }
    }
}
