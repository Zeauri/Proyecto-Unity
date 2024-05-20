using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBala : MonoBehaviour
{

    private Rigidbody2D Rigidbody2D;
    public float Speed; //Velocidad de la bala
    private Vector2 Direction; //Para añadir dirección de la bala
    public void SetDirection(Vector2 direction) //Función de direccionado de la bala
    {
        Direction = direction;
    }

    public void DestroyBullet() //Función para destruir bala para que no sea infinita
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.velocity = Direction * Speed; //Direccionado por velocidad de la bala
        
    }



    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovimientoPersonaje Robot = collision.GetComponent<MovimientoPersonaje>();
        ScriptDrone Drone = collision.GetComponent<ScriptDrone>();
        ScriptTorreta torreta = collision.GetComponent<ScriptTorreta>();
        if (Robot != null)
        {
            Robot.Hit();
        }

        if (Drone != null)
        {
            Drone.Hit();
        }

        if (torreta != null) 
        {
            torreta.Hit();
        }

        DestroyBullet();

    }

}
