using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            if (collision.GetComponent<EnemyReceiveDamage>() != null) 
            {
                collision.GetComponent<EnemyReceiveDamage>().DealDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
