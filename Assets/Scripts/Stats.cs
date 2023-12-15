using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Stats : MonoBehaviour
{
    [SerializeField] protected float _life; /*{ get { return _life; } set { _life=value; } }*/
    [SerializeField] protected float _da�o;
    [SerializeField] protected float velocity;
    [SerializeField] protected string _name;
    [SerializeField] protected Rigidbody2D rb2d;
    [SerializeField] protected SpriteRenderer spriteRenderer;  

    protected virtual void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
   
}
