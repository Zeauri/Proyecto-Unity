using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{

    
    private float LastShoot;
    public GameObject BulletPrefab; //Es el prefab de la bala
    public Animator Animator; 
    public float Speed; //Modificador publica (la podemos modificar) de velocidad del personaje
    public float JumpForce; //Modificador publica (la podemos modificar) de potencia de salto del personaje
    private Rigidbody2D Rigidbody2d; //Creamos una variable que podemos acceder desde cualquier parte de este script de tipo Rigidbody2D
    private float Horizontal; //Es una variable creada para el movimiento
    private bool Grounded; //Creamos esto para saber si estamos en el suelo o no. Se representara en valores 1 o 0, Si esta suelo=1 si no lo esta=0
    private void Jump() //Salto
    {
        Rigidbody2d.AddForce(Vector2.up * JumpForce);
    }
    private void Shoot() //Sistema de direccionado de la bala
    {
        Vector3 direction;
        if(transform.localScale.x == -1.0f) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<ScriptBala>().SetDirection(direction);
    }








    private void FixedUpdate() //Usamos esto para que las fisicas se actualicen de manera más constante que el void update
    {
        Rigidbody2d.velocity = new Vector2(Horizontal, Rigidbody2d.velocity.y); //Linea para modificar velocidad
        
    }


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2d = GetComponent<Rigidbody2D>(); //Con esto cogemos el componente de Rigidbody2D y lo metemos en este script. En nuestro caso "MovimientoPersonaje"
        Animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //En horizontal se van a almacenar valores de tipo float, que son los valores reales (1.6f 5.6f)
        Horizontal = Input.GetAxisRaw("Horizontal") * Speed; //Con esto lo que tenemos son valores de 1 o -1 en función de lo que estemos pulsando en el teclado (A=-1 D=1 y si no pulsa nada=0)

        if (Horizontal < 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f); // Estas 2 lineas se usan para cambiar la dirección del personaje y mantenerlo depende de la tecla usada
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
  

        Animator.SetBool("Walking", Horizontal != 0.0f); //Si Horizontal es diferente a 0 vale true y si es igual igual a cero vale false
        
        
        Debug.DrawRay(transform.position,Vector3.down * 2.3f, Color.red); //Usamos esta linea para ver el resultado (el rayo) de la linea de abajo
        if (Physics2D.Raycast(transform.position, Vector3.down, 2.3f)) //Si el rayo que hemos creado aqui choca con el suelo nos dara true. Sino nos dara false
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.W) && Grounded) //Salto+condición de que este en grounded para que no sea como el "Flappy birds"
        {
            Jump();

        }

        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f) //Sistema de disparo
        {
            Shoot();
            LastShoot = Time.time;
        }

    }

    

}
