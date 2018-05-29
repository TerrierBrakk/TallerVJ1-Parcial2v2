using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lanzagranada : MonoBehaviour {

    public float fireRate = 15f;
    public ParticleSystem particles;
    public float throwForce = 40f;
    public GameObject grenadePrefab;
    // Use this for initialization
    private float nextTimetoFire = 0F;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 2f;

    private bool IsReloading = false;
    public Animator animator;

	public Text UImunicion;
	public Text balastotal;

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


    void Update()
    {
        animator.SetBool("Shooting", false);

        if (IsReloading)
        {
            return;
        }
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1f / fireRate;
            ThrowGrenade();
        }

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo != maxAmmo)
        {
            StartCoroutine(Reload());
            return;
        }
		UImunicion.text = currentAmmo.ToString ();
		balastotal.text = currentAmmo.ToString ();
    }

    void ThrowGrenade()
    {
        particles.Play();
        animator.SetBool("Shooting", true);
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce);
        currentAmmo--;
    }

    IEnumerator Reload()
    {
        IsReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        IsReloading = false;
    }

}


