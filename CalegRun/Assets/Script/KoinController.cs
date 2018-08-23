using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoinController : MonoBehaviour {

	public GameObject Particles;
	public InfoController TheInfos;
	public ScoreController TheScore;

	// Use this for initialization
	void Start () {
		TheInfos = FindObjectOfType<InfoController> ();
		TheScore = FindObjectOfType<ScoreController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Instantiate (Particles, transform.position, transform.rotation);
			TheInfos.ShowInfo ();
			TheScore.MyScore += 10;
			Destroy (gameObject);
		}
	}
}
