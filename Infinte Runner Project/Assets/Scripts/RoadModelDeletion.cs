using UnityEngine;

[System.Serializable]
public class BoundaryLimits
{
    public float xMin, xMax, zMin, zMax, y;
}

public class RoadModelDeletion : MonoBehaviour
{
    public BoundaryLimits boundaryLimits;

    private GameObject crystal;

    private void Start()
    {
        crystal = transform.Find("Crystal").gameObject;
        float chance = Random.Range(0, 100);

        if (chance % 11 == 0)
        {
            crystal.transform.position = new Vector3
                                                    (this.gameObject.transform.position.x + Random.Range(boundaryLimits.xMin, boundaryLimits.xMax),
                                                     this.gameObject.transform.position.y + boundaryLimits.y,
                                                     this.gameObject.transform.position.z + Random.Range(boundaryLimits.zMin, boundaryLimits.zMax));
            crystal.SetActive(true);
        }
    }

    private void Update ()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.position.z > this.gameObject.transform.position.z + 4f)
        {
            Destroy(this.gameObject);
        }
    }
}
