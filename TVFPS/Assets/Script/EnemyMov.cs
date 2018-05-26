using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour {

	public Transform objetivo;
	// Use this for initialization
	void Start () {



		
	}
	
	// Update is called once per frame
	void Update () {
		UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		agent.destination = objetivo.position;

	}
}
