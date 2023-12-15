using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.SteeringBehaviours;
public class EnemyChicken : EnemyController
{
    [SerializeField] Pool objectPooling;
    [SerializeField] Transform positionDisparo;
    [SerializeField]bool canShoot=false;
    GameObject pooledObject;
    Vector3 direction;
    private void Start()
    {
        InvokeRepeating("Shoot", 0f, 2f);
    }
    protected override void Movement()
    {
        rb2d.velocity = SteeringBehaviours.Seek(new Vector2(transform.position.x, transform.position.y), new Vector2(rb2d.velocity.x, rb2d.velocity.y),
            new Vector2(playerRefences.transform.position.x, playerRefences.transform.position.y), velocity, maxForce);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canShoot = true;
            print("Triger");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canShoot = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            print("collider");
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            _life--;
            if (_life <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Shoot()
    {
        if (canShoot)
        {
            direction = playerRefences.gameObject.transform.position - transform.position;
            direction.Normalize();
            pooledObject = objectPooling.GetPooledObject();
            if (pooledObject != null)
            {
                pooledObject.transform.position = positionDisparo.position;
                pooledObject.SetActive(true);
                pooledObject.GetComponent<BulletController>().Shooting(direction);
            }
        }
    }
}
