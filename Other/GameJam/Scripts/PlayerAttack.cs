using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowANDarrow : MonoBehaviour
{
    public Animator playerController;

    public Transform firePoint;

    public Movement movement;

    public GameObject bulletPrefab;

    public bool isUp;
    public bool isShooting;

    private float coolDownTime = 0f;

    public SpriteRenderer spriteRenderer;
    public SpriteRenderer tempsprite;
    public Color originalcolor;

    // Update is called once per frame

    void Start()
    {
        originalcolor = tempsprite.color;
        isUp = false;
        isShooting = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time - coolDownTime > 1f)
        {
            if(!movement.isJumping && !movement.isMoving)
            {
                isShooting = true;
                playerController.SetTrigger("Attack");
            }
        }

        if (isShooting && Input.GetKeyUp(KeyCode.F))
        {
            isShooting = false;
            coolDownTime = Time.time;
            Shoot();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isUp = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            isUp = true;
        }
        playerController.SetBool("LookingUp", isUp);
    }

    void Shoot()
    {
        if (isUp)
        {
            if (movement.isLeft == true)
            {
                Quaternion rotation = Quaternion.Euler(0f, 0f, 45f);
                GameObject anglebullet = Instantiate(bulletPrefab, firePoint.position, rotation);
                playerController.SetTrigger("AttackRelease");
                Destroy(anglebullet, 5f);
            }
            if (movement.isLeft == false)
            {
                Quaternion rotation = Quaternion.Euler(0f, 0f, 135f);
                GameObject anglebullet2 = Instantiate(bulletPrefab, firePoint.position, rotation);
                playerController.SetTrigger("AttackRelease");
                Destroy(anglebullet2, 5f);
            }
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            playerController.SetTrigger("AttackRelease");
            Destroy(bullet, 5f); // Destroy the bullet after 5 seconds
        }
    }
}