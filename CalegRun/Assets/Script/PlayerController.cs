using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D MyBody;
	public float Speed;
	public float NormalSpeed = 6;
	public float JumpForce;

	[SerializeField]
	private bool Grounded = true;
	[SerializeField]
	private float SlideCoolDown = 0.3f;
	[SerializeField]
	private float ActualSlideCoolDown=0.3f;

	public Animator Anim;
	public Slider HealthBar;
	public int Health;

	// Use this for initialization
	void Start () {
		MyBody = GetComponent<Rigidbody2D> ();
		Grounded = true;
		Anim = GetComponentInChildren<Animator> ();
		Health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		MyBody.velocity = new Vector2 (Speed, MyBody.velocity.y);
		ActualSlideCoolDown += Time.deltaTime;
		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && Grounded == true) {
			Jump ();
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) && ActualSlideCoolDown>=SlideCoolDown && Grounded == true) {
			Slide ();
		}
		if (ActualSlideCoolDown >= SlideCoolDown) {
			Anim.SetBool ("Slide", false);
			Speed = NormalSpeed;
		}
		HealthBar.value = Health;
	}

	public void Jump()
	{
		MyBody.velocity = new Vector2 (Speed, JumpForce);
		Anim.SetBool ("Jump", true);
		Anim.SetBool ("Slide", false);
		Grounded = false;
	}

	public void Slide()
	{
		Speed += 4;
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
