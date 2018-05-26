using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawner : MonoBehaviour {

	public GameObject nangent;
	public GameObject ObjetivObject;
	pooler objectPooler;
	float tiempo_generar;
	public float Frecuencia = 1f;

    float DistanciaZ = 1f;
	private void Start()
	{
		objectPooler = pooler.Instance;
		tiempo_generar = Time.time + Frecuencia;


        /*for (int i = 0; i < 7; i++)
        {*/
           // objectPooler.SpawnFromPool("Enemy", spawnInicial, Quaternion.identity);
    

       /* }*/
    }

	void FixedUpdate() {

       
		
	
		if (tiempo_generar < Time.time) {
		
			objectPooler.SpawnFromPool ("Enemy",gameObject.transform.position, Quaternion.identity);
			tiempo_generar = Time.time + Frecuencia;
		}
			
	}

	/*void SpawnAgent()
	{
		GameObject nav = (GameObject)Instantiate (nangent, this.transform.position, Quaternion.identity);
		nav.GetComponent<EnemyMov> ().objetivo = ObjetivObject.transform;
		Invoke ("SpawnAgent", Random.Range (5, 20));
	}*/

}
