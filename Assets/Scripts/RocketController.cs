using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
Rigidbody rb;
AudioSource audioSource;
public AudioClip thrustAudio;
public float thrust;
public float rotationSpeed;
public ParticleSystem engineThrust;
public Collider bounds;



	// this script handles the player's input for controlling the rocket
// Start is called before the first frame update
void Start()
{
	rb = GetComponent<Rigidbody>();
	audioSource = GetComponent<AudioSource>();
}

// Update is called once per frame
void Update()
{
	//whenever input is processed, play rocket thrust sound
	ProcessInput();
	CheckBounds();
}

private void ProcessInput()

{
	if (Input.GetKey(KeyCode.Space))
	{
		rb.AddRelativeForce(Vector3.up * thrust);
		engineThrust.Play();
		if (!audioSource.isPlaying)
		{

			audioSource.PlayOneShot(thrustAudio);
		}
	}

	if (Input.GetKey(KeyCode.A))
	{
		transform.Rotate(-transform.right * rotationSpeed);
	}

	if (Input.GetKey(KeyCode.D))
	{
		transform.Rotate(transform.right * rotationSpeed);
	}
}


 private void CheckBounds()
    {
        if (bounds != null)
        {
            if (!bounds.bounds.Contains(transform.position))
            {
                Vector3 clampedPosition = transform.position;
                clampedPosition.x = Mathf.Clamp(clampedPosition.x, bounds.bounds.min.x, bounds.bounds.max.x);
                clampedPosition.y = Mathf.Clamp(clampedPosition.y, bounds.bounds.min.y, bounds.bounds.max.y);
                clampedPosition.z = Mathf.Clamp(clampedPosition.z, bounds.bounds.min.z, bounds.bounds.max.z);

                transform.position = clampedPosition;
            }
        }
    }


}