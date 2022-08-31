using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playable
{
    public class CharacterSpec : MonoBehaviour
    {
        Rigidbody2D rigid;
        BoxCollider2D collid;
        playable.CharacterAct acter;

        //산소 UI슬라이더와 연결
        [SerializeField] UI_Manager _uimanager;
        //산소 UI슬라이더와 연결

        [SerializeField] int oxygen;
        [SerializeField] int oxyuse;
        [SerializeField] int maxVelocity;
        [SerializeField] float accel;
        [SerializeField] float jumpAccel;
        [SerializeField] float jumpCool;
        [SerializeField] float shootDelay;
        [SerializeField] bool zetpackAble;


        bool invincibleTime;
        bool canShoot;
        bool canJump;
        bool zetpackActivated;
        int direction;
        float HP;
        float epsilon;
        // Start is called before the first frame update
        private void Awake()
        {
            collid = gameObject.GetComponent<BoxCollider2D>();
            rigid = gameObject.GetComponent<Rigidbody2D>();
            acter = gameObject.GetComponent<playable.CharacterAct>();
            invincibleTime = false;
            canJump = true;
            canShoot = true;
            direction = 0;
            epsilon = 0.001f;
            zetpackActivated = false;
            HP = (float)oxygen;
        }

        void Start()
        {
            Vector3 objectScale = transform.localScale;
            reSize(objectScale);
            StartCoroutine("usingOxy");

            //산소 UI슬라이더와 연결
            _uimanager.SetOxygen(givHP());
            //산소 UI슬라이더와 연결
        }
        private void reSize(Vector3 vector)
        {
            Transform trans = transform.parent;
            transform.parent = null;
            transform.localScale = new Vector3(1f, 1f, 1f);
            transform.parent = trans;

            Transform sprite = transform.GetChild(0).transform;
            collid.size = new Vector2(vector.x, vector.y);
            sprite.localScale = vector;
        }
        public float givVelocity()
        {
            return rigid.velocity.x;
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

        public bool givInvTime()
        {
            return invincibleTime;
        }

        IEnumerator Invincible(int time)
        {
            invincibleTime = true;
            yield return new WaitForSeconds((float)time);
            invincibleTime = false;
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
        public void p_Heal(int percent)
        {
            float onePercent = oxygen * 0.01f;
            float result = onePercent * percent + HP;
            if (result > oxygen) HP = oxygen;
            else HP = result;
        }

        public void p_OxyUse(int percent)
        {
            float onePercent = oxygen * 0.01f;
            HP -= onePercent * percent;
        }
        public void p_damage(int percent)
        {
            p_OxyUse(percent);
            
            gameObject.GetComponent<SpriteManager>().blinkf(3);
            StartCoroutine(Invincible(3));
        }
        // 체력비례 피해

        public void damage(int dmg)
        {
            HP -= dmg;
            gameObject.GetComponent<SpriteManager>().blinkf(3);
            StartCoroutine(Invincible(3));
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
                    p_OxyUse(1);
                    acter.shoot();
                    shootCooltime(shootDelay);
                }
            }
            //산소 UI슬라이더와 연결
            _uimanager.SetOxygen(givHP() / oxygen);
            //산소 UI슬라이더와 연결

        }
    }
}
