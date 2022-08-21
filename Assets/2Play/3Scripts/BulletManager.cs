using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] int cylinderSize;
    [SerializeField] int x;
    [SerializeField] int y;
    GameObject character;
    public GameObject pref;
    public Queue<GameObject> cylinder;
    private void Awake()
    {
        cylinder = new Queue<GameObject>();
        character = GameObject.Find("character");
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cylinderSize; i++)
        {
            cylinder.Enqueue(Instantiate(pref));
        }
    }

    public void shoot()
    {
        int direction = character.GetComponent<playable.CharacterSpec>().givDir();
        GameObject bullet = cylinder.Dequeue();
        bullet.GetComponent<Bullet_Properties>().Activate(direction, x, y);
    }
}
