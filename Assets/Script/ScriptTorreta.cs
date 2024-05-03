using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTorreta : MonoBehaviour
{
    

    public GameObject Robot;

    

    private float LastShoot;

    private void Update()
    {
        Vector3 direction = Robot.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(6.0f, 8.0f, 1.0f);
        else transform.localScale = new Vector3(-6.0f, 8.0f, 1.0f);

        float distance = Mathf.Abs(Robot.transform.position.x - transform.position.x);

        if (distance < 6.0f && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Debug.Log("Shoot");
        
    }

   
}