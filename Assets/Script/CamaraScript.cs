using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    public GameObject Robot;

    

    // Update is called once per frame
    void Update() //Sistema para que la cámara siga al personaje en vectores X y Y
    {
        Vector3 position = transform.position;
        position.x = Robot.transform.position.x;
        position.y = Robot.transform.position.y;
        transform.position = position;
    }
}
