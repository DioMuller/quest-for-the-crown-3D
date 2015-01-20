using System;
using System.Collections;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
	#region Public Attributes
    public bool RemoveOnDestroy = true;

	public int MaxHealth = 1;
	public int MaxMagic = 1;
    public float MagicRegenTime = 1.0f;
    public int MagicRegenQuantity = 1;
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
		CurrentHealth = MaxHealth;
		CurrentMagic = MaxMagic;

		IsDead = MaxHealth <= 0;

        if( MagicRegenTime > 0.0f)
        {
            InvokeRepeating("MagicRegen", MagicRegenTime, MagicRegenTime);
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

		CurrentHealth = Math.Min(CurrentHealth + health, MaxHealth);
    }

	public void RemoveHealth(int amount, Transform attacker)
    {
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
		CurrentMagic = Math.Min(CurrentMagic + amount, MaxMagic);
	}

    public void MagicRegen()
    {
        RestoreMagic(MagicRegenQuantity);
    }
	#endregion Status Methods

	#region Event Methods
	IEnumerator PlayDestruction(Transform killer)
    {
		IsDead = true;

        yield return null;

        //if (killer != null)
        //{
        //    try
        //    {
        //        killer.SendMessage("Kill", this);
        //    }
        //    catch(Exception ex)
        //    {
        //        Debug.Log("Kill message had no receiver. (" + ex.Message + ")");
        //    }
        //}

        if (RemoveOnDestroy)
            Destroy(gameObject);
    }
	#endregion Event Methods
}
