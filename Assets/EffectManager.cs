using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour {
    Camera cameraMain;

	
	
	void OnEnable() {
        EventManager.StartListening("setupCamera", SetupCamera);
    }
    void OnDisable() {
        EventManager.StopListening("setupCamera", SetupCamera);
    }

    public void StartScreenShake(int numShakes)
    {
        StartCoroutine(ScreenShake(numShakes));
        StopCoroutine(ScreenShake(numShakes));
    }

    void SetupCamera() {
        cameraMain = Camera.main;
        //Debug.Log(cameraMain);
    }

    IEnumerator ScreenShake(int numOfShakes)
    {
        //bool shake = true;
        //float cameraPosX = Camera.main.transform.position.x;
        //float newCameraPosX = Camera.main.transform.position.x;
        /*while (shake == true)
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

        }*/
        for(int i = 0; i < numOfShakes; i++)
        {
            Camera.main.orthographicSize = Random.Range(20, 23);
            cameraMain.transform.position = new Vector3(Random.Range(-2.0f, 2.0f), 0, -10);
            yield return new WaitForEndOfFrame();
        }        
        Camera.main.orthographicSize = 20;
        cameraMain.transform.position = new Vector3(0, 0, -10);

        //newCameraPosX = cameraPosX;

    }
}
