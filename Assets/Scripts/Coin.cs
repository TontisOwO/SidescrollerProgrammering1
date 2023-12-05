using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var PlayerScript = collision.gameObject.GetComponent<PhysicsController>();
        if (PlayerScript != null)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
