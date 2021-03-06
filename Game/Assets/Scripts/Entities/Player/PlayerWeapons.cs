using UnityEngine;
using Assets.Code.Libs.Input;
using System.Collections;
using System.Collections.Generic;
using Assets.Code.Libs;
using System;
using System.Linq;

/// <summary>
/// Weapon Status container.
/// </summary>
[Serializable]
public class WeaponStatus
{
	/// <summary>
	/// Weapon Name/Id.
	/// </summary>
	public Weapons WeaponType;

    /// <summary>
    /// Weapon Object.
    /// </summary>
    public Weapon WeaponObject = null;

	/// <summary>
	/// Weapon Model.
	/// </summary>
	public GameObject WeaponModel = null;

    /// <summary>
    /// Is the weapon enabled?
    /// </summary>
    public bool WeaponEnabled = false;
}

[RequireComponent(typeof(PlayerMovement))]
public class PlayerWeapons : MonoBehaviour
{
    #region Private Attributes
    /// <summary>
    /// The player controller.
    /// </summary>
    PlayerMovement _playerController;

    /// <summary>
    /// Current Weapons Index.
    /// </summary>
    int[] _currentWeapons = {0, -1};

    /// <summary>
    /// Switch weapon button is currently pressed.
    /// </summary>
    bool _switchWeaponPressed = false;

    /// <summary>
    /// Is the Use weapon button currently pressed?
    /// </summary>
    bool _useWeaponPressed = false;

    /// <summary>
    /// Is a weapon active?
    /// </summary>
    bool _weaponActive = false;
    #endregion Private Attributes

    #region Public Attributes
    /// <summary>
    /// Weapons list.
    /// </summary>
    public WeaponStatus[] Weapons;

    /// <summary>
    /// Character Animator.
    /// </summary>
    public Animator Animator;
    #endregion Public Attributes

    #region Weapon Instance Methods
    /// <summary>
    /// Get Current Weapon Indexes.
    /// </summary>
    /// <param name="position">Weapon Position.</param>
    /// <returns>Weapon Index.</returns>
    public int GetWeaponIndex(int position)
    {
        if (position < 0 || position > _currentWeapons.Length) return -1;

        return _currentWeapons[position];
    }

    /// <summary>
    /// Get Weapon Data.
    /// </summary>
    /// <param name="position">Weapon Index.</param>
    /// <returns>Weapon instance (null if not exists).</returns>
    public WeaponStatus GetWeapon(int position)
    {
        var index = GetWeaponIndex(position);
        if( index < 0 || index > Weapons.Length ) return null;
        
        return Weapons[index];
    }
    #endregion Weapon Instance Methods

    #region MonoBehaviour Methods
    /// <summary>
    /// Initializes MonoBehaviour.
    /// </summary>
    void Start()
    {
        _playerController = GetComponent<PlayerMovement>();

		UpdateWeapons();
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    void Update()
    {
        if (!_playerController.CanMove) return;
        if (_weaponActive) return;

        #region Weapon Change Controls

		#region Primary
        if (_playerController.Input.GetButton("QuickChangePrimaryUp"))
        {
            if (!_switchWeaponPressed)
            {
                NextWeaponUp(0);
                _switchWeaponPressed = true;
            }

            return;
        }
		if (_playerController.Input.GetButton("QuickChangePrimaryDown"))
		{
			if (!_switchWeaponPressed)
			{
				NextWeaponDown(0);
				_switchWeaponPressed = true;
			}

			return;
		}
		#endregion Primary

		#region Secondary
		if (_playerController.Input.GetButton("QuickChangeSecondaryUp"))
        {
            if (!_switchWeaponPressed)
            {
                NextWeaponUp(1);
                _switchWeaponPressed = true;
            }

            return;
		}

		if (_playerController.Input.GetButton("QuickChangeSecondaryDown"))
		{
			if (!_switchWeaponPressed)
			{
				NextWeaponDown(1);
				_switchWeaponPressed = true;
			}

			return;
		}
		#endregion Secondary

		#endregion Weapon Change Controls

		#region Weapon Use Controls
		_switchWeaponPressed = false;

        if (GetWeaponIndex(0) >= 0 && _playerController.Input.GetButton("PrimaryAttack"))
        {
            if (!_useWeaponPressed)
            {
                StartCoroutine(ActivateWeapon(GetWeapon(0)));
                _useWeaponPressed = true;
            }
        }
        else if (GetWeaponIndex(1) >= 0 && _playerController.Input.GetButton("SecondaryAttack"))
        {
            if (!_useWeaponPressed)
            {
                StartCoroutine(ActivateWeapon(GetWeapon(1)));
                _useWeaponPressed = true;
            }
        }
        else
        {
            _useWeaponPressed = false;
        }
        #endregion Weapon Use Controls
    }
    #endregion MonoBehaviour Methods

    #region Public Methods
    public void AddWeapon(Weapon weapon)
    {
        var wp = Weapons.FirstOrDefault((w) => w.WeaponObject.GetType() == weapon.GetType());

        if (wp != null)
        {
            wp.WeaponEnabled = true;
        }        
    }

    public void RemoveWeapon(Weapon weapon)
    {
        var wp = Weapons.FirstOrDefault((w) => w.WeaponObject.GetType() == weapon.GetType());

        if (wp != null)
        {
            wp.WeaponEnabled = false;
        }
    }

	public void UpdateWeapons()
	{
		for( int i = 0; i < Weapons.Length; i++ )
		{
			Weapons[i].WeaponObject.Parent = transform;
			Weapons[i].WeaponObject.gameObject.SetActive(false);

			if (Weapons[i].WeaponModel != null) Weapons[i].WeaponModel.SetActive(false);

			Weapons[i].WeaponEnabled = PlayerManager.IsWeaponActive(Weapons[i].WeaponType);

			if (Weapons[i].WeaponEnabled)
			{
				for (int j = 0; j < _currentWeapons.Length; j++)
				{
					if (_currentWeapons[j] == -1 || _currentWeapons[j] == i)
					{
						_currentWeapons[j] = i;
						break;
					}
				}
			}
		}
	}
    #endregion Public Methods

    #region Private Methods
    void NextWeaponUp(int position)
    {
        SetWeapon(position, _currentWeapons[position] + 1);       
    }

	void NextWeaponDown(int position)
	{
		SetWeapon(position, _currentWeapons[position] - 1);
	}

    void SetWeapon(int position, int index)
    {
	    var diff = _currentWeapons[position] < index ? 1 : -1;
	    var ow = GetWeapon(position);
        var oldWeapon = ow != null ?  ow.WeaponObject : null;

        if( index >= Weapons.Length ) index = 0;
	    if (index < 0) index = Weapons.Length - 1;

        while( !Weapons[index].WeaponEnabled )
        {
			index = (index + diff) % Weapons.Length;

            if ( Weapons[index].WeaponObject == oldWeapon) return;
        }

        _currentWeapons[position] = index;
        var newWeapon = Weapons[index].WeaponObject;
        

        if (oldWeapon != newWeapon)
        {
            if (oldWeapon != null)
                oldWeapon.OnUnequip();
            if (newWeapon != null)
                newWeapon.OnEquip();
        }
    }

    IEnumerator ActivateWeapon(WeaponStatus weaponStatus)
    {
	    var weapon = weaponStatus.WeaponObject;
	    var model = weaponStatus.WeaponModel;

        if (Animator == null) yield return null;

        _weaponActive = true;
		
		if( model != null ) model.SetActive(true);
        weapon.gameObject.SetActive(true);
        Animator.SetBool(weapon.Data.AnimationFlag, true);

        yield return new WaitForSeconds(weapon.Data.AnimationTime);

        weapon.Attack();

        Animator.SetBool(weapon.Data.AnimationFlag, false);
        weapon.gameObject.SetActive(false);
		if (model != null) model.SetActive(false);

        _weaponActive = false;
    }
    #endregion Private Methods
}
