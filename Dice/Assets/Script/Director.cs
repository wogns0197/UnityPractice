using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Director : MonoBehaviour
{	
	public int dicesum,stop_dicenum,setnumofdice;
	public TextMeshProUGUI num;
    float time;
    void Start()
    {	
    	// num = GameObject.Find("dicenum");
        time=0;
        dicesum=0;
        stop_dicenum=0;
        setnumofdice=1;
    }

    
    void Update()
    {	    	
    	if(Input.GetKeyDown(KeyCode.A)){
    		setnumofdice++;
    	}
		if(dicesum!=0 &&stop_dicenum==setnumofdice){
			num.text = dicesum.ToString();
			// dicesum=0;
			// stop_dicenum=0;
		}
	
        

    }
    // bool checklist(int[] list){
    // 	int cnt=0;
    // 	for(int i=0; i<list.Length ; i++){
    // 		if(list[i]!=0){
    // 			cnt++;
    // 		}
    // 	}
    // 	if(cnt == list.Length){return true;}
    // 	else{return false;}
    // }
}
