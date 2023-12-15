using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float seep;

    void Awake(){
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Shooting(Vector3 directionshoot){
        Vector3 direction = directionshoot - transform.position;
        direction.Normalize();  
        rb2d.velocity = new Vector2(direction.x,direction.y)*seep;
    }
}
