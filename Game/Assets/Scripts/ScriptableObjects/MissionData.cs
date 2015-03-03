using UnityEngine;
using System.Collections;

public class MissionData : ScriptableObject
{
    // Level Info
    public string Title;
    public string Description;
    public Texture2D Image;
    public int MoneyPrize;

    // Level Data
    public string Scene;
}