using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playable
{
    public class CharacterSpec : MonoBehaviour
    {
        Rigidbody2D rigid;
        playable.CharacterAct acter;

        [SerializeField] int oxygen;
        [SerializeField] int oxyuse;
        [SerializeField] int maxVelocity;
        [SerializeField] float accel;
        [SerializeField] float jumpAccel;
        [SerializeField] float jumpCool;
        [SerializeField] float shootDelay;

        bool canShoot;
        bool canJump;
        int direction;
        float HP;
        float epsilon;
        // Start is called before the first frame update
        private void Awake()
        {
            rigid = gameObject.GetComponent<Rigidbody2D>();
            acter = gameObject.GetComponent<playable.CharacterAct>();
            canJump = true;
            canShoot = true;
            direction = 0;
            epsilon = 0.001f;
            HP = (float)oxygen;
        }

        void Start()
        {
            reSize(85f, 130f, 0.5f);
            StartCoroutine("usingOxy");
        }

        private void reSize(float x, float y, float z)
        {
            Transform trans = transform.parent;
            transform.parent = null;
            transform.localScale = new Vector3(x, y, z);
            transform.parent = trans;
        }

        public float givHP()
        {
            return HP;
        }

        public float givMaxVelocity()
        {
            return (float)maxVelocity;
        }

        public float givAccel()
        {
            return accel;
        }

        public float givJumpAccel()
        {
            return jumpAccel;
        }
        public int givDir()
        {
            return direction;
        }


        IEnumerator jumpCooltime(float cool)
        {
            canJump = false;
            yield return new WaitForSeconds(cool);
            canJump = true;
        }

        IEnumerator shootCooltime(float cool)
        {
            canShoot = false;
            yield return new WaitForSeconds(cool);
            canShoot = true;
        }

        public void p_damage(int percent)
        {
            float onePercent = HP * 0.01f;
            HP -= onePercent * percent;
        }
        // 체력비례 피해

        public void damage(int dmg)
        {
            HP -= dmg;
        }
        //일반 피해

        IEnumerator usingOxy()
        {
            while (HP > 0)
            {
                HP -= oxyuse;
                yield return new WaitForSeconds(0.1f);
            }
        }

        private void Update()
        {
            if (direction != 1 && rigid.velocity.x >= 0) direction = 1;
            else if (direction != -1 && rigid.velocity.x < 0) direction = -1;

            if (HP < 0)
            {
                Debug.Log("Game Over");
                Application.Quit();
            }

            if (Input.GetKey(KeyCode.LeftArrow)) acter.left_acceleration();

            if (Input.GetKey(KeyCode.RightArrow)) acter.right_acceleration();

            if (Input.GetKeyDown("x"))
            {
                if (canJump == true)
                {
                    acter.jump();
                    jumpCooltime(jumpCool);
                }
            }

            if (Input.GetKeyDown("a"))
            {
                if (canShoot == true)
                {
                    p_damage(1);
                    acter.shoot();
                    shootCooltime(shootDelay);
                }
            }
        }
    }
}
