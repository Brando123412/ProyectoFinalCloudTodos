using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float speed;
    private Camera mainCamera;
    Vector3 screenPoint;
    void Awake(){
        rb2d = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }
    public void Shooting(Vector3 directionshoot){
        rb2d.velocity = directionshoot* speed;
    }
    void Update()
    {
        screenPoint = mainCamera.WorldToViewportPoint(transform.position);

        if (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
        {
            gameObject.SetActive(false);
        }
    }
}
