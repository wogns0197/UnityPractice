using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGen : MonoBehaviour {
	public GameObject arrow_prefab;
	public Vector3 startpos;
	public Quaternion startrot;
	void Start () {
		startpos = arrow_prefab.transform.position;
		startrot = arrow_prefab.transform.rotation;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ArrowGenerator(){
		Instantiate(arrow_prefab, startpos, startrot);
	}
}
