using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool gameHasEnded = false;
    public float restartDelay = 1;
    public GameObject completeLevelUI;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

	public void EndGame() // Public used so it can be referenced
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("HIT");
            //Restarting
            Invoke("Restart", restartDelay); //Delay
        }

        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
