using UnityEngine;

// Creates satellites in an orbital plane. Also, controls the orbital plane's rotation.
public class SatelliteCreator : MonoBehaviour
{
    public GameObject satellitePrefab;

    // private Vector3 edgePosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void CreateSatellites()
    {
        int numSats = 36;
        var anglePerSat = 360 / numSats;

        int numSatsCreated = 0;

        for (int i = 0; i <= 360; i += anglePerSat)
        {
            // Make a satellite with fixed radius
            // TODO: Not sure why this is needed
            var radius = 6f / 100;

            var x = radius * Mathf.Sin(Mathf.PI * 2 * i / 360);
            var z = radius * Mathf.Cos(Mathf.PI * 2 * i / 360);
            var sat = Instantiate(satellitePrefab, new Vector3(x, 0, z), Quaternion.identity);

            // TODO: Not sure why "worldPositionStays" arg needs to be false here.
            sat.transform.SetParent(gameObject.transform, false);

            sat.GetComponent<Satellite>().move = false;

            // Fix scale
            // TODO: Not sure why this is needed
            sat.transform.localScale /= 100;

            numSatsCreated += 1;

            // if (numSatsCreated == 1)
            // {
            //     break;
            // }

            // edgePosition = new Vector3(
            //     sat.transform.position.x,
            //     sat.transform.position.y,
            //     sat.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // var inward = edgePosition - gameObject.transform.position;
        gameObject.transform.Rotate(Vector3.up, -10 * Time.deltaTime);
    }
}
