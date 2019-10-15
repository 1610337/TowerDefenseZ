using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Turrent : MonoBehaviour {

    private Transform target;

    [Header("Attributes")]

    public bool hasDirectShootingMode;
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public string name;
    private node node = null;
    public GameObject explosionEffect;

    [Header("Unity Setup Files")]

    

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Mandatory for CrazyGun")]

    public Camera mainCam;
    public GameObject CameraSpawn;
    private float rotSpeed = 20;
    private CanvasChanger canvasChanger = CanvasChanger.instance;

    Camera shootCamera;
    GameObject shootCameraObject;
    UnityEngine.EventSystems.PhysicsRaycaster ShootCameraRayCaster;

    // Use this for initialization
    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

    }

    void UpdateTarget()
    {
        if(hasDirectShootingMode)
        {
            return;
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;

            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (hasDirectShootingMode)
        {
            return;
        }

        if (target == null)
        {
            return;
        }
        // target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    
	}

    void Shoot()
    {
        
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        Destroy(bulletGO, 5f);

        if (bullet != null)
        {
            bullet.Seek(target);
            //this.node.instantiateGlowingEffect();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }

    public void goToShootMode()
    {

        Debug.Log("inside now spawn a new camera");

        if(shootCameraObject == null)
        {
            shootCamera = CameraSpawn.AddComponent(typeof(Camera)) as Camera;
              shootCameraObject = shootCamera.gameObject;
             ShootCameraRayCaster = shootCameraObject.AddComponent(typeof(UnityEngine.EventSystems.PhysicsRaycaster)) as UnityEngine.EventSystems.PhysicsRaycaster;
            //GameObject Bloom = shootCameraObject.AddComponent<Bloom>();
        }
        else
        {
            shootCameraObject.SetActive(true);
        }
       

        // i should also deactivate all other buttons (buttons in the shop)
        // instantiate more buttons and controllers that controll the camera and offer invoking shooting and a node function call to destroy this camera and then 
        // go back to node and normal camera 

        canvasChanger.activateShootingCanvas(this.gameObject);

        return;
    }

    public void leaveShootMode()
    {
        //shootCamera.GetComponent<GameObject>().des
        shootCameraObject.SetActive(false);
        this.node.crazyGunNotInShootingMode();
        return;
    }
    public string getName()
    {
        return this.name;
    }

    public void setNode(node node)
    {
        this.node = node;
        return;
    }

    public void shootStraight()
    {
        Debug.Log("Shooting af");
        //Vector3 shootingDirection = transform.position;
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }

    public void explode()
    {
        GameObject effectInstance = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
        this.gameObject.SetActive(false);
    }

}
