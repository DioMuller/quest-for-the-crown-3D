using UnityEngine;
using System.Collections;

public class MinimapEntity : MonoBehaviour 
{
	#region Public Attributes
	/// <summary>
	/// Minimap sprite.
	/// </summary>
	public Texture2D MinimapSprite;

	/// <summary>
	/// Sprite Color.
	/// </summary>
	public Color SpriteColor = Color.white;
	#endregion Public Attributes

	#region MonoBehaviour Methods
	/// <summary>
	/// Initializes MonoBehaviour.
	/// </summary>
	void Start () 
	{
		// Create GameObject.
		GameObject minimap = new GameObject();
		minimap.transform.name = "MinimapSprite";
		minimap.layer = LayerMask.NameToLayer("Minimap");

		// Create Sprite.
		var sprite = Sprite.Create(MinimapSprite,
			new Rect(0, 0, MinimapSprite.width, MinimapSprite.height),
			new Vector2(0.5f, 0.5f), MinimapSprite.height);

		// Create SpriteRenderer Component.
		minimap.AddComponent<SpriteRenderer>();
		var component = minimap.GetComponent<SpriteRenderer>();

		component.sprite = sprite;
		component.color = SpriteColor;

		// Add Children to this Object.
		minimap.transform.parent = this.transform;

		// Transform Position
		minimap.transform.localPosition = Vector3.zero;
		minimap.transform.localRotation = Quaternion.Euler(90, 0, 0);
	}
	#endregion MonoBehaviour Methods
}
