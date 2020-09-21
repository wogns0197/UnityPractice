using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignorecollision : MonoBehaviour {
	public GameObject o1;
	public GameObject o2;
	void Start () {
		o2 = this.gameObject;
		o1 = GameObject.FindWithTag("wall");
		Physics.IgnoreCollision(o1.GetComponent<Collider>(),o2.GetComponent<Collider>());
	}
	
	void Update () {
		
	}
}
