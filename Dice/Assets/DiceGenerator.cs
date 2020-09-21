using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceGenerator : MonoBehaviour
{
 	public GameObject diceprefab;
 	public GameObject maincamera;
    void Start()
    {
        
    }

    
    void Update()
    {	
    	if(Input.GetKeyDown(KeyCode.A)){
    	    Instantiate(diceprefab, this.transform.position, Quaternion.identity);
    	}
    	
    	

    }


	
}
