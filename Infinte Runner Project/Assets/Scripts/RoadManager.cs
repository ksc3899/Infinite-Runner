using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject roadModel;
    public Vector3 lastPosition;
    public float offset = 1f;
    public float easyTime = 15f;
    public float mediumTime = 25f;
 
    private void Start ()
    {
        InvokeRepeating("RoadCreator", 2f, 0.25f);
	}

    private void RoadCreator()
    {
        Vector3 spawnPosition = Vector3.zero;

        float random = Random.Range(0, 100);
        if (Time.time < easyTime)
        {
            if (random < 80)
                spawnPosition = new Vector3(lastPosition.x, lastPosition.y, lastPosition.z + offset);
            else
                spawnPosition = new Vector3(lastPosition.x - offset, lastPosition.y, lastPosition.z);
        }
        else if (Time.time > easyTime && Time.time < mediumTime)
        {
            if (random < 70)
                spawnPosition = new Vector3(lastPosition.x, lastPosition.y, lastPosition.z + offset);
            else
                spawnPosition = new Vector3(lastPosition.x - offset, lastPosition.y, lastPosition.z);
        }
        else
        {
            if (random < 50)
                spawnPosition = new Vector3(lastPosition.x, lastPosition.y, lastPosition.z + offset);
            else
                spawnPosition = new Vector3(lastPosition.x - offset, lastPosition.y, lastPosition.z);
        }
        GameObject road = Instantiate(roadModel, spawnPosition, Quaternion.identity);
        lastPosition = road.transform.position;
    }
}
