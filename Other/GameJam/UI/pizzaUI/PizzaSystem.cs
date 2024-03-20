using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaSystem : MonoBehaviour
{
    public GameObject[] pizza;

    void Start()
    {

    }


    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Dough")
        {
            Debug.Log("dough collided");
            pizza[0].SetActive(true);
        }else if (collision.gameObject.tag == "Sauce")
        {
            Debug.Log("sauce collided");
            pizza[1].SetActive(true);
        }else if (collision.gameObject.tag == "Cheese")
        {
            Debug.Log("cheese collider");
            pizza[2].SetActive(true);
        }else if (collision.gameObject.tag == "Pepperoni")
        {
            Debug.Log("pepperoni collider");
            pizza[3].SetActive(true);
        }
    }
}

