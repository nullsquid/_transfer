using UnityEngine;
using System.Collections;

public class TimeKeeper : MonoBehaviour {


	public float seconds = 0;
	public float minutes = 0;
	public float hours = 0;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		seconds = seconds + Time.deltaTime;
		Mathf.RoundToInt(seconds);
		if(seconds>=60){
			Invoke("IncrementMinutes", 0);
			seconds = 0;
		}
	}

	void IncrementMinutes(){

		minutes = minutes + 1;
		if(minutes >= 60){

			Invoke("IncrementHours", 0);
			minutes = 0;

		}

	}

	void IncrementHours(){

		hours = hours + 1;

	}
}
