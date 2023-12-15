using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : Stats
{
    [Header("Movimientos")]
    public PlayerInput playerInput;
    Vector2 objetivo;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }


    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        
        if (value.performed)
        {
            Debug.Log("Me muevo");
            Vector2 inputMovement = value.ReadValue<Vector2>();
            rb2d.velocity = inputMovement * velocity;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
        

        
    }
    public void OnAim(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            Debug.Log("Estoy apuntando");
            Vector2 tmp = value.ReadValue<Vector2>();
            objetivo = Camera.main.ScreenToWorldPoint(tmp);
        }
        
    }
    public void OnAttack1(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Debug.Log("Ataack1");
        }

    }
    private void FixedUpdate()
    {
        float anguloRadianes = Mathf.Atan2(objetivo.y - transform.position.y, objetivo.x - transform.position.x);
        float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
        transform.rotation = Quaternion.Euler(0, 0, anguloGrados);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {

        }
        if (collision.gameObject.tag == "Buff")
        {

        }
        if (collision.gameObject.tag == "Wall")
        {

        }
    }
}
