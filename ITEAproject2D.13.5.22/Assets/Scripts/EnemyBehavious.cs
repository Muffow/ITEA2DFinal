using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavious : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D enemyRb;
    public int maxHealth = 100;
    int currentHealth;

    public bool mustPatrol;
    private bool mustTurn;
    public float patrolSpeed = 3.0f;

    public Slider healthBarSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody2D>();
        mustPatrol = true;

        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = currentHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

    public void Patrol()
    {
        enemyRb.velocity = new Vector2(patrolSpeed, enemyRb.velocity.y);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Turn"))
        {
            Flip();
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mustPatrol = false;
            animator.SetTrigger("Attack");
            HurtPlayer();
            mustPatrol = true;
        }
        else
        {
            mustPatrol = true;
        }
    }
    public void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        patrolSpeed *= -1;
        mustPatrol = true;
    }


    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    IEnumerator AttackAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetTrigger("Attack");
        HurtPlayer();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBarSlider.value=currentHealth;

        if (currentHealth <= 0)
        {
            animator.SetTrigger("Death");
            StartCoroutine(ExecuteAfterTime(0.3f));
        }
    }

    public void HurtPlayer()
    {
        gameObject.GetComponent<HeroKnight>().UpdateLives(-1);
        StartCoroutine(AttackAfterDelay(0.3f));
    }

    //set difficulty, resolution
}