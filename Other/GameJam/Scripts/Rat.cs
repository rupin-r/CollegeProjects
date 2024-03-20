using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{

    // Start is called before the first frame update
    public float speed;
    private int direction;
    private Rigidbody2D rb;

    public Animator enemyController;
    void Start()
    {
        speed = 1;
        direction = 1;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * direction, 0);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 0.6f, 1);
        RaycastHit2D hitFloor = Physics2D.Raycast(transform.position + new Vector3(0.4f * direction, 0, 0), transform.up * -1, 0.5f, 1);
        RaycastHit2D hitPlayer1 = Physics2D.Raycast(transform.position, transform.right, 4f, 2);
        RaycastHit2D hitPlayer2 = Physics2D.Raycast(transform.position + new Vector3(0, 0.4f, 0), transform.right, 4f, 2);
        if (hit.collider != null)
        {
            direction *= -1;
            transform.Rotate(0f, 180f, 0f);
        }
        if(hitFloor.collider == null)
        {
            direction *= -1;
            transform.Rotate(0f, 180f, 0f);
        }
        if(hitPlayer1.collider != null || hitPlayer2.collider != null)
        {
            enemyController.SetTrigger("getLaunched");
            //launch at player here
            //can determine from which collider was a hit where to launch
            //Or you can search for the player and launch at it that way

            //
        }
        Debug.DrawRay(transform.position, transform.right, Color.green);
        Debug.DrawRay(transform.position + new Vector3(0.4f * direction, 0, 0), transform.up * -1, Color.green);
        Debug.DrawRay(transform.position, transform.right * 5f, Color.red);
        Debug.DrawRay(transform.position + new Vector3(0,0.4f,0), transform.right * 5f, Color.red);
    }
}
