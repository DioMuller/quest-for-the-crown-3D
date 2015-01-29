using UnityEngine;
using System.Collections;

public class PostprocessingEffect : MonoBehaviour  
{
    public Material Material;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, Material);
    }
}
