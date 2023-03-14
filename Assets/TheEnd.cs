using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
	void Update()
	{
		if (Input.GetButtonDown("Fire1") || Input.touchCount > 0)
		{
			Application.Quit();
		}
	}
}
