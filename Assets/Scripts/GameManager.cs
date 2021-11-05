using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject diePanel;
    [SerializeField] GameObject pausePanel;
	private const string KEY_CURRENT_LEVEL = "currentLevel";
	private int progress => PlayerPrefs.GetInt(KEY_CURRENT_LEVEL);
	private bool isMenuOpen = false;

	private void Start()
	{
		if (progress == 0)
			PlayerPrefs.SetInt(KEY_CURRENT_LEVEL, 1); // on initialise le progrès au niveau 1
	}

	// escape to pause
	private void Update()
	{
		if (Input.GetButtonDown("Cancel") && SceneManager.GetActiveScene().buildIndex != 0) // on fait pause hors du menu principal
		{
			isMenuOpen = !isMenuOpen;
			pausePanel.SetActive(isMenuOpen);
			if (isMenuOpen)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
		}
	}

	// MENU BUTTON
	public void Continue()
	{
		isMenuOpen = false;
		pausePanel.SetActive(isMenuOpen);
		Time.timeScale = 1;
	}

	public void RestartLevel()
	{
		Continue();
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
	}

	public void Menu()
	{
		Continue();
		mainMenuPanel.SetActive(true);
		SceneManager.LoadSceneAsync(0);
	}

	public void Exit()
    {
        Debug.Log("Je quitte le jeu");
        Application.Quit();
    }

	public void ContinueProgress()
	{
		mainMenuPanel.SetActive(false);
		int progress = PlayerPrefs.GetInt(KEY_CURRENT_LEVEL);
		SceneManager.LoadSceneAsync(progress);
	}


	// PORATL METHOD
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
