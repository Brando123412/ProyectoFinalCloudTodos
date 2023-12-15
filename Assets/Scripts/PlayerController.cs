using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class PlayerController : Stats
{
    [Header("Movimientos")]
    public PlayerInput playerInput;
    Vector2 objetivo;

    [Header("Pool y Bullet")]
    [SerializeField] Pool objectPooling;
    [SerializeField] Transform positionDisparo;
    GameObject pooledObject;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }


    void Update()
    {
        float anguloRadianes = Mathf.Atan2(objetivo.y - transform.position.y, objetivo.x - transform.position.x);
        float anguloGrados = (180 / Mathf.PI) * anguloRadianes + 90;
        transform.rotation = Quaternion.Euler(0, 0, anguloGrados);
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
            tmp = new Vector2(tmp.x - transform.position.x, tmp.y - transform.position.y);
            objetivo = Camera.main.ScreenToWorldPoint(tmp);
            objetivo = objetivo - new Vector2(transform.position.x, transform.position.y);

            //objetivo.Normalize();
        }
        
    }
    public void OnAttack1(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            pooledObject = objectPooling.GetPooledObject();
            if (pooledObject != null)
            {
                pooledObject.transform.position = positionDisparo.position;

                Vector2 shootDirection = objetivo - new Vector2(positionDisparo.position.x, positionDisparo.position.y);
                shootDirection.Normalize();

                float angleRadians = Mathf.Atan2(shootDirection.y, shootDirection.x);
                float angleDegrees = angleRadians * Mathf.Rad2Deg;

                pooledObject.transform.rotation = Quaternion.Euler(0, 0, angleDegrees);
                pooledObject.SetActive(true);
                pooledObject.GetComponent<BulletController>().Shooting(shootDirection);
            }
        }

    }
    
    private void FixedUpdate()
    {
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Buff")
        {

        }
        if (collision.gameObject.tag == "Wall")
        {

        }
    }

    public float GetLife()
    {
        return _life;
    }
    public void setLife(float newLife)
    {
        _life = newLife;
    }
    public float GetDamage()
    {
        return _damage;
    }
}
