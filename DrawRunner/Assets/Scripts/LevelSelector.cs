using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;

    void Start () {

        int levelReached = PlayerPrefs.GetInt ("levelReached", 1);
        
        for (int i = 0; i < levelButtons.Length; i++) {

            if (i + 1 > levelReached) {
                levelButtons[i].interactable = false;
            }
        }
    }



    public void Level1() {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Level2() {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void Level3() {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void Level4() {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 4);
    }
    public void Level5() {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 5);
    }
    public void Level6() {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 6);
    }

}
