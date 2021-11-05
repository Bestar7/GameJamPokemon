using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] GameObject panel;
	private bool isMenuOpen { get; set; } 

	private void Awake()
	{
		//Instantiate(panel);
		isMenuOpen = false;
	}

	private void Update()
	{
		if (Input.GetButtonDown("Cancel"))
		{
			isMenuOpen = !isMenuOpen;
			panel.SetActive(isMenuOpen);
			if (isMenuOpen)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
		}
	}

	public void Continue()
	{
		isMenuOpen = false;
		panel.SetActive(isMenuOpen);
		Time.timeScale = 1;
	}
}
