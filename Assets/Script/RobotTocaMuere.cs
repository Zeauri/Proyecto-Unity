using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTocaMuere : MonoBehaviour
{

    Vector2 StartPos;

    private void Start()
    {
        StartPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo")) 
        {
            Die();
        }
    }

    void Die() 
    {
        Respawn();
    }

    void Respawn() 
    {
        transform.position = StartPos;
    }

}
