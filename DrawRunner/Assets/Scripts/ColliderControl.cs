using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControl : MonoBehaviour
{
    public GameObject boxHolderPlaneL;

    public GameObject bridgeParticle;
    public GameObject planeParticle;
    public Transform bridgeTransform;
    public Transform boxHolderPlaneTransform;




    void OnCollisionEnter (Collision collision) {

        if (collision.collider.tag == "Finish") {
            Debug.Log("finish");
            FindObjectOfType<PlayerController>().EndGame();

        }
        if (collision.collider.tag == "Bridge") {
            
            Debug.Log("BridgeDestroy");
            Destroy(collision.gameObject);
            bridgeParticle = Instantiate (bridgeParticle, bridgeTransform.transform.position, Quaternion.identity) as GameObject;
        }
        if (collision.collider.tag == "BoxHolder") {
            Debug.Log("planeDestroy");
            Destroy(collision.gameObject);
            planeParticle = Instantiate (planeParticle, boxHolderPlaneTransform.transform.position, Quaternion.identity) as GameObject;
            

        }
        if (collision.collider.tag == "BoxHolder2") {
            Debug.Log("planeDestroy");
            Destroy(collision.gameObject);
            planeParticle = Instantiate (planeParticle, boxHolderPlaneTransform.transform.position, Quaternion.identity) as GameObject;
        }    
        if(collision.collider.tag == "Obstacle") {
            Debug.Log("LevelFailed");
            FindObjectOfType<PlayerController>().LevelFailed();
            
        }
        if (collision.collider.tag == "ChainsawDown") {
            Debug.Log("Chainsaw Down");
            Destroy(collision.gameObject);
            FindObjectOfType<Chainsaw>().MoveChainsawDown();
                
        }

        if (collision.collider.tag == "ChainsawForward") {
            Debug.Log("Chainsaw Forward");
            Destroy(collision.gameObject);
            FindObjectOfType<Chainsaw>().MoveChainsawForward();
                
        }


        
    }



    
}
