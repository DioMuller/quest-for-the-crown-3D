using System;
using System.Collections;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    #region Private Attributes
    private Rigidbody _rigidbody;
    #endregion Private Attributes

    #region Public Attributes
    public bool RemoveOnDestroy = true;

	public Animator Animator = null;
	public float AnimationTime = 1.0f;

    public CharacterData Data;
	#endregion Public Attributes

	#region Properties
	public int CurrentHealth { get; private set; }
	public int CurrentMagic { get; private set; }
	public bool IsDead { get; private set; }
    public bool IsInvulnerable { get; private set; }
	#endregion Properties

	#region MonoBehaviour Methods
    // Use this for initialization
    void Start()
    {
		CurrentHealth = Data.MaxHealth;
        CurrentMagic = Data.MaxMagic;

        IsInvulnerable = false;

        _rigidbody = GetComponent<Rigidbody>();

        IsDead = Data.MaxHealth <= 0;

        if (Data.MagicRegenTime > 0.0f)
        {
            InvokeRepeating("MagicRegen", Data.MagicRegenTime, Data.MagicRegenTime);
        }

		if (IsDead)
            StartCoroutine(PlayDestruction(null));
    }
	#endregion MonoBehaviour Methods

	#region Status Methods
    public void AddHealth(int health)
    {
		if (IsDead)
            return;

        CurrentHealth = Math.Min(CurrentHealth + health, Data.MaxHealth);
    }

	public void RemoveHealth(int amount, Transform attacker)
    {
        if (IsInvulnerable) return;

        if (attacker == transform) return;
		if (IsDead)
            return;

		CurrentHealth -= amount;

        // TODO: Correct Knockback.
        if (_rigidbody != null)
        {
            var knockbackDirection = (transform.position - attacker.position);
            knockbackDirection.y = 0;
            knockbackDirection.Normalize();
            _rigidbody.MovePosition(transform.position + knockbackDirection);
        }


        if (CurrentHealth <= 0)
        {
            StartCoroutine(PlayDestruction(attacker));
        }

        if (Data.InvulnerabilityTime > 0.0)
        {
            StartCoroutine(SetInvulnerable());
        }
    }

	public bool UseMagic(int amount)
	{
		if( CurrentMagic < amount ) return false;

		CurrentMagic = CurrentMagic - amount;
		return true;
	}

	public void RestoreMagic(int amount)
	{
        CurrentMagic = Math.Min(CurrentMagic + amount, Data.MaxMagic);
	}

    public void MagicRegen()
    {
        RestoreMagic(Data.MagicRegenQuantity);
    }
	#endregion Status Methods

	#region Event Methods
	IEnumerator PlayDestruction(Transform killer)
    {
		IsDead = true;

        // Animation?
		if (Animator != null)
		{
			Animator.SetBool("IsDead", true);
			yield return new WaitForSeconds(AnimationTime);
		}
		else
		{
			yield return null;
		}

		if (RemoveOnDestroy)
            Destroy(gameObject);
    }

    IEnumerator SetInvulnerable()
    {
        IsInvulnerable = true;
        InvokeRepeating("Blink", 0.1f, 0.3f);

        yield return new WaitForSeconds(Data.InvulnerabilityTime);

        CancelInvoke("Blink");
        IsInvulnerable = false;
    }

    void Blink()
    {
        // TODO: Blink or Hit effect.
    }
	#endregion Event Methods
}
