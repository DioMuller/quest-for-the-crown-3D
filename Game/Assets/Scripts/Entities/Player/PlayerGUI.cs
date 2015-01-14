using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(CharacterStatus))]
public class PlayerGUI : MonoBehaviour 
{
	#region Public Attributes
	/// <summary>
	/// The player GUI.
	/// </summary>
	public Canvas PlayerCanvas;
	#endregion Public Attributes

	#region Private Attributes (Player Attributes)
	/// <summary>
	/// The health script instance.
	/// </summary>
	private CharacterStatus _characterStatus;
	#endregion Private Attributes (Player Attributes)

	#region Private Attributes (GUI Attributes)
	/// <summary>
	/// The health bar instance.
	/// </summary>
	private GUIBar _healthBar;

	/// <summary>
	/// The magic bar instance.
	/// </summary>
	private GUIBar _magicBar;
	#endregion Private Attributes (GUI Attributes)


	#region MonoBehaviour Methods
	/// <summary>
	/// Called on initialization.
	/// </summary>
	void Start () 
	{
		#region Player Scripts
		_characterStatus = GetComponent<CharacterStatus>();
		#endregion Player Scripts

		#region GUI Components
		if( PlayerCanvas != null )
		{
			var statusPanel = PlayerCanvas.transform.FindChild("StatusPanel");

			var lifeBar = statusPanel.transform.FindChild("LifeBar");
			var magicBar = statusPanel.transform.FindChild("MagicBar");

			_healthBar = lifeBar.GetComponent<GUIBar>();
			_magicBar = magicBar.GetComponent<GUIBar>();

			_healthBar.MaximumValue = _characterStatus.MaxHealth;
			_healthBar.CurrentValue = _characterStatus.CurrentHealth;

			_magicBar.MaximumValue = _characterStatus.MaxMagic;
			_magicBar.CurrentValue = _characterStatus.CurrentMagic;
		}
		#endregion GUI Components
	}
	
	/// <summary>
	/// Called once per frame
	/// </summary>
	void Update () 
	{
		// Health
		if( _characterStatus.CurrentHealth != _healthBar.CurrentValue ) _healthBar.CurrentValue = _characterStatus.CurrentHealth;
		if( _characterStatus.MaxHealth != _healthBar.MaximumValue ) _healthBar.MaximumValue = _characterStatus.MaxHealth;

		// Magic
		if( _characterStatus.CurrentMagic != _magicBar.CurrentValue ) _magicBar.CurrentValue = _characterStatus.CurrentMagic;
		if( _characterStatus.MaxMagic != _magicBar.MaximumValue ) _magicBar.MaximumValue = _characterStatus.MaxMagic;
	}
	#endregion MonoBehaviour Methods
}
