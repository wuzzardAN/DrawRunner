using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Draw : MonoBehaviour
{
    #region Singleton class: Draw 
    
    public static Draw Instance;

    void Awake() {
        if(Instance == null) {
            Instance = this;
        }
    }

    #endregion

    public GameObject m_Cube;
    public float m_DistanceZ;


    public int objectsInScene;
    public int totalObject;
    public int drawLimit;
    [SerializeField] Transform objectParent;
    [SerializeField] Slider progressFillDraw;


    Plane m_Plane;
    Vector3 m_DistanceFromCamera;

    void Start()
    {
        m_DistanceFromCamera = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - m_DistanceZ); 
        m_Plane = new Plane(Vector3.forward, m_DistanceFromCamera);

        
    }

    void Update()
    {
        CountObjects();
        UpdateDrawProgress();
        if(progressFillDraw.value < drawLimit) {
            DrawScreen();
        }
        else {
            Debug.Log("Full Amount");
        }
        
        
    }

    void CountObjects() {
        totalObject = objectParent.childCount;
        objectsInScene = totalObject;
    }

    public void UpdateDrawProgress() {
        progressFillDraw.value = ((float)objectsInScene);
        
    }

    void DrawScreen() {
        if (Input.GetMouseButton(0))
        {
           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            
            float enter = 0.0f;

            if (m_Plane.Raycast(ray, out enter))
            {
                GameObject go;
                Vector3 hitPoint = ray.GetPoint(enter);

                
                
                go = Instantiate(m_Cube,hitPoint, Quaternion.identity);
                go.transform.SetParent(transform);
            }
        }
    }

    

}
    
