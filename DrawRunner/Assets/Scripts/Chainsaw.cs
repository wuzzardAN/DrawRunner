using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour
{
    public GameObject chainsaws;
    void Start()
    {
        
    }

    void Update()
    {
        RotateChainsaw();
    }

    void RotateChainsaw() {
        iTween.RotateBy(chainsaws, iTween.Hash(
                    "z", 1f,
                    "speed", 200f,
                    "easetype", iTween.EaseType.linear
                ));
    }
    public void MoveChainsawDown() {
        iTween.MoveTo(this.gameObject, iTween.Hash(
            "position", new Vector3(-23,0,0),
            "speed", 2f,
            "easetype", iTween.EaseType.linear

        ));
    }

    public void MoveChainsawForward() {
        iTween.MoveTo(this.gameObject, iTween.Hash(
            "position", new Vector3(-115,2,0),
            "speed", 2f,
            "easetype", iTween.EaseType.linear

        ));
    }
}
