using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Animator anim;
    public bool isgrounded;

    
    void Start() {
        anim = GetComponent<Animator>();
        speed = 0;
    }

    void Update() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (isgrounded == true) {
         
        }
    }
    
    
    public void EndGame() {
        speed = 0f;
        anim.SetInteger ("LevelComplete", 1);
        FindObjectOfType<CanvasManager>().LevelCompleted();
        FindObjectOfType<Destroyer>().DestroyerSpeedZero();
    }

    public void LevelFailed() {
        speed = 0f;
        anim.SetInteger ("LevelFailed", 2);
        FindObjectOfType<CanvasManager>().LevelFailed();
        FindObjectOfType<Destroyer>().DestroyerSpeedZero();
    }

    public void TapToStart() {
        speed = 5f;
        anim.SetInteger ("StartGame", 4);
        FindObjectOfType<Destroyer>().DestroyerSpeedUp();

    }

    
    


    



}
