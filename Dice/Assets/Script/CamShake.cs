using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 originPos;
 
	void Start () {
	    originPos = transform.localPosition;
	}

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
    	    Shake(30f,10f);
    	}
    }
    public IEnumerator Shake(float _amount,float _duration)
	{	
		Debug.Log("!@#!@#!@");
	    float timer=0;
	    while(timer <= _duration)
	    {
	        transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + originPos;
	 
	        timer += Time.deltaTime;
	        yield return null;
	    }
	    transform.localPosition = originPos;
	 
	}
}
