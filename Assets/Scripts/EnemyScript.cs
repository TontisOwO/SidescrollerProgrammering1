using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int HealthPoints = 1;
    public Rigidbody2D myRigidBody = null;
    public float MovementSpeedPerSecond = 10.0f;
    public float MovementSign = 1.0f;

    void FixedUpdate()
    {
        Vector3 characterVelocity = myRigidBody.velocity;
        characterVelocity.x = 0.0f;

        characterVelocity += MovementSign * MovementSpeedPerSecond * transform.right.normalized;
        
        myRigidBody.velocity = characterVelocity;
        if (HealthPoints <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
    public void TakeDamage(int aHealthValue)
    {
        HealthPoints += aHealthValue;
    }
}
