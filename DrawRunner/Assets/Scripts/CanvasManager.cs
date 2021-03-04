using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    #region Singleton class : CanvasManager 
    
    public static CanvasManager Instance;

    void Awake() {
        if(Instance == null) {
            Instance = this;
        }
    }

    #endregion

    [SerializeField] Transform Player;
    [SerializeField] Transform EndLine;
    [SerializeField] Slider levelProggress;

    private int currentSceneIndex;
    
    

    float maxDistance;



    public GameObject startGameUI;
    public RectTransform gameOverUI;
    public RectTransform endGameUI;
    

    void Start() {
        startGameUI.SetActive(true);
        maxDistance = getDistance();
        
    }

    void Update() {
        if(-Player.position.x <= maxDistance && -Player.position.x <= -EndLine.position.x) {
            float distance = 1 - (getDistance() / maxDistance);
            setProgress (distance);
        }
        
    }

    

    float getDistance() {
        return Vector3.Distance (Player.position, EndLine.position);
    }

    public void StartGame() {
        startGameUI.SetActive(false);
        FindObjectOfType<PlayerController>().TapToStart();
        
    }


    public void LevelFailed() {
        gameOverUI.DOAnchorPos(new Vector2(0,0), 0.7f);
    }

    public void LevelCompleted() {
        
        endGameUI.DOAnchorPos(new Vector2(0,0),0.7f);
    }

    public void RestartCurrentLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void setProgress(float p) {
        levelProggress.value = p;
    }

    public void LoadNextLevel() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ContinueGame() {
        currentSceneIndex = PlayerPrefs.GetInt("SavedScene");
        if(currentSceneIndex != 0) {
            SceneManager.LoadScene (currentSceneIndex);
        }
        else { 
             SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
            
        }
    }
}
