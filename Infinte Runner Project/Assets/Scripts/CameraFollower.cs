using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float smoothing;

    private Transform player;
    private Vector3 offset;

	private void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        offset = this.transform.position - player.position;
	}
	
	private void LateUpdate ()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, player.position + offset, smoothing * Time.deltaTime);
	}
}
