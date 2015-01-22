using UnityEngine;
using System.Collections;

public static class Vector3Extension 
{
    public static Vector3 RotateY(this Vector3 vector, float angle)
    {
        float rad = Mathf.Deg2Rad * angle;
        float sin = Mathf.Sin(rad);
        float cos = Mathf.Cos(rad);

        float vx = (cos * vector.x) + (sin * vector.z);
        float vz = (cos * vector.z) - (sin * vector.x);

        return new Vector3(vx, 0.0f, vz);
    }
}
