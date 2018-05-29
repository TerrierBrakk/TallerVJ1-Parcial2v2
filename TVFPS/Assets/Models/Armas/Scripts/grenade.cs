using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour {

    public float delay = 3f;
    //public SphereCollider myCollider;
    public float damage = 100f;
    public float radius = 10f;
    float countdown;
    bool hasExploded = false;
    public float explosionForce = 600f;
    public GameObject explosioneffect;
	// Use this for initialization
	void Start () {
        countdown = delay;
		
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if(countdown <= 0 && !hasExploded)
        {
                explode();
            hasExploded = true;
        }
	}
    void explode()
    {
        //mostrar efecto 
        GameObject explosion = Instantiate(explosioneffect, transform.position, transform.rotation);
        Destroy(explosion, 1f);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach( Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            Target target = nearbyObject.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, radius);
            }
        }

        Physics.OverlapSphere(transform.position, radius);
        Destroy(gameObject);
        //fuerzas de la explosion
    }

   /* protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>())
        {
            other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(
                explosionForce, transform.position, myCollider.radius);
        }
        
    }
    */
}
