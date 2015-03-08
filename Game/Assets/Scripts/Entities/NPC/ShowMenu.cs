using Assets.Code.Libs.Input;
using System;
using UnityEngine;

public class ShowMenu : MonoBehaviour, EventAction
{
	#region MonoBehaviour Methods
	/// <summary>
	/// Called when any objects collides with this.
	/// </summary>
	/// <param name="other"></param>
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			print("Player Contacted.");
			var interaction = other.GetComponent<PlayerInteraction>();

			if(interaction != null)
			{
				interaction.SetAction(this);
			}			
		}
	}

	/// <summary>
	/// Called when any objects exits collision with this.
	/// </summary>
	/// <param name="other"></param>
	void OnTriggerExit(Collider other) 
	{
		if (other.tag == "Player")
		{
			print("Player Is Out.");
			var interaction = other.GetComponent<PlayerInteraction>();
			
			if(interaction != null)
			{
                interaction.ClearAction(this);
			}			
		}
	}
	#endregion MonoBehaviour Methods

	#region Public Methods
    public bool Activate()
    {
	    if (OptionSelection.Instance == null) return false;

	    OptionSelection.Instance.OpenMissionSelection();
	    return true;
    }
    #endregion Methods
}
