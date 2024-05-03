using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLingote : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //Si se colisiona el gameobject con el tag "Personaje" se destruye este game object
    {
        if (collision.gameObject.tag == "Personaje")
        {
            Destroy(this.gameObject);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
