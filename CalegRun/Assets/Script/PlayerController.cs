using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D MyBody;
	public float Speed;
	public float JumpForce;

	[SerializeField]
	private bool Grounded = true;
	[SerializeField]
	private float SlideCoolDown = 0.3f;
	[SerializeField]
	private float ActualSlideCoolDown=0.3f;

	public Animator Anim;

	// Use this for initialization
	void Start () {
		MyBody = GetComponent<Rigidbody2D> ();
		Grounded = true;
		Anim = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		MyBody.velocity = new Vector2 (Speed, MyBody.velocity.y);
		ActualSlideCoolDown += Time.deltaTime;
		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && Grounded == true) {
			Jump ();
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) && ActualSlideCoolDown>=SlideCoolDown) {
			Slide ();
		}
		if (ActualSlideCoolDown >= SlideCoolDown) {
			Anim.SetBool ("Slide", false);
		}
	}

	private void Jump()
	{
		MyBody.velocity = new Vector2 (Speed, JumpForce);
		Anim.SetBool ("Jump", true);
		Anim.SetBool ("Slide", false);
		Grounded = false;
	}

	private void Slide()
	{
		Anim.SetBool ("Slide", true);
		ActualSlideCoolDown = 0f;
	}

	public void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Ground")
		Grounded = true;
		Anim.SetBool ("Jump", false);
	}
}
