using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject character;
    playable.CharacterSpec spec;

    [SerializeField] private float xRange;
    
    float characterX;
    float cameraX;
    // Start is called before the first frame update
    private void Awake()
    {
        character = GameObject.Find("character");
        spec = character.GetComponent<playable.CharacterSpec>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        characterX = character.transform.position.x;
        cameraX = gameObject.transform.position.x;

        if (characterX > cameraX + xRange)
            gameObject.transform.position =
                new Vector3(
                    characterX - xRange,
                    gameObject.transform.position.y,
                    gameObject.transform.position.z
                );

        else if (characterX < cameraX - xRange)
            gameObject.transform.position =
                new Vector3(
                    characterX + xRange,
                    gameObject.transform.position.y,
                    gameObject.transform.position.z
            );
        /*
        else
            gameObject.transform.position =
                new Vector3(
                    cameraX + spec.givVelocity() / 480,
                    gameObject.transform.position.y,
                    gameObject.transform.position.z
                );
        */
    }
}
