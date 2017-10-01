using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    public string nextLevel = "Level03";
    public int levelToUnlock = 3;

    public void LoadNextLevel()
    {

        if (levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }

        SceneManager.LoadScene("LevelSelect");
    }
}
