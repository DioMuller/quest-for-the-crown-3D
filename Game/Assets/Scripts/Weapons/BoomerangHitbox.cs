using UnityEngine;
using System.Collections;
using System;

public class BoomerangHitbox : WeaponHitbox 
{
    public const float FlightDuration = 0.5f;
    public const float ExtendFlightDuration = 0.5f;

    Rigidbody _rigidbody;
    /// <summary>
    /// Player camera info.
    /// </summary>
    CameraTrack _cameraTrack;
    PlayerMovement _playerController;
    bool _canControl;
    float _flightDuration;

    public Vector3 Direction = new Vector3(0, 0, -1);
    public float Speed = 200.0f;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        var target = _playerController.Input.GetTarget(_cameraTrack, gameObject);
        if (_canControl && target.magnitude > 0.5)
        {
            if (_flightDuration < 0)
            {
                if (!ParentWeapon.ParentStatus.UseMagic(ParentWeapon.Data.MagicConsumption))
                {
                    _canControl = false;
                    return;
                }
                _flightDuration = ExtendFlightDuration;
            }

            Direction = target;
            Direction.Normalize();
        }
        else if (_flightDuration < 0)
        {
            Direction = ParentWeapon.Parent.transform.position - transform.position;
            Direction.Normalize();
            Direction.y = 0;
            return;
        }

        _flightDuration -= Time.deltaTime;
    }

    public void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + (Direction * Time.fixedDeltaTime * Speed));
    }

    new void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ParentWeapon.Parent.gameObject)
            ((Boomerang)ParentWeapon).OnReturn();
        else
            base.OnTriggerEnter(other);

        ((Boomerang)ParentWeapon).OnHit(other);
    }

    public void Return()
    {
        _canControl = false;
    }

    public void StartFlight(CameraTrack cameraTrack, PlayerMovement playerController)
    {
        _cameraTrack = cameraTrack;
        _playerController = playerController;

        _canControl = true;
        _flightDuration = FlightDuration;
        Direction = Direction.RotateY(transform.localRotation.eulerAngles.y);
    }
}
