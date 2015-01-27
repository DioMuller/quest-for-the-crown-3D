using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
    #region Private Attributes
    /// <summary>
    /// Parent transform.
    /// </summary>
    private Transform _parent = null;
    #endregion Private Attributes

    #region Public Attributes
    /// <summary>
    /// Weapon Hitbox.
    /// </summary>
    public Transform Hitbox;

    /// <summary>
    /// Weapon data/status.
    /// </summary>
    public WeaponData Data;
    #endregion Public Attributes

    #region Properties
    /// <summary>
    /// Weapon parent.
    /// </summary>
    public Transform Parent
	{
		get { return _parent; }
		set
		{
			_parent = value;
			if( _parent != null )
			{
                ParentStatus = _parent.GetComponent<CharacterStatus>();
			}
		}
	}

    /// <summary>
    /// Parent status.
    /// </summary>
	public CharacterStatus ParentStatus { get; private set; }
    #endregion Properties

    #region MonoBehaviour Methods
    /// <summary>
    /// Called on initialization.
    /// </summary>
    void Awake()
    {
        var parentTrans = this.transform;

        while (ParentStatus == null && parentTrans != null)
        {
            Parent = parentTrans.parent;
            parentTrans = Parent;
        }
    }
    #endregion MonoBehaviour Methods

    #region Methods
    /// <summary>
    /// Uses MP and Attack.
    /// </summary>
	public void Attack()
	{
		if(ParentStatus && CanAttack() && ParentStatus.UseMagic(Data.MagicConsumption))
		{
            var obj = (Transform)Instantiate(Hitbox);
            
            if (Data.MoveWithPlayer)
                obj.parent = this.transform;
            else
                obj.parent = Parent.parent;

            var hitbox = obj.GetComponent<WeaponHitbox>();
            hitbox.ParentWeapon = this;
            hitbox.DestroyTime = Data.LifeTime;

            obj.position = transform.position;
            obj.rotation = Parent.rotation;

            OnAttack(hitbox);
		}
        else
        {
            OnAttackFail();
        }
	}
    #endregion Methods

    #region Abstract Methods
    /// <summary>
    /// Called when the attack button is pressed.
    /// </summary>
    public abstract void OnAttack(WeaponHitbox hitbox);

    /// <summary>
    /// Called when the weapon cannot be used.
    /// </summary>
    public abstract void OnAttackFail();

    /// <summary>
    /// Called when the weapon is equiped.
    /// </summary>
	public abstract void OnEquip();

    /// <summary>
    /// Called when the weapon is unequiped.
    /// </summary>
	public abstract void OnUnequip();

    /// <summary>
    /// Checks if the weapon can currently attack.
    /// </summary>
    /// <returns>Can the weapon attack?</returns>
    public abstract bool CanAttack();

    /// <summary>
    /// Called when the weapon hitbox is destroyed.
    /// </summary>
    public abstract void OnHitboxDestroyed();
    #endregion Abstract Methods
}
