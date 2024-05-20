using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTorreta : MonoBehaviour
{
    

    public GameObject Robot;

    public GameObject BulletPrefab;

    private int Health = 3;

    public void Hit() //Sistema de vidas por golpes
    {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);
    }



    private float LastShoot;

    private void Update()
    {
        Vector3 direction = Robot.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(8.0f, 10.0f, 1.0f);
        else transform.localScale = new Vector3(-8.0f, 10.0f, 1.0f);

        float distance = Mathf.Abs(Robot.transform.position.x - transform.position.x);

        if (distance < 10.0f && Time.time > LastShoot + 1.0f) //El objeto disparara en cuanto el personaje esté en distancia de 10 o menos y con un retardo de LastShoot de 1.0f de tiempo
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Debug.Log("Shoot");

        Vector3 direction;
        if (transform.localScale.x == 8.0f) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 1.5f, Quaternion.identity); //El objeto disparara las balas no desde su interior, sino a 1,2f de distancia. Esto se usa para que las balas no colisionen con el propio objeto
        bullet.GetComponent<ScriptBala>().SetDirection(direction);
    }

   
}