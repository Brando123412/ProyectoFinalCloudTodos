using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyController : Stats
{
    [SerializeField] protected PlayerController playerRefences;
    [SerializeField] protected float maxForce;
    [SerializeField] HealthBarController healthBar;
    public event Action<int, HealthBarController> onCollision;

    protected override void Awake()
    {
        base.Awake();
        playerRefences = FindObjectOfType<PlayerController>();
        onCollision += DamageCalculation;
    }
    private void FixedUpdate()
    {
        Movement();
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            Debug.Log(healthBar.gameObject);
            //onCollision?.Invoke(10,healthBar);
            healthBar.UpdateHealth(-10);
            Debug.Log("Te baje vida");
        }
    }

    protected virtual void Movement(){}
    private void DamageCalculation(int damageTaken, HealthBarController healthBarController)
    {
        healthBarController.UpdateHealth(-damageTaken);
    }

}
