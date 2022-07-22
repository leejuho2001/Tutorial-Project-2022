using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playable {
    public class CharacterController : MonoBehaviour
    {
        // Start is called before the first frame update
        private BoxCollider2D collider;
        private Rigidbody2D rigid;
        private SpriteRenderer spRenderer;
        private Character body;

        private float terminalSpeed;
        private float acceleration;
        private float force;

        void Start()
        {
            body = GetComponent<Character>();
            collider = GetComponent<BoxCollider2D>();
            rigid = GetComponent<Rigidbody2D>();
            spRenderer = GetComponent<SpriteRenderer>();
            acceleration = 3;
            force = rigid.mass * acceleration;
            WaterMode();
        }

        protected void WaterMode()
        {
            rigid.drag = 3;
            terminalSpeed = 5;
        }

        protected void NormalMode()
        {
            rigid.drag = 1;
            terminalSpeed = 10;
        }// 수중이 아닌, 일반으로 취급될경우( 사용할지는 모름 )
        // Update is called once per frame
        void Update()
        {

            if (Input.GetKey(KeyCode.RightArrow))
            {
                rigid.AddForce(new Vector3(force, 0, 0));
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rigid.AddForce(new Vector3(-force, 0, 0));
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(body.jump.canUse)
                    body.jump.Activate();
                // 쿨타임이 다 돌아야 사용가능
            }
        }
    }
}