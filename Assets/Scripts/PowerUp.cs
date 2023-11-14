using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp: MonoBehaviour
{
    public int AddHealth = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var PlayerScript = collision.gameObject.GetComponent<PhysicsController>();
        if (PlayerScript != null)
        {
            if (PlayerScript.HealthPoints < PlayerScript.HealthMaxPoints)
            {
            PlayerScript.HealthPoints += AddHealth;
            }
            AddHealth = 0;
            GameObject.Destroy(gameObject);
        }
    }
}
