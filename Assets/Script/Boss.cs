using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    private int Health = 10;

    public void Hit() //Sistema de vidas por golpes
    {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);
        if (Health == 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
