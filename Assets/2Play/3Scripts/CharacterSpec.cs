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

        //��� UI�����̴��� ����
        [SerializeField] UI_Manager _uimanager;
        [SerializeField] SceneChanger _scenechanger;
        //��� UI�����̴��� ����

        [SerializeField] int oxygen;
        [SerializeField] int oxyuse;
        [SerializeField] int maxVelocity;
        [SerializeField] float accel;
        [SerializeField] float jumpAccel;
        [SerializeField] float jumpCool;
        [SerializeField] float shootDelay;
        [SerializeField] bool zetpackAble;

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

            //��� UI�����̴��� ����
            _uimanager.SetOxygen(givHP());
            //��� UI�����̴��� ����
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
        // ü�º�� ����

        public void damage(int dmg)
        {
            HP -= dmg;
        }
        //�Ϲ� ����

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
            //��� UI�����̴��� ����
            _uimanager.SetOxygen(givHP() / oxygen);
            //��� UI�����̴��� ����
            
        }
        //���� ����
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Goal")
            {
                _scenechanger.ChangeSceneByName_B();
            }
        }
        //���� ����
    }
}
