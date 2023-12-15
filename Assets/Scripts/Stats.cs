using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Stats : MonoBehaviour
{
    [SerializeField] protected float _life;
    [SerializeField] protected float velocity;
    [SerializeField] protected string _name;
    [SerializeField] protected Rigidbody2D rb2d;
    [SerializeField] protected SpriteRenderer spriteRenderer;

    public event Action<float> OnLifeUpdated;
    public event Action OnPlayerDeath;

    protected virtual void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    protected virtual void UpdateLife(float damageAmount)
    {
        _life -= damageAmount;
        OnLifeUpdated?.Invoke(_life);

        if (_life <= 0)
        {
            OnPlayerDeath?.Invoke();
        }
    }
}
