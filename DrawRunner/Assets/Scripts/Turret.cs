using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Attributes")]
    private Transform target;
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    
    public GameObject bulletPref;
    public Transform firePoint;

    public Transform partToRotate;
    

    void Start() {
        InvokeRepeating ("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget() {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Player");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

            if (nearestEnemy != null && shortestDistance <= range) {
                target = nearestEnemy.transform;
            }
            else {
                target = null;
            }
        }

    }

    void Update() {
        if(target == null) {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler (rotation.x, 90f, rotation.z);

        if(fireCountdown <= 0f) {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot() {
        Debug.Log("Shoot");
        GameObject bulletGO = (GameObject)Instantiate(bulletPref, firePoint.position, firePoint.rotation);
        
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        
        if(bullet != null){
            bullet.Seek(target);
        }

    }

    void OnDrawGizmosSelected() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
