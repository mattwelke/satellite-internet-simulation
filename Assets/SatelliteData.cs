using UnityEngine;

public class SatelliteData
{
    private static readonly float inclinationDegrees = 30f;
    
    public static readonly Vector3 satRotation = new Vector3(
        Mathf.Cos(inclinationDegrees), Mathf.Sin(inclinationDegrees), 0);
}
