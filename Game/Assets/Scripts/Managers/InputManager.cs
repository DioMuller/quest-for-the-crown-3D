using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Awake() 
	{
		// initialize cInput
		cInput.Init();

		// cINPUT SETUP

		// KEYBOARD
		// Keys
		cInput.SetKey("Keyboard_Pause", "P");
		cInput.SetKey("Keyboard_Left", "A", "LeftArrow");
		cInput.SetKey("Keyboard_Right", "D", Keys.RightArrow);
		cInput.SetKey("Keyboard_Up", "W", Keys.UpArrow);
		cInput.SetKey("Keyboard_Down", "S", Keys.DownArrow);
		cInput.SetKey("Keyboard_Action", Keys.Space, Keys.X);
		//Axis
		cInput.SetAxis("Keyboard_Horizontal", "Keyboard_Left", "Keyboard_Right");
		cInput.SetAxis("Keyboard_Vertical", "Keyboard_Up", "Keyboard_Down"); 

		//JOYPAD
		for (int i = 1; i <= 4; i++)
		{
			// KEYBOARD
			// Keys
			cInput.SetKey("Joy" + i + "_Pause", "Joystick" + i + "Button1");
			cInput.SetKey("Joy" + i + "_Left", "A", "Joy"+ i +" Axis 1+");
			cInput.SetKey("Joy" + i + "_Right", "D", "Joy" + i + " Axis 1-");
			cInput.SetKey("Joy" + i + "_Up", "W", "Joy" + i + " Axis 2+");
			cInput.SetKey("Joy" + i + "_Down", "S", "Joy" + i + " Axis 2-");
			cInput.SetKey("Joy" + i + "_Action", "Joystick" + i + "Button1");

			//Axis
			cInput.SetAxis("Joy" + i + "_Horizontal", "Joy" + i + "_Left", "Joy" + i + "_Right");
			cInput.SetAxis("Joy" + i + "_Vertical", "Joy" + i + "_Up", "Joy" + i + "_Down"); 
		}
	}
}
