using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamagingScript : MonoBehaviour
{
    public bool IsPlayer = false;
    public int damageValue = -1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsPlayer)
        {
            var enemyScript = collision.gameObject.GetComponent<EnemyScript>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(damageValue);
            }
        }
        else
        {
            var PlayerScript = collision.gameObject.GetComponent<PhysicsController>();
            if (PlayerScript != null)
            {
                PlayerScript.TakeDamage(damageValue);
            }
        }
        
    }
}
