using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huddle1gen : MonoBehaviour {

	public GameObject h1;
	public GameObject h1_pos;
	int wait_time;
	public float timer;
	void Start () {
		timer = 0.0f;
		wait_time = 4;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if( timer>wait_time ){
			Instantiate(h1, h1_pos.transform.position, h1_pos.transform.rotation);	
			timer = 0.0f;
			GameObject.FindGameObjectWithTag("caltext").GetComponent<Calculatenum>().change();
		}
		
		// print(GameObject.FindGameObjectWithTag("Huddle").transform.position.z);

		if(gameObject.transform.position.z < 5.0f){
			Destroy(gameObject);
			
		}
	}
}
