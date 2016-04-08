using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour {
    Camera cameraMain;
    postVHSPro vhs;
	
	
	void OnEnable() {
        //Startup
        EventManager.StartListening("setupCamera", SetupCamera);
        //Through Play
        EventManager.StartListening("pixelate", PixelateTrigger);
    }
    void OnDisable() {
        //Startup
        EventManager.StopListening("setupCamera", SetupCamera);
        //Through Play
        EventManager.StopListening("pixelate", PixelateTrigger);
    }

    public void StartScreenShake(int numShakes)
    {
        StartCoroutine(ScreenShake(numShakes));
        StopCoroutine(ScreenShake(numShakes));
    }

    void SetupCamera() {
        cameraMain = Camera.main;
        vhs = GetComponent<postVHSPro>();
    }

    IEnumerator ScreenShake(int numOfShakes)
    {
        
        for(int i = 0; i < numOfShakes; i++)
        {
            Camera.main.orthographicSize = Random.Range(20, 23);
            cameraMain.transform.position = new Vector3(Random.Range(-2.0f, 2.0f), 0, -10);
            yield return new WaitForEndOfFrame();
        }        
        Camera.main.orthographicSize = 20;
        cameraMain.transform.position = new Vector3(0, 0, -10);

    }
    void PixelateTrigger() {
        StartCoroutine(Pixelate());
    }

    IEnumerator Pixelate() {
        //TODO Move this into effects manager
        Camera.main.GetComponent<TOZ.ImageEffects.PP_Pixelated>().enabled = true;
        GameObject.Find("TextManager").GetComponent<TextDisplay>().canType = false;
        yield return new WaitForSeconds(.5f);
        Camera.main.GetComponent<TOZ.ImageEffects.PP_Pixelated>().enabled = false;
        GameObject.Find("TextManager").GetComponent<TextDisplay>().canType = true;
    }
}
