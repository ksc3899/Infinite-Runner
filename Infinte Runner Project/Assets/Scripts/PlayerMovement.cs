using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]public int score = 0;
    public GameObject crystalBlast;

    private float speed = 2f;
    private Rigidbody playerRigidbody;
    private bool forwardDirection = true;
    private Animator animator;
        
	private void Start ()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        InvokeRepeating("SpeedIncrease", 3f, 8f);
	}
	
	private void FixedUpdate ()
    {
        playerRigidbody.MovePosition(transform.position + (transform.forward * speed * Time.deltaTime));
	}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            forwardDirection = !forwardDirection;

            if (forwardDirection == true)
                playerRigidbody.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            else
                playerRigidbody.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }

        if(playerRigidbody.transform.position.y < 0f)
        {
            animator.SetBool("Falling", true);
        }
    }

    private void SpeedIncrease()
    {
        if (speed < 8f)
            speed += 0.4f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Crystal")
        {
            score += 10;

            GameObject crystalEffect = Instantiate(crystalBlast, transform.position, Quaternion.identity);
            Destroy(crystalEffect, 2f);

            Destroy(other.gameObject);
        }
    }
}
