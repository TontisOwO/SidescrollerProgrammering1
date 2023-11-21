using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCheck : MonoBehaviour
{
    public PhysicsController myCharacterController = null;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (myCharacterController.JumpingState != CharacterState.Grounded)
        {
            myCharacterController.JumpingState = CharacterState.Airborne;

        }
    }
}
