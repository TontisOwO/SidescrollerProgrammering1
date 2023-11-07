using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody = null;
    public float MovementSpeedPerSecond = 10.0f;
    
    void FixedUpdate()
    {
        Vector3 characterVelocity = myRigidBody.velocity;
        characterVelocity.x = 0.0f;

        characterVelocity += MovementSpeedPerSecond * transform.right.normalized;
        
        myRigidBody.velocity = characterVelocity;
    }
}
