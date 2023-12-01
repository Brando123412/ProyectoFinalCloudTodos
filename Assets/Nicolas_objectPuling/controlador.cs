using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlador : MonoBehaviour
{
    float a = 0.1f;
    float tiempo = 0;
    GameObject b;


    [SerializeField]objectPulling objectPuling;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        if (tiempo > a)
        {
            tiempo = 0;
            b=objectPuling.ActiveObject();
            b.transform.position = new Vector2(10.8f, 0);
        }
    }
}
