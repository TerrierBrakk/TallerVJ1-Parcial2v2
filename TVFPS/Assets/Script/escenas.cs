using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escenas : MonoBehaviour {

	public void changescenes(string scenename)
	{
		Application.LoadLevel (scenename);
	}
}
