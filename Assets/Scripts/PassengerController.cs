using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassengerController : MonoBehaviour
{
    private const string KEY_CURRENT_LEVEL = "currentLevel";
    [SerializeField] private int offsetLevel;
    private bool isEntered;
	private bool isBonus => transform.name.Contains("Bonus");
    // Start is called before the first frame update
    
    public void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isEntered = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isEntered = false;
	}

    private void Update()
    {
        if (Input.GetKeyDown("down") && isEntered)
        {
			if (isBonus)
				GoToLevelBonus(transform.name);
			GoToLevel();
        }
    }


    private void GoToLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + offsetLevel;
        PlayerPrefs.SetInt(KEY_CURRENT_LEVEL, nextScene);
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync(nextScene);
    }

	private void GoToLevelBonus(string bonusScene)
	{
		SceneManager.LoadSceneAsync(bonusScene);
	}
}
