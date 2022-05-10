using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

	public GameObject[] prefabs;
	public int noOfPreloadObjects = 20;

	public List<GameObject> list;

	public bool autoPreload = true;

	private int count;

	[HideInInspector]
	public GameObject firstPrefab{
		get{
			return prefabs [0];
		}
	}

	void Awake(){
		if (autoPreload) {
			PreloadObjects ();
		}
	}

	public void PreloadObjects(){

		list = new List<GameObject>();

		int len = prefabs.Length;

		for (int i = 0; i < len; i++) {
			for (int j = 0; j < noOfPreloadObjects; j++) {
				Create (prefabs [i]);
			}
		}	
	}

	public GameObject Pool(GameObject prefab){
		for (int i = 0; i < count; i++) {
			if (!list [i].activeSelf && prefab.name == list[i].name)
				return list [i];
		}
		return Create (prefab);
	}

    public GameObject Pool(int prefabIndex) {
        return Pool(prefabs[prefabIndex]);
    }




    GameObject Create(GameObject prefab){		
		GameObject g = Instantiate (prefab);
		g.name = prefab.name;
		g.transform.parent = transform;
		g.SetActive (false);
		list.Add (g);
		count = list.Count;
		return g;
	}






}
