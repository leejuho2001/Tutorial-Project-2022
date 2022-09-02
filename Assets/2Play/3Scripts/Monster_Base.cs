using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Base : MonoBehaviour
{
    [SerializeField] int HP;
    [SerializeField] int p_atk; //퍼센트 데미지 공격력
    [SerializeField] float invTime;

    int healthPoint;
    bool invincibleTime;

    Rigidbody2D rigid;
    SpriteManager spriteManager;

    private void Awake()
    {
        spriteManager = gameObject.GetComponent<SpriteManager>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        healthPoint = HP;
        invincibleTime = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteManager.spriteReSize();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void set_Invincible()
    {
        invincibleTime = true;
    } //영구 무적임을 설정

    public int givHP()
    {
        return healthPoint;
    }

    IEnumerator Invincible(float time)
    {
        invincibleTime = true;
        yield return new WaitForSeconds((float)time);
        invincibleTime = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playable.CharacterSpec spec = collision.GetComponent<playable.CharacterSpec>();
            if (spec.givInvTime())
                return;
            else
                spec.p_damage(p_atk);
        }

        else if (collision.tag == "Bullet")
        {
            if (invincibleTime) return;
            else
            {
                int times = (int)(invTime * 10);
                collision.GetComponent<Bullet_Properties>().deActivate();
                healthPoint--;
                spriteManager.hitf(times);
                StartCoroutine(Invincible(invTime));
            }
        }
    }
}
