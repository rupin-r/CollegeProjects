using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour
{

    public float speed;
    public float distance = 4f;
    private float timeDistance;
    private float direction;
    private Rigidbody2D rb;

    private float timeAttack = 0.5f;
    private float attack;
    private bool attacking;

    public GameObject poo;

    public Animator enemyController;
    // Start is called before the first frame update
    void Start()
    {
        timeDistance = Time.time;
        direction = 1f;
        speed = 1.5f;
        attacking = false;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            enemyController.SetBool("Attack", true);
            rb.velocity = new Vector2(0, 0);
            if(Time.time - attack > timeAttack)
            {
                enemyController.SetBool("Attack", false);
                attacking = false;
                GameObject bullet = Instantiate(poo, transform.position, transform.rotation);
                Rigidbody2D rb1111 = bullet.GetComponent<Rigidbody2D>();
                rb1111.AddForce(transform.up * 10f, ForceMode2D.Impulse);
                Destroy(bullet, 3f); // Destroy the bullet after 5 seconds

                //
            }
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up * -1, 5f, 2);
            if (hit.collider != null)
            {
                rb.velocity = new Vector2(0, 0);
                if (!attacking)
                {
                    attacking = true;
                    attack = Time.time;
                }
            }
            else
            {
                rb.velocity = new Vector2(speed * direction, 0);
                if (Time.time - timeDistance > distance)
                {
                    direction *= -1;
                    timeDistance = Time.time;
                    transform.Rotate(0f, 180f, 0f);
                }
            }
        }
        Debug.DrawRay(transform.position, transform.up * -5, Color.red);
    }
}
