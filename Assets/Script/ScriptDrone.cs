using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDrone : MonoBehaviour
{
    

    public GameObject Robot;

    public GameObject BulletPrefab;

    private float LastShoot;

    private void Update()
    {
        Vector3 direction = Robot.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(-6.0f, 8.0f, 1.0f);
        else transform.localScale = new Vector3(6.0f, 8.0f, 1.0f);

        float distance = Mathf.Abs(Robot.transform.position.x - transform.position.x);

        if (distance < 10.0f && Time.time > LastShoot + 0.25f) //El objeto disparara en cuanto el personaje esté en distancia de 10 o menos
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {

        Debug.Log("Shoot");

        Vector3 direction;
        if (transform.localScale.x == 6.0f) direction = Vector2.left;
        else direction = Vector2.right;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<ScriptBala>().SetDirection(direction);
    }

   
}