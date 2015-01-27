﻿using UnityEngine;
using System.Collections;

public class BoomerangHitbox : WeaponHitbox 
{
    private Rigidbody _rigidbody;

    public Vector3 Direction = new Vector3(0, 0, -1);
    public float Speed = 200.0f;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
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
}
