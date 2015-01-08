using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    bool _dead;
    float _health;

    public float MaxHealth = 1;
    public bool RemoveOnDestroy = true;

    // Use this for initialization
    void Start()
    {
        _health = MaxHealth;
        _dead = MaxHealth <= 0;

        if (_dead && RemoveOnDestroy)
            PlayDestruction(null);
    }

    void AddHealth(float health)
    {
        if (_dead)
            return;

        _health = Math.Min(_health + health, MaxHealth);
    }

    void Hit(MonoBehaviour attacker, float damage)
    {
        if (_dead)
            return;

        _health -= damage;
        if (_health <= 0)
            StartCoroutine(PlayDestruction(attacker));
    }

    IEnumerator PlayDestruction(MonoBehaviour killer)
    {
        _dead = true;

        yield return null;

        if (killer != null)
            killer.SendMessage("Kill", this);

        if (RemoveOnDestroy)
            Destroy(this);
    }
}
