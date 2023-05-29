using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public float speed;
    private float distance;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public float cooldown;
    public bool isDead = false;
    private SpriteRenderer _renderer;
    //private BoxCollider2D collider;

    private Rigidbody2D rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //StartCoroutine(ShootPlayer());
        // player = FindObjectOfType<PlayerMovement>().gameObject;
        //player = PlayerStats.playerStats.playerModel;
        _renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        if (!isDead)
        {
            //distance = Vector2.Distance(transform.position, player.transform.position);
            //Vector2 direction = player.transform.position - transform.position;
            //direction.Normalize();
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            player = PlayerStats.playerStats.playerModel;
            transform.position = Vector2.MoveTowards(this.transform.position, 
            player.transform.position, speed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle)
        } 
        else
        {
            GetComponent<BoxCollider2D> ().enabled = false;
        }
        
        if (this.transform.position.x < player.transform.position.x)
        {
            _renderer.flipX = false;
        }
        else if (this.transform.position.x > player.transform.position.x)
        {
            _renderer.flipX = true;
        }  
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy")
        {
            if(collision.tag == "Player")
            {
                PlayerMovement.animator.SetTrigger("Hit");
                PlayerStats.playerStats.DealDamage(Random.Range(minDamage, maxDamage));
                //StartCoroutine(Knockback());
                Vector2 difference = transform.position - collision.transform.position;
                transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
            }
        }
    }

    /*public IEnumerator Knockback()
    {
        float knockbackDuration = 0.01f;
        //float knockbackPower = 0.0005f;
        //float knockbackPower = 0.4f;
        Transform obj = PlayerStats.playerStats.player.transform;
        Vector2 difference = transform.position - obj.transform.position;
        float timer = 0;

        while (knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
        yield return 0;
    }*/

    /*IEnumerator ShootPlayer() {
            yield return new WaitForSeconds(cooldown);
            if (player!=null) {
                GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
                Debug.Log(player.transform.position);
                Vector2 myPos = transform.position;
                Vector2 targetPos = player.transform.position;
                Vector2 direction = (targetPos - myPos).normalized;
                spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
                spell.GetComponent<TestEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);
                StartCoroutine(ShootPlayer());
            }
    }*/
}
