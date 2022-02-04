using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour {

	public bool rotate; // do you want it to rotate?

	public float rotationSpeed;

	public AudioClip collectSound;

	public GameObject collectEffect;

	private Level gm;

	public bool checkpoint;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindObjectOfType<Level>();
	}
	
	// Update is called once per frame
	void Update () {

		if (rotate)
			transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Ran through collectible");
		gm.onCollected(other.gameObject);
		Debug.Log("Place1");
		Collect();
	}

	public void Collect()
	{
		Debug.Log("Place2");
	

		if (collectSound)
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
		if(collectEffect)
			Instantiate(collectEffect, transform.position, Quaternion.identity);

		Destroy();
	}

    public void Destroy()
    {
		Destroy(gameObject);
	}
}
