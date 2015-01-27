using System;
using System.Collections;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
	#region Public Attributes
    public bool RemoveOnDestroy = true;

    public CharacterData Data;
	#endregion Public Attributes

	#region Properties
	public int CurrentHealth { get; private set; }
	public int CurrentMagic { get; private set; }
	public bool IsDead { get; private set; }
	#endregion Properties

	#region MonoBehaviour Methods
    // Use this for initialization
    void Start()
    {
		CurrentHealth = Data.MaxHealth;
        CurrentMagic = Data.MaxMagic;

        IsDead = Data.MaxHealth <= 0;

        if (Data.MagicRegenTime > 0.0f)
        {
            InvokeRepeating("MagicRegen", Data.MagicRegenTime, Data.MagicRegenTime);
        }

		if (IsDead && RemoveOnDestroy)
            PlayDestruction(null);
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
        if (attacker == transform) return;
		if (IsDead)
            return;

		CurrentHealth -= amount;
		
		if (CurrentHealth <= 0)
            StartCoroutine(PlayDestruction(attacker));
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

        yield return null;

        if (RemoveOnDestroy)
            Destroy(gameObject);
    }
	#endregion Event Methods
}
