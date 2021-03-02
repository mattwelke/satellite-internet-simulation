using UnityEngine;

public class Satellite : MonoBehaviour
{
    private static readonly Vector3 pivot = new Vector3(0, 0, 0);
    public bool move;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Beginning Satellite motion.");
    }

    // Update is called once per frame
    void Update()
    {
        // var dir = gameObject.transform.position - pivot;
        // dir = Quaternion.Euler(0f, 0.1f, 0f) * dir;
        // Vector3 newPoint = dir + pivot;

        // gameObject.transform.position = newPoint;

        if (move)
        {
            gameObject.transform.RotateAround(pivot, SatelliteData.satRotation, 10 * Time.deltaTime);
        }
    }
}
