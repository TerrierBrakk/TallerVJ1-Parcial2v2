using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_lanzaglobos : MonoBehaviour {

    public Animator animator;

    void OnEnable()
    {
       
        animator.SetBool("Reloading", false);
        animator.SetBool("Shooting", false);


    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
