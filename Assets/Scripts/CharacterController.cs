using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum CharacterState
{
    Grounded,
    Airborne,
    Jumping,
    Total
}
public class CharacterController : MonoBehaviour
{
    public CharacterState JumpingState = CharacterState.Airborne;

    public float JumpSpeedFactor = 2.0f;
    public float JumpMaxHeight = 64.0f;
    public float JumpHeightDelta = 0.0f;

    public float MovementSpeedPerSecond = 100.0f;
    public float GravityPerSecond = 160.0f;
    public float GroundLevel = -16.0f;
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (transform.position.y <= GroundLevel)
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y = GroundLevel;
            transform.position = characterPosition;
            JumpingState = CharacterState.Grounded;
        }

        if (Input.GetKey(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping;
            JumpHeightDelta = 0.0f;

        }
        if (JumpingState == CharacterState.Jumping)
        {
            Vector3 characterPosition = transform.position;
            float totalJumpMovementThisFrame = MovementSpeedPerSecond * JumpSpeedFactor * Time.deltaTime;
            characterPosition.y += totalJumpMovementThisFrame;
            transform.position = characterPosition;
            JumpHeightDelta += totalJumpMovementThisFrame;
            if (JumpHeightDelta >= JumpMaxHeight || !Input.GetKey(KeyCode.W))
            {
                JumpingState = CharacterState.Airborne;
            }
        }

        //if (Input.GetKey(KeyCode.S))
        //{
        //    Vector3 characterPosition = gameObject.transform.position;
        //    characterPosition.y -= MovementSpeedPerSecond * Time.deltaTime;
        //    gameObject.transform.position = characterPosition;
        //}

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

        if (JumpingState == CharacterState.Airborne)
        {
            Vector3 gravityPosition = gameObject.transform.position;
            gravityPosition.y -= GravityPerSecond * Time.deltaTime;
            if (gravityPosition.y < GroundLevel)
            {
                gravityPosition.y = GroundLevel;
            }
            gameObject.transform.position = gravityPosition;
        }

    }

}
