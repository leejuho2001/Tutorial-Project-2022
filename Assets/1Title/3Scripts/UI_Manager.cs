using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    Slider _OxygenBar;

    public void SetOxygen(float _arg)
    {
        _OxygenBar.value = _arg;
    }
    // 캐릭터와 ui manager 연결 해야 작동함
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
