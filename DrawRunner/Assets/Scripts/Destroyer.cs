using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject particle;
    public GameObject chainsaws;
    public float speed = 0f;
    void Start() {
        speed = 0f;
    }
    void Update() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
    }
    public void DestroyerSpeedZero() {
        speed = 0f;
    }
    public void DestroyerSpeedUp() {
        speed = 5f;
    }

    void OnCollisionEnter (Collision collision) {

        if(collision.collider.tag == "Obstacle") {
            Debug.Log("LevelFailed");
            Destroy(collision.gameObject);
            particle = Instantiate (particle, collision.gameObject.transform.position, Quaternion.identity) as GameObject;

            
        }

        
    }
        
}
