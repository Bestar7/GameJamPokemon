using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] GameObject panel;
	private bool isGettingInMenu = false;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Cancel"))
		{
			isGettingInMenu = !isGettingInMenu;
			panel.SetActive(isGettingInMenu);
			if (isGettingInMenu)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
		}
	}

	private void Continue()
	{
		panel.SetActive(true);
		Time.timeScale = 1;
	}

	private void Restart() // TODO VERIFIER CECI
	{
		throw new NotImplementedException();
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
	}

	private void Menu() // TODO Implementer Ceci
	{
		throw new NotImplementedException();
	}

	private void Quit()
	{
		Application.Quit();
	}

}
