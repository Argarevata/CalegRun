using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public int MyScore;
	public Text MyText;

	[SerializeField]
	private float CoolDown = 1f;
	[SerializeField]
	private float ActualCoolDown=1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MyText.text = "Score: " + MyScore;
		ActualCoolDown += Time.deltaTime;
		if (ActualCoolDown >= CoolDown) {
			MyScore += 1;
			ActualCoolDown = 0;
		}
	}
}
