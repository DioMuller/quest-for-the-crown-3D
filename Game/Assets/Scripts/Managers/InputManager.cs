using UnityEngine;
using System.Collections;

/*
		ESC / START - Menu
		I / BACK - Inventory

		WASD / LS (Movement) = MovementHorizontal/MovementVertical
		Arrows/RS (Movement) = AimHorizontal/AimVertical

		M / LS (Press) = Map
		? / RS (Press) = ?

		CTRL / LT = PrimaryAttack
		ALT / RT = SecondaryAttack
		Q / LB = QuickChange (Main)
		E / RB = QuickChange (Secondary)

		SPACE / A = Action/Confirm
		LeftShift / B = Run/Cancel
		Z / X = ?
		X / Y = ?

		1 / U = UseItem 1
		2 / D = UseItem 2
		3 / L = UseItem 3
		4 / R = UseItem 4
 */

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
		cInput.SetKey("Keyboard_MoveLeft", "A");
		cInput.SetKey("Keyboard_MoveRight", "D");
		cInput.SetKey("Keyboard_MoveUp", "W");
		cInput.SetKey("Keyboard_MoveDown", "S");

		cInput.SetKey("Keyboard_AimLeft", Keys.LeftArrow);
		cInput.SetKey("Keyboard_AimRight", Keys.RightArrow);
		cInput.SetKey("Keyboard_AimUp", Keys.UpArrow);
		cInput.SetKey("Keyboard_AimDown", Keys.DownArrow);

		cInput.SetKey("Keyboard_Action", Keys.Space);
		cInput.SetKey("Keyboard_Confirm", Keys.Space);
		cInput.SetKey("Keyboard_Run", Keys.LeftShift);
		cInput.SetKey("Keyboard_Cancel", Keys.Escape);

		cInput.SetKey("Keyboard_Menu", Keys.F1);
		cInput.SetKey("Keyboard_Inventory", Keys.F2);

		cInput.SetKey("Keyboard_Map", "M");

		cInput.SetKey("Keyboard_PrimaryAttack", Keys.Mouse0, Keys.LeftControl);
		cInput.SetKey("Keyboard_SecondaryAttack", Keys.Mouse1, Keys.LeftAlt);

		cInput.SetKey("Keyboard_QuickChangePrimary", "Q");
		cInput.SetKey("Keyboard_QuickChangeSecondary", "E");

		cInput.SetKey("Keyboard_UseItem1", "1");
		cInput.SetKey("Keyboard_UseItem2", "2");
		cInput.SetKey("Keyboard_UseItem3", "3");
		cInput.SetKey("Keyboard_UseItem4", "4");

		//Axis
		cInput.SetAxis("Keyboard_MoveHorizontal", "Keyboard_MoveLeft", "Keyboard_MoveRight");
		cInput.SetAxis("Keyboard_MoveVertical", "Keyboard_MoveDown", "Keyboard_MoveUp");

		cInput.SetAxis("Keyboard_AimHorizontal", "Keyboard_AimLeft", "Keyboard_AimRight");
		cInput.SetAxis("Keyboard_AimVertical", "Keyboard_AimDown", "Keyboard_AimUp"); 

		//JOYPAD
		for (int i = 1; i < 3; i++)
		{
			//"Joystick" + i + "Button1"
			//"Joy" + i + "_
			//"Joy"+ i +" Axis 1+"
			// Buttons
			cInput.SetKey("Joy" + i + "_MoveLeft", "Joy" + i + " Axis 1-");
			cInput.SetKey("Joy" + i + "_MoveRight", "Joy" + i + " Axis 1+");
			cInput.SetKey("Joy" + i + "_MoveUp", "Joy" + i + " Axis 2-");
			cInput.SetKey("Joy" + i + "_MoveDown", "Joy" + i + " Axis 2+");

			cInput.SetKey("Joy" + i + "_AimLeft", "Joy" + i + " Axis 4-");
			cInput.SetKey("Joy" + i + "_AimRight", "Joy" + i + " Axis 4+");
			cInput.SetKey("Joy" + i + "_AimUp", "Joy" + i + " Axis 5-");
			cInput.SetKey("Joy" + i + "_AimDown", "Joy" + i + " Axis 5+");

			cInput.SetKey("Joy" + i + "_Action", "Joystick" + i + "Button0");
			cInput.SetKey("Joy" + i + "_Confirm", "Joystick" + i + "Button0");
			cInput.SetKey("Joy" + i + "_Run", "Joystick" + i + "Button1");
			cInput.SetKey("Joy" + i + "_Cancel", "Joystick" + i + "Button1");

			cInput.SetKey("Joy" + i + "_Menu", "Joystick" + i + "Button7");
			cInput.SetKey("Joy" + i + "_Inventory", "Joystick" + i + "Button6");

			cInput.SetKey("Joy" + i + "_Map", "Joystick" + i + "Button8");

			cInput.SetKey("Joy" + i + "_PrimaryAttack", "Joy" + i + " Axis 3-", "Joystick" + i + "Button2");
			cInput.SetKey("Joy" + i + "_SecondaryAttack", "Joy" + i + " Axis 3+", "Joystick" + i + "Button3");

			cInput.SetKey("Joy" + i + "_QuickChangePrimary", "Joystick" + i + "Button4");
			cInput.SetKey("Joy" + i + "_QuickChangeSecondary", "Joystick" + i + "Button5");

			cInput.SetKey("Joy" + i + "_UseItem1", "Joy" + i + " Axis 6-");
			cInput.SetKey("Joy" + i + "_UseItem2", "Joy" + i + " Axis 7-");
			cInput.SetKey("Joy" + i + "_UseItem3", "Joy" + i + " Axis 6+");
			cInput.SetKey("Joy" + i + "_UseItem4", "Joy" + i + " Axis 7+");

			//Axis
			cInput.SetAxis("Joy" + i + "_MoveHorizontal", "Joy" + i + "_MoveLeft", "Joy" + i + "_MoveRight");
			cInput.SetAxis("Joy" + i + "_MoveVertical", "Joy" + i + "_MoveDown", "Joy" + i + "_MoveUp");

			cInput.SetAxis("Joy" + i + "_AimHorizontal", "Joy" + i + "_AimLeft", "Joy" + i + "_AimRight");
			cInput.SetAxis("Joy" + i + "_AimVertical", "Joy" + i + "_AimDown", "Joy" + i + "_AimUp"); 
		}
	}
}
