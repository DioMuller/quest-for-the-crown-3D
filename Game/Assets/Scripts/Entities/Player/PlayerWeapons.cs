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
    /// Weapon Object.
    /// </summary>
    public Weapon WeaponObject = null;

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
    int[] _currentWeapons = {0, 1};

    /// <summary>
    /// Switch weapon button is currently pressed.
    /// </summary>
    bool _switchWeaponPressed = false;

    /// <summary>
    /// Is the Use weapon button currently pressed?
    /// </summary>
    bool _useWeaponPressed = false;
    #endregion Private Attributes

    #region Public Attributes
    /// <summary>
    /// Weapons list.
    /// </summary>
    public WeaponStatus[] Weapons;
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
    public Weapon GetWeapon(int position)
    {
        var index = GetWeaponIndex(position);
        if( index < 0 || index > Weapons.Length ) return null;
        
        return Weapons[index].WeaponObject;
    }
    #endregion Weapon Instance Methods

    #region MonoBehaviour Methods
    /// <summary>
    /// Initializes MonoBehaviour.
    /// </summary>
    void Start()
    {
        _playerController = GetComponent<PlayerMovement>();

        foreach(WeaponStatus weapon in Weapons)
        {
            weapon.WeaponObject.Parent = transform;
            weapon.WeaponObject.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    void Update()
    {
        if (_playerController.Input.GetButton("QuickChangePrimary"))
        {
            if (!_switchWeaponPressed)
            {
                NextWeapon(0);
                _switchWeaponPressed = true;
            }
        }
        else if (_playerController.Input.GetButton("QuickChangeSecondary"))
        {
            if (!_switchWeaponPressed)
            {
                NextWeapon(1);
                _switchWeaponPressed = true;
            }
        }
        else
        {
            _switchWeaponPressed = false;

            if (GetWeaponIndex(0) >= 0 && _playerController.Input.GetButton("PrimaryAttack"))
			{
                if (!_useWeaponPressed)
                {
                    StartCoroutine(ActivateWeapon(GetWeapon(0)));
                    GetWeapon(0).Attack();
                    _useWeaponPressed = true;
                }
			}
            else if (GetWeaponIndex(1) >= 0 && _playerController.Input.GetButton("SecondaryAttack"))
            {
                if (!_useWeaponPressed)
                {
                    StartCoroutine(ActivateWeapon(GetWeapon(1)));
                    GetWeapon(1).Attack();
                    _useWeaponPressed = true;
                }
            }
            else
            {
                _useWeaponPressed = false;
            }
        }
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
    #endregion Public Methods

    #region Private Methods
    void NextWeapon(int position)
    {
        SetWeapon(position, _currentWeapons[position] + 1);       
    }

    void SetWeapon(int position, int index)
    {
        var oldWeapon = GetWeapon(position);

        if( index >= Weapons.Length ) index = 0;

        while( !Weapons[index].WeaponEnabled )
        {
            index++;

            if (Weapons[index].WeaponObject == oldWeapon) return;
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

    IEnumerator ActivateWeapon(Weapon weapon)
    {
        weapon.gameObject.SetActive(true);
        yield return new WaitForSeconds(weapon.Data.AnimationTime);
        weapon.gameObject.SetActive(false);
    }
    #endregion Private Methods
}
