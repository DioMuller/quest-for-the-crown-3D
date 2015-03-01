using System;
using System.Collections;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    #region Private Attributes
    private Rigidbody _rigidbody;
	private Renderer[] _renderers;
	private bool _visible = true;

    private int _currentHealth;
    private int _currentMagic;
    #endregion Private Attributes

    #region Public Attributes
    public bool RemoveOnDestroy = true;

	public Animator Animator = null;
	public float AnimationTime = 1.0f;

    public CharacterData Data;
    #endregion Public Attributes

    #region Properties
    public int CurrentHealth
    {
        get { return _currentHealth; }
        private set { _currentHealth = value; }
    }
	public int CurrentMagic
    {
        get { return _currentMagic; }
        private set { _currentMagic = value; }
    }
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
		_renderers = GetComponentsInChildren<Renderer>();

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
    public int AddHealth(int quantity)
    {
        return Add(ref _currentHealth, quantity, Data.MaxHealth);
    }

    public int RestoreMagic(int amount)
    {
        return Add(ref _currentMagic, amount, Data.MaxMagic);
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
        if (CurrentMagic < amount) return false;

        CurrentMagic = CurrentMagic - amount;
        return true;
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

        BroadcastMessage("OnDeath");
    }

    IEnumerator SetInvulnerable()
    {
        IsInvulnerable = true;
        InvokeRepeating("Blink", 0.0f, 0.1f);

        yield return new WaitForSeconds(Data.InvulnerabilityTime);

        CancelInvoke("Blink");
	    SetVisibility(true);
		IsInvulnerable = false;
    }

    void Blink()
    {
	    SetVisibility(!_visible);
    }

	void SetVisibility(bool visibility)
	{
		_visible = visibility;

		foreach (var childRenderer in _renderers)
		{
			childRenderer.enabled = visibility;
		}
	}
    #endregion Event Methods

    #region Private Methods
    private int Add(ref int storage, int quantity, int max)
    {
        if (IsDead || storage >= max)
            return 0;

        int toUse = Math.Min(quantity, max - storage);
        storage += toUse;
        return toUse;
    }
    #endregion Private Methods
}
