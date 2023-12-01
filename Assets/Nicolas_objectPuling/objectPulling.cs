using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPulling : MonoBehaviour
{
    [SerializeField] GameObject ElObjeto;
    [SerializeField] int cantidad;
    [SerializeField] Vector2 PosicionInicial;
    List<GameObject> objetosActivos = new List<GameObject>();
    Queue<GameObject> objetosDesctivos = new Queue<GameObject>();


    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i < cantidad; i++)
        {
            GameObject a = Instantiate(ElObjeto, PosicionInicial, Quaternion.identity);
            InsertObjectPulling(a);
            // Agregar elementos a la cola
            objetosDesctivos.Enqueue(a);
            a.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    void InsertObjectPulling(GameObject a)
    {
        a.GetComponent<Prueba>().controlador = this;
    }

    public GameObject ActiveObject()
    {
        GameObject a = null;
        if (objetosDesctivos.Count != 0)
        {
            // Quitar el primer elemento de la cola
            a = objetosDesctivos.Dequeue();
            objetosActivos.Add(a);
            a.SetActive(true);


        }
        else
        {
            a = Instantiate(ElObjeto, PosicionInicial, Quaternion.identity);
            InsertObjectPulling(a);
            objetosActivos.Add(a);
        }

        return a;

    }

    public void DesactiveObject(GameObject a)
    {
        int indiceElemento = objetosActivos.FindIndex(x => x == a);
        objetosDesctivos.Enqueue(objetosActivos[indiceElemento]);
        objetosActivos[indiceElemento].SetActive(false);
        objetosActivos.RemoveAt(indiceElemento);

    }


}
