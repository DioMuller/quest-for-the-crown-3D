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

		// setting up the default inputkeys...
		cInput.SetKey("Pause", "P"); // sets the 'Pause' input to "P" - notice we didn't set up a secondary input-this will be defaulted to 'None'
		cInput.SetKey("Left", "A", "LeftArrow"); // sets the 'Left' primary input to 'A' and the secondary input to 'LeftArrow'
		cInput.SetKey("Right", "D", Keys.RightArrow); // inputs can be set as string or as Key, using the Keys class
		cInput.SetKey("Up", "W", Keys.UpArrow); // using the Keys class allows you to autocomplete the inputs
		cInput.SetKey("Down", "S", Keys.DownArrow);
		cInput.SetKey("Shoot", Keys.Space, Keys.X, Keys.None, Keys.LeftShift); // here we set up a default modifier key for "X" so ACTION "Shoot" will default to 'SPACE' & 'LeftShift+X' as default inputs 

		// The Keys class can be very helpful in getting the correct name.
		cInput.SetKey("Weapon 1", Keys.Joy1Axis1Negative);
		cInput.SetKey("Weapon 2", Keys.Joy1Axis1Positive);
		cInput.SetKey("Weapon 3", Keys.Joy1Axis1Negative);
		cInput.SetKey("Weapon 4", Keys.Joy1Axis1Positive);
		cInput.SetKey("Weapon 5", Keys.Joy1Axis1Negative);
		cInput.SetKey("Weapon 6", Keys.Joy1Axis1Positive);
		// Note that the aboveinputs aren't actually used in this demo.
		// They're just defined here to show you how it's done.

		// we define an axis like this:
		cInput.SetAxis("Horizontal", "Left", "Right"); // we set up the 'Horizontal' axis with 'Left' and 'Right'as inputs
		cInput.SetAxis("Vertical", "Up", "Down"); // we set up 'Vertical' axis with 'Up' and 'Down' as inputs. 
		// Notice we don't use the 'Vertical' axis in our control code in plane.cs but we don't want to allow modifier keys for inputs UP and DOWN. Any inputs that are part of an axis are ignoring modifiers
	}
}
