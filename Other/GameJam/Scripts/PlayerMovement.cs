using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator playerController;

    public float speed;
    public float jump;


    public Rigidbody2D rigidjump;
    public Vector3 pos;


    public bool isJumping;
    public bool isLeft;
    public bool isMoving;

    
    // Start is called before the first frame update
    void Start()
    {
        isLeft = false;
        isJumping = false;
        isMoving = false;
        jump = 5;
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    void Moving()
    {
        Vector3 pos = transform.position;
        isMoving = false;
        if (Input.GetKey("a"))
        {
            if (isLeft == false)
            {
                transform.Rotate(0f, 180f, 0f);
            }
            isLeft = true;
            pos.x -= speed * Time.deltaTime;
            isMoving = true;
        }
        if (Input.GetKey("d"))
        {
            if (isLeft == true)
            {
                transform.Rotate(0f, 180f, 0f);
            }
            isLeft = false;
            pos.x += speed * Time.deltaTime;
            isMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rigidjump.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            isJumping = true;
            playerController.SetBool("Jump", true);
        }
        playerController.SetBool("isRunning", isMoving & !isJumping);
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            playerController.SetBool("Jump", false);
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }
}
