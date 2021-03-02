using UnityEngine;

public class Earth : MonoBehaviour
{
    private static readonly Vector3 satPivot = new Vector3(0, 0, 0);
    private static readonly Vector3 firstSatLoc = new Vector3(6, 0, 0);

    public GameObject satellitePrefab;    
    public float degreesPerPlane = 30f;    
    public float degreesPerSatInPlane = 30f;
    

    // Start is called before the first frame update
    void Start()
    {
        int planes = (int) (360f / degreesPerPlane);
        int satsPerPlane = (int) (360f / degreesPerSatInPlane);

        // Create all needed satellites
        // TODO: This doesn't work right now lol.
        Debug.Log("Creating " + planes + " satellite plane(s) with " + satsPerPlane + " satellite(s) per plane.");

        // Instantiate(satellitePrefab, firstSatLoc, Quaternion.identity);

        for (var i = 0; i <= planes; i++) {
            for (var j = 0; j <= satsPerPlane; j++) {
                var sat = Instantiate(satellitePrefab, firstSatLoc, Quaternion.identity);
                // Rotate once for the in-plane rotation (to complete a plane).
                sat.transform.RotateAround(satPivot, SatelliteData.satRotation, degreesPerSatInPlane * j);
                // Rotate again for number of plane (to complete planes around the planet).
                sat.transform.RotateAround(satPivot, Vector3.up, degreesPerPlane * i);

                Debug.Log("Created " + (j + 1) + "st/nd/th satellite in plane #" + (i + 1) + ".");
            }
        }

        Debug.Log("Finished creating satellites.");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
