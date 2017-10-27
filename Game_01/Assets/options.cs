using UnityEngine;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour {

	public void GoBack()
	{
		SceneManager.LoadScene ("Menu");
	}
}
