using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public void LoadNextLevel()
    {
        
        PlayerPrefs.SetInt("levelReached", levelToUnlock);

        SceneManager.LoadScene("LevelSelect");
    }
}
