using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.SteeringBehaviours;
public class EnemyChicken : EnemyController
{
    protected override void Movement()
    {
        rb2d.velocity = SteeringBehaviours.Seek(new Vector2(transform.position.x, transform.position.y), new Vector2(rb2d.velocity.x, rb2d.velocity.y),
            new Vector2(playerRefences.transform.position.x, playerRefences.transform.position.y), velocity, maxForce);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        }
    }
}
