using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DamageManager : MonoBehaviour
{
    [SerializeField] HealthBarController _barravida;
    [SerializeField] HealthBarController enem;


    void Start()
    {
        _barravida.OnLifeUpdated += ChangeLifePlayer;
        enem.OnLifeUpdated += ChangeLifeEnemy;
        enem.OnPlayerDeath += DiedEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeLifePlayer(float damageRecive)
    {
        _barravida.UpdateHealth(damageRecive);
    }
    void ChangeLifeEnemy(float damageRecive)
    {
        enem.UpdateHealth(damageRecive);
    }
    void DiedEnemy()
    {
        Destroy(enem.gameObject);
    }
}
