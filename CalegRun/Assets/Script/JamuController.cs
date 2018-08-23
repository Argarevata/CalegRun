using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamuController : MonoBehaviour {

	public PlayerController ThePlayer;
	public int PlusHealth;
	public GameObject Particles;

	// Use this for initialization
	void Start () {
		ThePlayer = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			ThePlayer.Health += PlusHealth;
			transform.rotation = Quaternion.Euler(-90,0,0);
			Instantiate (Particles, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
