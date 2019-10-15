using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRazyGunBullet : MonoBehaviour {
    private Transform target;

    public float speed = 60f;
    public float explosionRadius = 0f;
    public GameObject impactEffect;
    public GameObject startEffect;
    public int damage = 25;
    private string enemyTag = "Enemy";
    private Vector3 startPosition;

    private void Start()
    {
        this.startPosition = transform.position;
        GameObject effectInstance = (GameObject)Instantiate(startEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 5f);
    }

    void Update()
    {
        if(Vector3.Distance(startPosition, transform.position)> 55)
        {
            //Destroy(effectInstance, 5f);
            Destroy(this.gameObject, 5f);
        }
        transform.position += Time.deltaTime * speed * transform.forward;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < 2)
            {
                //Damage(enemy.transform);
                HitTarget(enemy.transform);
            }
        }

    }

    void HitTarget(Transform enemy)
    {
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(enemy);
        }
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
