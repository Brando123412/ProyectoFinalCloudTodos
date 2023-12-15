using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyController : Stats
{
    [SerializeField] protected PlayerController playerRefences;
    [SerializeField] protected float maxForce;

    protected override void Awake()
    {
        base.Awake();
        playerRefences = FindObjectOfType<PlayerController>();
    }
    protected void FixedUpdate()
    {
        Movement();
    }
    protected virtual void Movement(){}

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
        return _daño;
    }
}
