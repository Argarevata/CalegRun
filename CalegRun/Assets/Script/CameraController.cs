using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Rigidbody2D Player;
	public Rigidbody2D MyBody;

	// Use this for initialization
	void Start () {
		MyBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		MyBody.velocity = new Vector2 (Player.velocity.x, 0);
	}
}
