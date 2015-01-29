using UnityEngine;

public class WeaponData : ScriptableObject
{
    /// <summary>
    /// Weapon Attack Power.
    /// </summary>
	public int AttackPower = 1;

    /// <summary>
    /// Weapon Magic cost.
    /// </summary>
	public int MagicConsumption = 0;

    /// <summary>
    /// Weapon lifetime. 0 for eternal.
    /// </summary>
    public float LifeTime = 1.0f;

    /// <summary>
    /// Weapon Animation Time.
    /// </summary>
    public float AnimationTime = 1.0f;

    /// <summary>
    /// Will the weapon be destroyed on contact?
    /// </summary>
	public bool DestroyOnContact = false;

    /// <summary>
    /// Does the weapon/hitbox move with the player?
    /// </summary>
    public bool MoveWithPlayer = false;

    /// <summary>
    /// Weapon Icon.
    /// </summary>
    public Texture2D Icon = null;
}
