using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour {
    Camera cameraMain;
	// Use this for initialization
	void Start () {

        cameraMain = Camera.main;
        Debug.Log(cameraMain);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartScreenShake()
    {
        StartCoroutine(ScreenShake());
        StopCoroutine(ScreenShake());
    }

    IEnumerator ScreenShake()
    {
        bool shake = true;
        //float cameraPosX = Camera.main.transform.position.x;
        //float newCameraPosX = Camera.main.transform.position.x;
        while (shake == true)
        {
            Camera.main.orthographicSize = Random.Range(20, 23);
            cameraMain.transform.position = new Vector3(Random.Range(-1, 1), 0, -10);
            yield return new WaitForEndOfFrame();
            Camera.main.orthographicSize = Random.Range(20, 23);
            cameraMain.transform.position = new Vector3(Random.Range(-1, 1), 0, -10);
            yield return new WaitForEndOfFrame();
            Camera.main.orthographicSize = Random.Range(20, 23);
            cameraMain.transform.position = new Vector3(Random.Range(-1, 1), 0, -10);
            yield return new WaitForEndOfFrame();
            Camera.main.orthographicSize = Random.Range(20, 23);
            cameraMain.transform.position = new Vector3(Random.Range(-1, 1), 0, -10);
            yield return new WaitForEndOfFrame();
            Camera.main.orthographicSize = Random.Range(20, 23);
            cameraMain.transform.position = new Vector3(Random.Range(-1, 1), 0, -10);
            yield return new WaitForEndOfFrame();
            shake = false;

        }
        
        Camera.main.orthographicSize = 20;
        cameraMain.transform.position = new Vector3(0, 0, -10);

        //newCameraPosX = cameraPosX;

    }
}
