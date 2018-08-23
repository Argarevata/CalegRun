using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstcaleController : MonoBehaviour {

	public int MinusHealth;
	public PlayerController ThePlayer;
	public GameObject particles;

	// Use this for initialization
	void Start () {
		ThePlayer = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		print ("hello");
	}
		
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			print ("Health -30%");	
			ThePlayer.Health -= MinusHealth;
			Instantiate (particles, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
