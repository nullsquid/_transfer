using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

public class InterfaceElementController : MonoBehaviour {

	public GameObject connectionInterface;
	public Text header;

	bool connectionInterfaceExists = false;

	#region eventlisteners
	private UnityAction connectListener;
	private UnityAction exitConnectListener;
	#endregion

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
			header.enabled = false;
			Debug.Log("connection loaded");
		}
		connectionInterfaceExists = true;
	}

	void ExitConnectionInterface(){
		if(connectionInterfaceExists == true){
			Destroy(newConnectionInterface);
			newConnectionInterface = null;
			header.enabled = true;

		}
		connectionInterfaceExists = false;
		Debug.Log("exit");
	}
}
