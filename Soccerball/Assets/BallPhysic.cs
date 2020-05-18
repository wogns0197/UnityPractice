using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallPhysic : MonoBehaviour {
	public GameObject bd;
	public int ln=0,rn=0;

	void Start () {
		
	}
	
	void Update () {
		Vector3 pos = transform.position;
		if(pos.z<1.5 && pos.z>-1.5 && pos.y<3){
			if( (pos.x<-19) || (pos.x>19)){
				this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
				this.GetComponent<Rigidbody>().velocity = Vector3.zero;
				this.transform.position = new Vector3(0f,6.0f,0f);


			}
			if(pos.x<-19){
				rn++;
				bd.GetComponent<TextMesh>().text= ln.ToString() + " : " + rn.ToString();

			}
			if(pos.x>19){
				ln++;
				bd.GetComponent<TextMesh>().text= ln.ToString() + " : " + rn.ToString();

			}
		}
	}
}
