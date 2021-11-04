using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSettings : MonoBehaviour
{
	private void Awake()
	{
		RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
		RenderSettings.ambientLight = Color.black;
	}

	private void Update()
	{
		RenderSettings.ambientLight = Color.black;
	}
}
