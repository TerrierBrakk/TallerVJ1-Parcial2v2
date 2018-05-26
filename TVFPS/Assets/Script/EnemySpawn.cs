using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public GameObject nangent;
	public GameObject ObjetivObject;
	// Use this for initialization
	void Start () {

		Invoke ("SpawnAgent", 2);
	}

	void SpawnAgent()
	{
		GameObject nav = (GameObject)Instantiate (nangent, this.transform.position, Quaternion.identity);
		nav.GetComponent<EnemyMov> ().objetivo = ObjetivObject.transform;
		Invoke ("SpawnAgent", Random.Range (5, 20));
	}

}
