using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public Button[] buttons;

	private bool isPointing = false;
	private int buttonIndex = 0;

	public void Update()
	{
		if (buttons.Length == 0) return;

		float axis = Input.GetAxisRaw("Horizontal_P1");

		if (isPointing)
		{
			if (axis == 0)
			{
				isPointing = false;
			}
		}
		else
		{
			if (axis > 0)
			{
				buttonIndex++;
				isPointing = true;
			}
			else if (axis < 0)
			{
				buttonIndex--;
				isPointing = true;
			}
		}

		if (buttonIndex < 0)
		{
			buttonIndex = 0;
		}
		else if (buttonIndex >= buttons.Length)
		{
			buttonIndex = buttons.Length - 1;
		}

		buttons[buttonIndex].Select();

		float jumpAxis = Input.GetAxisRaw("Jump_P1");

		if (jumpAxis > 0)
		{
			buttons[buttonIndex].onClick.Invoke();
		}
	}

	public void OnStartClick()
	{
		SceneManager.LoadScene("GameScene");
	}

	public void OnQuitClick()
	{
		Application.Quit();
	}
}