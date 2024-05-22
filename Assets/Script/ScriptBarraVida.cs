using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScriptBarraVida : MonoBehaviour
{

    public Image Vida;

    public float Health = 5;

    public float MaxHealth = 5;



    private void Update()
    {
        Vida.fillAmount = Health / MaxHealth;

        

    }

    private void OnTriggerEnter2D(Collider2D collision) //Si se colisiona el gameobject con el tag "Personaje" se destruye este game object
    {
        if (collision.gameObject.tag == "Bala")
        {
            Health = Health - 1;
        }
    }
}
