using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pooler : MonoBehaviour {

	[System.Serializable]
	public class Pool
	{
		public string tag;
		public GameObject prefab;
		public int size;
	}


	//SINGLETON--------------------------
	public static pooler Instance;

	private void Awake()
	{

		Instance = this;
	}
	//----------------------------------------

	public List<Pool> pools;
	public Dictionary<string, Queue<GameObject>> poolDictionary;

	void Start () {

		poolDictionary = new Dictionary<string, Queue<GameObject>>();

		foreach (Pool pool in pools) {
			
			Queue<GameObject> objectPool = new Queue<GameObject> ();

			for (int i = 0; i < pool.size; i++) {
				GameObject obj = Instantiate (pool.prefab);
				obj.SetActive (false);
				objectPool.Enqueue (obj);
			}
		
			poolDictionary.Add (pool.tag, objectPool);
		}
	}

	public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
	{
		if (!poolDictionary.ContainsKey(tag)) {
			Debug.LogWarning ("pool with tag" + tag + "doen't exist. ");
			return null;
		
		}

		GameObject ObjectToSpawn = poolDictionary [tag].Dequeue ();

		ObjectToSpawn.SetActive (true);
		ObjectToSpawn.transform.position = position;
		ObjectToSpawn.transform.rotation = rotation;

		pooledObjects pooledObj = ObjectToSpawn.GetComponent<pooledObjects> ();

		if (pooledObj != null) {
			pooledObj.OnObjectSpawn();
		}
		poolDictionary[tag].Enqueue(ObjectToSpawn);

		return ObjectToSpawn;
	}
}
