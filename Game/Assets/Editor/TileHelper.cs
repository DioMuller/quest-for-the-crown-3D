using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Rotorz.Tile;
using UnityEditor;
using UnityEngine;

public class TileHelper
{
	private static List<Material> Materials;
	
	[MenuItem("Aditional Tools/Create Tile Materials &#m")]
	static void MenuCreateMaterials()
	{
		var selectedTextures = Selection.GetFiltered(typeof(Texture2D), SelectionMode.Assets);
		Materials = new List<Material>();

		foreach (var tex in selectedTextures)
		{
			var name = tex.name;
			var localPath = "Assets/Materials/Tiles/" + name + ".mat";

			Materials.Add(CreateMaterial(tex as Texture2D, localPath));
		}

		AssetDatabase.Refresh();
	}

	[MenuItem("Aditional Tools/Create Tile Prefab &#t")]
	static void MenuCreatePrefab()
	{
		var selectedObjects = Selection.gameObjects;

		/*
		var materials = AssetDatabase.LoadAllAssetRepresentationsAtPath("Assets/Materials/Tiles");
		Debug.Log(materials.Length);
		*/

		foreach (var obj in selectedObjects)
		{
			var name = obj.name;

			foreach (var material in Materials)
			{
				var localPath = "Assets/Prefabs/Tiles/" + name + " - " + material.name + ".prefab";
				CreatePrefab(obj, material, localPath);
			}
			
		}

		AssetDatabase.Refresh();
	}

	#region Methods
	private static Material CreateMaterial(Texture2D obj, string path)
	{
		if (obj == null) return null;

		// Create empty prefab and replace with existing object.
		AssetDatabase.CreateAsset(new Material(Shader.Find("Diffuse")), path);
		Material material = AssetDatabase.LoadAssetAtPath(path, typeof(Material)) as Material;
		material.mainTexture = obj;

		return material;
	}

	static void CreatePrefab(GameObject obj, Material mat, string path)
	{
		if (obj == null) return;

		var prefab = PrefabUtility.CreateEmptyPrefab(path);

		obj.renderer.material = mat;

		PrefabUtility.ReplacePrefab(obj, prefab);
	}
	#endregion Methods
}
