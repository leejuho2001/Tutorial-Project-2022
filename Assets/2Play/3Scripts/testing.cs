using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace non_playable
{
    public class testing : MonoBehaviour
    {
        GameObject character;
        GameObject bullet;
        Rigidbody2D rigid;
        playable.CharacterSpec spec;
        // Start is called before the first frame update
        private void Awake()
        {
            bullet = GameObject.Find("Bullet");
            spec = gameObject.GetComponent<playable.CharacterSpec>();
            rigid = gameObject.GetComponent<Rigidbody2D>();
        }

        void Start()
        {

            StartCoroutine("CheckOxy");
        }
        IEnumerator CheckOxy()
        {
            while (spec.givHP() > 500)
            {
                Debug.Log(spec.givHP());
                yield return new WaitForSeconds(2.0f);
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("z"))
            {
                //       bullet.GetComponent<Bullet_Properties>().Activate(spec.givDir(), 0, 0);
            }
        }
    }
}