using UnityEngine;
using Assets.Code.Libs.Input;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInteraction : MonoBehaviour
{
    #region Private Attributes
    /// <summary>
    /// Currently registered use action.
    /// </summary>
    EventAction _registeredAction;

    /// <summary>
    /// The player controller.
    /// </summary>
    private PlayerMovement _playerController;

    /// <summary>
    /// Action button is currently pressed.
    /// </summary>
    private bool _actionPressed = false;
    #endregion Private Attributes

    #region MonoBehaviour Methods
    /// <summary>
    /// Initializes MonoBehaviour.
    /// </summary>
    void Start()
    {
        _playerController = GetComponent<PlayerMovement>();
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    void Update()
    {
        if (_registeredAction == null)
            return;

        if (_playerController.Input.GetButton("Action"))
        {
            if (!_actionPressed)
            {
                if (_registeredAction.Activate())
                    _playerController.BlockMovement();
                else
                    _playerController.UnblockMovement();

                _actionPressed = true;
            }
        }
        else _actionPressed = false;
    }
    #endregion MonoBehaviour Methods

    #region Methods
    /// <summary>
    /// Sets the current available interaction.
    /// </summary>
    /// <param name="action">Action to be used.</param>
    public void SetAction(EventAction action)
    {
        if (_registeredAction == null)
            _registeredAction = action;
    }

    /// <summary>
    /// Unregister a specified action.
    /// </summary>
    /// <param name="action"></param>
    public void ClearAction(EventAction action)
    {
        if (_registeredAction == action)
            _registeredAction = null;
    }
    #endregion Methods
}
