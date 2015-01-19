using UnityEngine;
using Assets.Code.Libs.Input;
using System.Collections;
using System.Collections.Generic;
using Assets.Code.Libs;
using System;
using System.Linq;

[Serializable]
public class WeaponStatus
{
    public Weapon WeaponObject = null;
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

    int _currentWeapon = -1;

    /// <summary>
    /// Switch weapon button is currently pressed.
    /// </summary>
    bool _switchWeaponPressed = false;
    #endregion Private Attributes

    #region Public Attributes
    public WeaponStatus[] Weapons;
    #endregion Public Attributes

    #region Public Properties
    public Weapon CurrentWeapon
    {
        get { return _currentWeapon >= Weapons.Length || _currentWeapon < 0 ? null : Weapons[_currentWeapon].WeaponObject; }
    }
    #endregion

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
                NextWeapon();
                _switchWeaponPressed = true;
            }
        }
        else
        {
            _switchWeaponPressed = false;

            if (CurrentWeapon != null && _playerController.Input.GetButton("PrimaryAttack"))
			{
                CurrentWeapon.Attack();
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
    void NextWeapon()
    {
        
        SetWeapon(_currentWeapon + 1);       
    }

    void SetWeapon(int index)
    {
        var oldWeapon = CurrentWeapon;

        if( index >= Weapons.Length ) index = 0;

        while( !Weapons[index].WeaponEnabled )
        {
            index++;

            if (Weapons[index].WeaponObject == oldWeapon) return;
        }

        _currentWeapon = index;
        var newWeapon = Weapons[index].WeaponObject;
        

        if (oldWeapon != newWeapon)
        {
            if (oldWeapon != null)
                oldWeapon.OnUnequip();
            if (newWeapon != null)
                newWeapon.OnEquip();
        }
    }
    #endregion Private Methods
}
