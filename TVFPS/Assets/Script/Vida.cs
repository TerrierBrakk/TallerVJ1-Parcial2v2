using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour {
	private int saludJ=1000;

	public Text UIsaludJ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		UIsaludJ.text = saludJ.ToString ();
	}
}
