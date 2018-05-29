using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cricket : MonoBehaviour {


    public Animator animator;
    public float damage;
    public float fireRate = 15f;
    private float nextTimetoFire = 0F;
	private bool isAtacking;
	private int currentAmmo;
	public int maxAmmo = 00;

	public Text UImunicion;
	void Start()
	{
		currentAmmo = maxAmmo;
	}
    void OnEnable()
    {
        isAtacking = false;
        animator.SetBool("Shooting", false);
    }

    // Update is called once per frame
    void Update () {
        animator.SetBool("Shooting", false);
     
        if (Input.GetButton("Fire1") && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1f / fireRate;
            
            StartCoroutine(Shoot());
        }

		UImunicion.text = currentAmmo.ToString ();


    }
    IEnumerator Shoot()
    {
        animator.SetBool("Shooting", true);
        isAtacking = true;
        yield return new WaitForSeconds(.25f);
        isAtacking = false;
        

    }

    void OnCollisionEnter(Collision _other)
    {
     
        Target target = _other.transform.GetComponent<Target>();

        if (target != null && isAtacking == true)
        {
            target.TakeDamage(damage);
            Debug.Log(target.transform.name);
        }
        else
        {
            Debug.Log("que haces alv??...");
        }

    }
}
