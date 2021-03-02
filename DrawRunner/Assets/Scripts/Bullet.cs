using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 10f;
    public GameObject bulletParticle;
    public float distanceThisFrame;

    public void Seek(Transform _target){
        
        target = _target;



    }

    void Update(){

        if(target == null) {
            
            Destroy(gameObject);
            return;

        }

        Vector3 dir = target.position - transform.position;
        distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame) {
            HitTarget();
            return;

        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);  

    }

    void HitTarget() {
        Instantiate(bulletParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision) {

        if (collision.collider.tag == "Draw") {
            Destroy(gameObject);
            Instantiate(bulletParticle, transform.position, transform.rotation);

        }
        if (collision.collider.tag == "Obstacle") {
            Destroy(gameObject);
            Instantiate(bulletParticle, transform.position, transform.rotation);
        }

        if(collision.collider.tag == "Player") {
            Debug.Log("LevelFailed");
            FindObjectOfType<PlayerController>().LevelFailed();
            
        }
    }



    

}
