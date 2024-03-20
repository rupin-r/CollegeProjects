using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public GameObject player;
    private int life;
    private bool dead;

    private void Start()
    {
        life = hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
       if (dead == true)
       {
        //CHANGE TO DEAD ANIMATION?
        player.SetActive(false);
        
       }
    }

    
    public void TakeDamage(int d)
    {
        if (life >= 1)
        {
            life -= d;
            hearts[life].SetActive(false);
            if (life < 1)
            {
                dead = true;
            }
        }
    }


}
