using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public ParticleSystem particles;
    public GameObject ImpactEffect;
    public float ImpactForce = 200f;
    private float nextTimetoFire = 0F;

	public Text UImunicion;
	public Text balastotal;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;

    private bool IsReloading = false;


    public Camera fpsCam;

    public Animator animator;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        IsReloading = false;
        animator.SetBool("Reloading", false);
        animator.SetBool("Shooting", false);


    }

    // Update is called once per frame
    void Update () {
        animator.SetBool("Shooting", false);

        if (IsReloading)
        {
            return;
        }
        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.R) && currentAmmo != maxAmmo)
        {
            StartCoroutine(Reload());
            return;
        }
		UImunicion.text = currentAmmo.ToString ();
		balastotal.text = currentAmmo.ToString ();
		
	}

    IEnumerator Reload()
    {
        IsReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime -.25f);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        IsReloading = false;
    }


    void Shoot()
    {
        particles.Play();
        RaycastHit hit;
        animator.SetBool("Shooting", true);
        if ( Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if( target != null)
            {
                target.TakeDamage(damage);
            }
            if( hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce );
            }
           GameObject Flare= Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(Flare, 1f);
        }
        currentAmmo--;
    }
}
