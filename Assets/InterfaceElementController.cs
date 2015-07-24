using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
public class InterfaceElementController : MonoBehaviour {

	public GameObject connectionInterface;


	bool connectionInterfaceExists = false;

	private UnityAction connectListener;
	private UnityAction exitConnectListener;

	public GameObject newConnectionInterface;


	void OnEnable(){
		EventManager.StartListening("connected", connectListener);
		EventManager.StartListening("exitConnected", exitConnectListener);
	}
	
	void OnDisable(){
		EventManager.StopListening("connected", connectListener);
		EventManager.StopListening("exitConnected", exitConnectListener);
	}

	void Awake(){
		connectListener = new UnityAction(LoadConnectionInterface);
		exitConnectListener = new UnityAction(ExitConnectionInterface);

	}

	void LoadConnectionInterface(){
		if(connectionInterfaceExists == false){
			newConnectionInterface = Instantiate(connectionInterface, transform.position = Vector3.zero, transform.rotation) as GameObject;
			newConnectionInterface.transform.parent = transform;
			Debug.Log("connection loaded");
		}
		connectionInterfaceExists = true;
	}

	void ExitConnectionInterface(){
		if(connectionInterfaceExists == true){
			Destroy(newConnectionInterface);
			newConnectionInterface = null;
		}
		connectionInterfaceExists = false;
		Debug.Log("exit");
	}
}
