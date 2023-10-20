using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhysicsController : MonoBehaviour
{
    public Rigidbody2D myRigidbody = null;

    [Header("Jump")]

    public CharacterState JumpingState = CharacterState.Airborne;

    public float JumpSpeedFactor = 2.0f;
    public float JumpMaxHeight = 64.0f;
    public float JumpHeightDelta = 0.0f;

    [Header("Movement")]

    public float MovementSpeedPerSecond = 100.0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping;
            JumpHeightDelta = 0.0f;
        }
    }

    void FixedUpdate()
    {
        Vector3 characterVelocity = myRigidbody.velocity;
        characterVelocity.x = 0.0f;
        characterVelocity.y = 0.0f;


        
        if (JumpingState == CharacterState.Jumping)
        {
            float totalJumpMovementThisFrame = MovementSpeedPerSecond * JumpSpeedFactor;
            characterVelocity.y += totalJumpMovementThisFrame;
            JumpHeightDelta += totalJumpMovementThisFrame*Time.deltaTime;

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
            characterVelocity.x -= MovementSpeedPerSecond;
        }

        if (Input.GetKey(KeyCode.D))
        {
            characterVelocity.x += MovementSpeedPerSecond;
        }
        myRigidbody.velocity = characterVelocity;
    }   

}
