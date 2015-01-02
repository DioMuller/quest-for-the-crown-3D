using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	#region Public Attributes
	/// <summary>
	/// Minimap sprite.
	/// </summary>
	public Texture2D MinimapSprite;

	/// <summary>
	/// Entity Mesh.
	/// </summary>
	public GameObject Object;
	#endregion Public Attributes

	#region MonoBehaviour Methods
	/// <summary>
	/// Initializes MonoBehaviour.
	/// </summary>
	void Start () 
	{
		// Add Children Object
		var obj = (GameObject) Instantiate(Object);
		

		// Add Minimap Dot
		var sprite = Sprite.Create(MinimapSprite,
			new Rect(0, 0, MinimapSprite.width, MinimapSprite.height),
			new Vector2(MinimapSprite.width / 2.0f, MinimapSprite.height / 2.0f)
		);

		

	}

	/// <summary>
	/// Called once per frame.
	/// </summary>
	void Update () 
	{

	}
	#endregion MonoBehaviour Methods
}
