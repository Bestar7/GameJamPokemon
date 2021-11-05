using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    [SerializeField] private string startScene;
    [SerializeField] GameObject panelPause;
	private const string KEY_CURRENT_LEVEL = "currentLevel";


	public void Quit()
    {
        Debug.Log("Je quitte le jeu");
        Application.Quit();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

	public void ContinueProgress()
	{
		int progress = PlayerPrefs.GetInt(KEY_CURRENT_LEVEL);
		SceneManager.LoadSceneAsync(progress);
	}

	public void PreviousLevel()
	{
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
	}

	public void NextLevel()
	{
		int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
		PlayerPrefs.SetInt(KEY_CURRENT_LEVEL, nextScene);
		PlayerPrefs.Save();
		SceneManager.LoadSceneAsync(nextScene);
	}

}
