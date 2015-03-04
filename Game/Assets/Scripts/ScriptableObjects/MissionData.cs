using UnityEngine;
using System.Collections;

public class MissionData : ScriptableObject
{
    // Level Info
    public int MissionId;
    public string Title;
    public string Description;
    public Texture2D Image;
    public int MoneyPrize;

    //Requiriments
    public int[] PrerequisiteMissions;

    // Level Data
    public string Scene;
}