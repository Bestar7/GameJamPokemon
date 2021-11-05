using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    [SerializeField] private string startScene;
    [SerializeField] GameObject panelPause;

    public void Quit()
    {
        Debug.Log("Je quitte le jeu");
        Application.Quit();
    }

    public void StartGame()
    {
        Debug.Log("I start the game");
        Time.timeScale = 1;
        SceneManager.LoadScene(startScene);
    }

    public void Continue()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

}
