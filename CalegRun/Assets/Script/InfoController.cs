using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoController : MonoBehaviour {

	public GameObject[] Info;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowInfo()
	{
		int RandomNum = Random.Range (0, 11);

		for (int i = 0; i < Info.Length; i++) {
			Info [i].SetActive (false);
		}
		Info [RandomNum].SetActive (true);
	}
}
