using UnityEngine;
using System.Collections;

public class MinimapEntity : MonoBehaviour
{
	private GameObject _minimap;

	#region Public Attributes
	/// <summary>
	/// Minimap sprite.
	/// </summary>
	public Texture2D MinimapSprite;

	/// <summary>
	/// Sprite Color.
	/// </summary>
	public Color SpriteColor = Color.white;

    /// <summary>
    /// Sprite Size
    /// </summary>
	public float Size = 1.0f;

	/// <summary>
	/// The zoom.
	/// </summary>
	public static float Zoom = 1.0f;
	#endregion Public Attributes

	#region MonoBehaviour Methods
	/// <summary>
	/// Initializes MonoBehaviour.
	/// </summary>
	void Start () 
	{
		// Create GameObject.
		_minimap = new GameObject();
		_minimap.transform.name = "MinimapSprite";
		_minimap.layer = LayerMask.NameToLayer("Minimap");

		// Create Sprite.
		var sprite = Sprite.Create(MinimapSprite,
			new Rect(0, 0, MinimapSprite.width, MinimapSprite.height),
			new Vector2(0.5f, 0.5f), MinimapSprite.height / (Size * Zoom) );

		// Create SpriteRenderer Component.
		var component = _minimap.AddComponent<SpriteRenderer>();

		component.sprite = sprite;
		component.color = SpriteColor;

		// Add Children to this Object.
		_minimap.transform.parent = this.transform;

		// Transform Position
		_minimap.transform.localPosition = new Vector3(0.0f, 1.0f, 0.0f);
		_minimap.transform.localScale = Vector3.one;
		_minimap.transform.localRotation = Quaternion.Euler(90, 0, 0);
	}

	/// <summary>
	/// Called once per frame.
	/// </summary>
	private void Update()
	{
		//Debug.Log(1.0f / Time.deltaTime);
	}

	public void SetVisible(bool visible)
	{
		_minimap.SetActive(visible);
	}

	#endregion MonoBehaviour Methods
}
