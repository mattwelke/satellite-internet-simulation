using UnityEngine;

public class OrbitalPlaneCreator : MonoBehaviour
{
    public GameObject orbitalPlanePrefab;
    public int numOrbitalPlanes;
    public int inclinationDegrees;

    // Start is called before the first frame update
    void Start()
    {
        int planesCreated = 0;
        int degreesPerOrbitalPlane = (int)(360 / numOrbitalPlanes);
        for (int i = 0; i <= 360; i += degreesPerOrbitalPlane)
        {
            CreateOrbitalPlane(i, inclinationDegrees);
            planesCreated += 1;
            // if (planesCreated == 2)
            // {
            //     break;
            // }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateOrbitalPlane(int degreesAroundPlanet, int inclinationDegrees)
    {
        var plane = Instantiate(orbitalPlanePrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        Debug.Log($"Orbital plane's rotation after creation  = {plane.transform.rotation}");

        // Rotate the entire plane around the planet such that the first satellite is on a longitude equal to
        // degreesAroundPlanet.
        plane.transform.Rotate(Vector3.up, degreesAroundPlanet, Space.Self);
        Debug.Log($"Orbital plane's rotation after rotate around planet is = {plane.transform.rotation}");

        plane.GetComponent<SatelliteCreator>().CreateSatellites();

        // Rotate again around a horizontal axis such that the orbital plane inclination is achieved.
        plane.transform.Rotate(Vector3.forward, inclinationDegrees);
        Debug.Log($"Orbital plane's rotation after rotate for incline = {plane.transform.rotation}");
    }
}
