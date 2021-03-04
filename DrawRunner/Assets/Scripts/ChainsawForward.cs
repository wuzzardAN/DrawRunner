using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawForward : MonoBehaviour
{
    public Transform chainsawHolderForward;
    Animator anim;


    public void Start() {
        anim = GetComponent<Animator>();
    }
    public void Update() {
        RotateChainsaw();
    }


    public void RotateChainsaw() {
        chainsawHolderForward.transform.Rotate(new Vector3(0f,0f,-300f) * Time.deltaTime);
    }

    public void ChainsawHolderForward() {
        anim.SetInteger ("ChainsawForward", 1);
    }
}
