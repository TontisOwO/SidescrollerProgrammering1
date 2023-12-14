using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public PlayerData CurrentPlayerPoints = null;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var PlayerScript = collision.gameObject.GetComponent<PhysicsController>();
        if (PlayerScript != null)
        {
            CurrentPlayerPoints.PlayerPoints += 100;
            GameObject.Destroy(gameObject);
        }
    }
}
