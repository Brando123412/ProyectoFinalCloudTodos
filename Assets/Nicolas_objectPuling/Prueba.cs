using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    float a = 0.007f;
    public objectPulling controlador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - a, transform.position.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "eliminador")
        {
            print("si");
            controlador.DesactiveObject(this.gameObject);
        }
    }
}
