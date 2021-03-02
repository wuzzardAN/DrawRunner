using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header ("Level Objects Color")]

    [SerializeField] Color build1Color;
    [SerializeField] Color build2Color;
    [SerializeField] Color build3Color;
    [SerializeField] Color build4Color;
    [SerializeField] Color build5Color;
    [SerializeField] Color tileColor;
    [SerializeField] Color destroyerColor;


    [Header ("UI (progress) Color")]
    [SerializeField] Color levelsliderColor;

    [Header ("Level Objects Material")]
    [SerializeField] Material build1Material;
    [SerializeField] Material build2Material;
    [SerializeField] Material build3Material;
    [SerializeField] Material build4Material;
    [SerializeField] Material build5Material;
    [SerializeField] Material tileMaterial;
    [SerializeField] Material destroyerMaterial;
    [SerializeField] Image levelsliderImage;

    


    void Start() {
        UpdateLevelColors();
    }
    void UpdateLevelColors() {
        build1Material.color = build1Color;
        build2Material.color = build2Color;
        build3Material.color = build3Color;
        build4Material.color = build4Color;
        build5Material.color = build5Color;
        tileMaterial.color = tileColor;
        destroyerMaterial.color = destroyerColor;
        levelsliderImage.color = levelsliderColor;

    }

    void OnValidate() {
        UpdateLevelColors();
    }




}
