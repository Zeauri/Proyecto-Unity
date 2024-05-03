using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptPuntuaje : MonoBehaviour
{
    private int score;
    public Text scoreText;
    private void Update()
    {
        if (score == 8) //Sistema para que al alcanzar el score deseado nos aparezca un mensaje
        {
            scoreText.text = "¡Nivel superado!";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0; //Para que cada vez que empieze el valor de "Score" sea 0
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Moneda") //Si toca el game object con el tag "Moneda"
        {
            score++; //Subir el score

        scoreText.text = "Monedas = " + score;
        }
    }
}
