using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterController : MonoBehaviour
{

    public float MovementSpeedPerSecond = 25.0f;
    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 characterPosition = gameObject.transform.position; 
            characterPosition.y += MovementSpeedPerSecond * Time.deltaTime;
            gameObject.transform.position = characterPosition;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 characterPosition = gameObject.transform.position;
            characterPosition.y -= MovementSpeedPerSecond * Time.deltaTime;
            gameObject.transform.position = characterPosition;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 characterPosition = gameObject.transform.position;
            characterPosition.x -= MovementSpeedPerSecond * Time.deltaTime;
            gameObject.transform.position = characterPosition;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 characterPosition = gameObject.transform.position;
            characterPosition.x += MovementSpeedPerSecond * Time.deltaTime;
            gameObject.transform.position = characterPosition;
        }
    }
}
