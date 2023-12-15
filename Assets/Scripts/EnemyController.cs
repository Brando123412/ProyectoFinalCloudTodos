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
    

}
