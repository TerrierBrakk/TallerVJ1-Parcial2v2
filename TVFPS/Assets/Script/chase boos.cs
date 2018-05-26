using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseboos : MonoBehaviour {

	public Transform player;
	static Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (player.position, this.transform.position) < 50) {
			Vector3 direction = player.position - this.transform.position;
			direction.y = 0;
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);


			anim.SetBool ("isIddle", false);
			if (direction.magnitude > 1	) {

				this.transform.Translate (0, 0, 0.9f);
				anim.SetBool ("isWalking", true);
				anim.SetBool ("isAttacking", false);
			} else {
				anim.SetBool ("isAttacking", true);
				anim.SetBool ("isWalking", false);
			}
		}
		else
		{
			anim.SetBool("isIddle",true);
			anim.SetBool("isWalking",false);
			anim.SetBool("isAttacking",false);

		}
	}
}
