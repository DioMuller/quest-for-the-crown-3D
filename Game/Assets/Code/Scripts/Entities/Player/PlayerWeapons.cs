using UnityEngine;
using Assets.Code.Libs.Input;
using System.Collections;
using System.Collections.Generic;
using Assets.Code.Libs;
using System;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerWeapons : MonoBehaviour
{
    #region Private Attributes
    /// <summary>
    /// The player controller.
    /// </summary>
    PlayerMovement _playerController;

    int _currentWeapon;

    /// <summary>
    /// Switch weapon button is currently pressed.
    /// </summary>
    bool _switchWeaponPressed = false;

    IList<IWeapon> _weapons;
    #endregion Private Attributes

    #region Public Properties
    public IWeapon CurrentWeapon
    {
        get { return _currentWeapon >= _weapons.Count ? null : _weapons[_currentWeapon]; }
    }
    #endregion

    #region MonoBehaviour Methods
    /// <summary>
    /// Initializes MonoBehaviour.
    /// </summary>
    void Start()
    {
        _playerController = GetComponent<PlayerMovement>();
        _weapons = new List<IWeapon>();
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    void Update()
    {
        if (_playerController.Input.GetButton("NextWeapon"))
        {
            if (!_switchWeaponPressed)
            {
                NextWeapon();
                _switchWeaponPressed = true;
            }
        }
        else if (_playerController.Input.GetButton("PreviousWeapon"))
        {
            if (!_switchWeaponPressed)
            {
                PreviousWeapon();
                _switchWeaponPressed = true;
            }
        }
        else
        {
            _switchWeaponPressed = false;

            if(CurrentWeapon != null && _playerController.Input.GetButton("Attack"))
                CurrentWeapon.Attack();
        }
    }
    #endregion MonoBehaviour Methods

    #region Public Methods
    public void AddWeapon(IWeapon weapon)
    {
        _weapons.Add(weapon);
        SetWeapon(_currentWeapon);
    }

    public void RemoveWeapon(IWeapon weapon)
    {
        _weapons.Remove(weapon);
        SetWeapon(_currentWeapon);
    }
    #endregion Public Methods

    #region Private Methods
    void NextWeapon()
    {
        SetWeapon(_currentWeapon + 1);
    }

    void PreviousWeapon()
    {
        SetWeapon(_currentWeapon - 1);
    }

    void SetWeapon(int index)
    {
        var oldWeapon = CurrentWeapon;
        _currentWeapon = Math.Max(0, Math.Min(_weapons.Count - 1, index));
        var newWeapon = CurrentWeapon;

        if (oldWeapon != newWeapon)
        {
            if (oldWeapon != null)
                oldWeapon.Unequip();
            if (newWeapon != null)
                newWeapon.Equip();
        }
    }
    #endregion Private Methods
}
