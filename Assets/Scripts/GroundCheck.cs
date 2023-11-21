using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PhysicsController myCharacterController = null;
    private void OnCollisionEnter2D(Collision2D collision)  
    {
        myCharacterController.JumpingState = CharacterState.Grounded;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (myCharacterController.JumpingState != CharacterState.Jumping)
        {
            myCharacterController.JumpingState = CharacterState.Airborne;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        myCharacterController.JumpingState = CharacterState.Grounded;
    }
}
