using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
	[SerializeField] Transform flashlight;

	// Update is called once per frame
	void Update()
    {
		setFlashlightRotation();
	}

	private Vector2 getMouseInput()
	{
		Vector2 LastMovement;

		LastMovement.x = Input.mousePosition.x - (Screen.width / 2); // position de souris par rapport au coin de la scene
		LastMovement.y = Input.mousePosition.y - (Screen.height / 2); // si je ne met pas le -Screen...
		var normDirectionPlayer = transform.localScale.normalized.x;
		LastMovement = normDirectionPlayer * LastMovement.normalized;
		return LastMovement;
	}

	// TODO : lorsqu'on se tourne, le personnage tourne aussi avec les controle de lampe
	private void setFlashlightRotation() {
		var mouseInput = getMouseInput();
		var angle = Mathf.Atan2(mouseInput.y, mouseInput.x) * Mathf.Rad2Deg;
		flashlight.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
