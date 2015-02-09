using UnityEngine;
using System.Collections;

public class CharacterData : ScriptableObject
{
    #region Public Attributes
    /// <summary>
    /// Character Max Health.
    /// </summary>
    public int MaxHealth = 1;

    /// <summary>
    /// Character Max Magic.
    /// </summary>
    public int MaxMagic = 1;

    /// <summary>
    /// Character Health Regen Time.
    /// </summary>
    public float MagicRegenTime = 1.0f;

    /// <summary>
    /// Character Magic Regen Quantity.
    /// </summary>
    public int MagicRegenQuantity = 1;

    /// <summary>
    /// Invulnerability time after hit.
    /// </summary>
    public float InvulnerabilityTime = 0.5f;
    #endregion Public Attributes
}
