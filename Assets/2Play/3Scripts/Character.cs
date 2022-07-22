using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ĳ���Ͱ� ������ �ִ� Ư¡�� ���� �κ��� ��� ��ũ��Ʈ
namespace playable
{
    public class Character : MonoBehaviour
    {
        [SerializeField] float Oxizen;
        [SerializeField] float breath;
        [SerializeField] float jumpCool;
        [SerializeField] float jumpPower;
        
        public Jump jump;
        public Rigidbody2D rigid;

        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
            jump = gameObject.AddComponent<Jump>();
            
            
            breath = 1;
            Oxizen = 5000;
        }

        // Update is called once per frame
        void Update()
        {
            StartCoroutine(lifeDecrease());
        }

        IEnumerator lifeDecrease()
        {
            Oxizen -= 1;
            yield return new WaitForSecondsRealtime(breath);
        }
    }

    public class Jump : common.SkillBase
    {
        private float jumpForce;
        private Rigidbody2D rigid;

        public Jump(float cool, Rigidbody2D irigid, float power) : base(cool)
        {
            jumpForce = power;
            rigid = irigid;
        }

        override public void Activate()
        {
            rigid.AddForce(new Vector3(0, jumpForce, 0));
            StartCoroutine(CoolTime());
        }
    }
}
