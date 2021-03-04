using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawDown : MonoBehaviour
{
    public Transform chainsawHolderDown;
    Animator anim;


    public void Start() {
        anim = GetComponent<Animator>();
    }
    public void Update() {
        RotateChainsaw();
    }


    public void RotateChainsaw() {
        chainsawHolderDown.transform.Rotate(new Vector3(0f,0f,-300f) * Time.deltaTime);
    }

    public void ChainsawHolderDown() {
        anim.SetInteger ("ChainsawDown", 1);
    }
}
