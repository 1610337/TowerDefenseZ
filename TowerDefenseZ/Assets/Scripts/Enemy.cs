using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float speed = 50f;

    private Transform target;
    private int wavePointIndex = 0;

    public float startHealth;
    private float currentHealth;

    public int value = 50;

    public GameObject deathEffect;

    [Header("Unity Internal")]

    public Image Healthbar;

     void Start()
    {
        target = Waypoints.points[0];
        currentHealth = startHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
        Healthbar.fillAmount = currentHealth / startHealth;
    }
    private void Die()
    {
        PlayerStats.instance.IncreaseMoney(value);

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
        Destroy(effect);
    }

     void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextWayPoint();
            return;
        }
    }

    void GetNextWayPoint()
    {
        if (wavePointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
        }
        wavePointIndex++;
        target = Waypoints.points[wavePointIndex];
    }

    void EndPath()
    {
        PlayerStats.instance.ReduceLives();
        Destroy(gameObject);
    }
}
