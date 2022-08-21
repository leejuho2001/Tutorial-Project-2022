using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playable
{
    public class CharacterAct : MonoBehaviour
    {
        BoxCollider2D b_collider;
        Rigidbody2D rigid;
        playable.CharacterSpec spec;
        BulletManager gun;
        Vector3 moveVec;

        private float max_velocity;
        private float accel;
        // Start is called before the first frame update
        private void Awake()
        {
            gun = GameObject.Find("Gun").GetComponent<BulletManager>();
            b_collider = gameObject.GetComponent<BoxCollider2D>();
            rigid = gameObject.GetComponent<Rigidbody2D>();
            spec = gameObject.GetComponent<CharacterSpec>();
        }

        void Start()
        {
            max_velocity = spec.givMaxVelocity();
            accel = spec.givAccel();
        }

        public void horizontal_acceleration()
        {
            float x = Input.GetAxisRaw("Horizontal");
            Vector3 saved_velocity = rigid.velocity;
            Vector3 component = new Vector3(x, 0, 0);

            rigid.AddForce(component * accel * rigid.mass, ForceMode2D.Impulse);
            if (Mathf.Abs(rigid.velocity.x) > max_velocity)
                rigid.velocity = new Vector3(x * max_velocity, saved_velocity.y, saved_velocity.z);
        }

        public void left_acceleration()
        {
            horizontal_acceleration();
        }

        public void right_acceleration()
        {
            horizontal_acceleration();
        }

        public void jump()
        {
            Debug.Log("Jump");
            Vector3 velocity = rigid.velocity;
            velocity.y = 0;
            rigid.velocity = velocity;// 순간 세로 속도 0

            Vector3 component = new Vector3(0, 1, 0);
            rigid.AddForce(component * spec.givJumpAccel() * rigid.mass, ForceMode2D.Impulse);
        }

        public void shoot()
        {
            Debug.Log("shoot");
            gun.shoot();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
