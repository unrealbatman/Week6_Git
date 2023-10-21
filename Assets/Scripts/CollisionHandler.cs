using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

	//this script handles collisions.
	public AudioClip crashAudio;
	public AudioClip successAudio;
	public ParticleSystem crash;
	public ParticleSystem success;
	public List<ParticleCollisionEvent> collisionEvents;
	private IEnumerator coroutine;
	private AudioSource audioSource;
	private int cycles = 20;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		collisionEvents = new List<ParticleCollisionEvent>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		switch (collision.gameObject.tag)
		{
			case "Obstacle":
				crash.Play();
				audioSource.PlayOneShot(crashAudio);
				coroutine = RotateOutOfBounds(4f);
				StartCoroutine(coroutine);
				Invoke("respawn", 2f);
				break;
			case "Finish":
				success.Play();
				audioSource.clip = successAudio;
				audioSource.PlayOneShot(successAudio);
				Invoke("loadNextLevel", 2f);
				break;
			case "Friendly":
				//do nothing
				break;

		}
	}

	private void loadNextLevel()
	{

		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		int nextSceneIndex = currentSceneIndex + 1;
		if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
		{
			nextSceneIndex = 0;
		}
		SceneManager.LoadScene(nextSceneIndex);
	}
	IEnumerator RotateOutOfBounds(float duration)
	{
		//on collision with an obstacle this method rotates the object in a way that mimicks it getting hit.
		float startRotation = transform.eulerAngles.x;
		float endRotation = startRotation + 360.0f;
		float t = 0.0f;
		while (t < duration)
		{
			t += Time.deltaTime;
			float xRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
			transform.eulerAngles = new Vector3(xRotation * cycles, transform.eulerAngles.y, transform.eulerAngles.z);
			yield return null;
		}
	}
	private void respawn()
	{

		// if the player dies, respawn to the start of the timeloop i.e. that first level
		SceneManager.LoadScene(3);
	}

	void OnParticleCollision(GameObject other)
	{
		//handles collision of lasers emitted by the boss in the final level.
		crash.Play();
		audioSource.PlayOneShot(crashAudio);
		coroutine = RotateOutOfBounds(4f);
		StartCoroutine(coroutine);

		Invoke("respawn", 2f);

	}

}

