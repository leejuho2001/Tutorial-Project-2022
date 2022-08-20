using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Animation : MonoBehaviour
{
    Animator _animator;
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();

        bool _IsOpen = false;
        
        if (_IsOpen == false)
        {
            _animator.SetBool("IsOpen", true);
            _IsOpen = true;
        }
    }
}
