using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(CharacterStatus))]
[RequireComponent(typeof(PlayerWeapons))]
public class PlayerGUI : MonoBehaviour 
{
	#region Public Attributes
	/// <summary>
	/// The player GUI.
	/// </summary>
	public Canvas PlayerCanvas;
	#endregion Public Attributes

	#region Private Attributes (Player Component Instances)
	/// <summary>
	/// The health script instance.
	/// </summary>
	private CharacterStatus _characterStatus;

    /// <summary>
    /// Player weapons instance.
    /// </summary>
    private PlayerWeapons _playerWeapons;
    #endregion Private Attributes (Player Component Instances)

    #region Private Attributes (Auxiliary Attributes)
    /// <summary>
    /// Primary Weapon Index.
    /// </summary>
    private int _primaryWeaponIndex = -1;

    /// <summary>
    /// Secondary Weapon Index.
    /// </summary>
    private int _secondaryWeaponIndex = -1;
    #endregion Private Attributes (Auxiliary Attributes)


    #region Private Attributes (GUI Attributes)
    /// <summary>
	/// The health bar instance.
	/// </summary>
	private CircleBar _healthBar;

	/// <summary>
	/// The magic bar instance.
	/// </summary>
	private CircleBar _magicBar;

    /// <summary>
    /// Primary Weapon GUI Renderer.
    /// </summary>
    private Image _primaryWeapon;

    /// <summary>
    /// Secondary weapon GUI renderer.
    /// </summary>
    private Image _secondaryWeapon;
	#endregion Private Attributes (GUI Attributes)

	#region MonoBehaviour Methods
	/// <summary>
	/// Called on initialization.
	/// </summary>
	void Start () 
	{
		#region Player Scripts
		_characterStatus = GetComponent<CharacterStatus>();
        _playerWeapons = GetComponent<PlayerWeapons>();
		#endregion Player Scripts

		#region GUI Components
		if( PlayerCanvas != null )
		{
			var statusPanel = PlayerCanvas.transform.FindChild("StatusPanel");

            #region Life and Magic bars
            var lifeBar = statusPanel.transform.FindChild("LifeBar");
			var magicBar = statusPanel.transform.FindChild("MagicBar");

			_healthBar = lifeBar.GetComponent<CircleBar>();
			_magicBar = magicBar.GetComponent<CircleBar>();

            _healthBar.MaximumValue = _characterStatus.Data.MaxHealth;
			_healthBar.CurrentValue = _characterStatus.CurrentHealth;

            _magicBar.MaximumValue = _characterStatus.Data.MaxMagic;
			_magicBar.CurrentValue = _characterStatus.CurrentMagic;
            #endregion Life and Magic bars

            #region Equiped Weapons
            _primaryWeapon = statusPanel.transform.FindChild("PrimaryItem").FindChild("Item").GetComponent<Image>();
            _secondaryWeapon = statusPanel.transform.FindChild("SecondaryItem").FindChild("Item").GetComponent<Image>();
            #endregion Equiped Weapons
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
        if (_characterStatus.Data.MaxHealth != _healthBar.MaximumValue) _healthBar.MaximumValue = _characterStatus.Data.MaxHealth;

		// Magic
		if( _characterStatus.CurrentMagic != _magicBar.CurrentValue ) _magicBar.CurrentValue = _characterStatus.CurrentMagic;
        if (_characterStatus.Data.MaxMagic != _magicBar.MaximumValue) _magicBar.MaximumValue = _characterStatus.Data.MaxMagic;

        // Primary Weapon
        if( _playerWeapons.GetWeaponIndex(0) != _primaryWeaponIndex )
        {
            _primaryWeaponIndex = _playerWeapons.GetWeaponIndex(0);

            if (_primaryWeaponIndex >= 0)
            {
                var weapon = _playerWeapons.GetWeapon(0);
                _primaryWeapon.enabled = true;
                _primaryWeapon.sprite = Sprite.Create(weapon.Data.Icon,
                    new Rect(0, 0, weapon.Data.Icon.width, weapon.Data.Icon.height),
                    new Vector2(0.5f, 0.5f), weapon.Data.Icon.height);
            }
            else
            {
                _primaryWeapon.enabled = false;
            }
        }

        // Secondary Weapon
        if (_playerWeapons.GetWeaponIndex(1) != _secondaryWeaponIndex)
        {
            _secondaryWeaponIndex = _playerWeapons.GetWeaponIndex(1);

            if (_secondaryWeaponIndex >= 0)
            {
                var weapon = _playerWeapons.GetWeapon(1);
                _secondaryWeapon.enabled = true;
                _secondaryWeapon.sprite = Sprite.Create(weapon.Data.Icon,
                    new Rect(0, 0, weapon.Data.Icon.width, weapon.Data.Icon.height),
                    new Vector2(0.5f, 0.5f), weapon.Data.Icon.height);
            }
            else
            {
                _secondaryWeapon.enabled = false;
            }
        }



	}
	#endregion MonoBehaviour Methods
}
