using UnityEngine;
using System.Collections;

public class InterfaceImageManager : MonoBehaviour {
    public Icon chat;
    Icon mail;

    Color imageOn = Color.white;
    Color imageOff = Color.gray;
    public SpriteRenderer chatImageRenderer;

    void OnEnable() {
        EventManager.StartListening("uiImageInit", UIImagesInit);
    }

    void OnDisable() {
        EventManager.StopListening("uiImageInit", UIImagesInit);
    }

    void UIImagesInit() {
        

        chat = GetComponentInChildren<ChatIcon>();
        mail = GetComponentInChildren<MailIcon>();
        chatImageRenderer = chat.GetComponentInChildren<SpriteRenderer>();
        //chatImageRenderer.color = Color.red;
        //chatImageRenderer.color = new Color(1, 1, 1, 1);
        //HACK
        //chat.gameObject.SetActive(false);
        TurnOffIcon(chat);
        //Debug.Log(chatImageRenderer.color);
        
        //chat.GetComponentInChildren<SpriteRenderer>().color = Color.gray;//imageOff;
        //mail.GetComponentInChildren<SpriteRenderer>().color = imageOff;
    }
    /*
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            IncomingChat();
        }
        else if (Input.GetMouseButton(1)) {
            TurnOffIcon(chat);
        }
    }*/

    void IncomingChat() {
        TurnOnIcon(chat);
    }

    //HACK
    void TurnOnIcon(Icon icon) {
        icon.gameObject.SetActive(true);
        icon.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }

    void TurnOffIcon(Icon icon) {
        //icon.gameObject.SetActive(false);
        icon.GetComponentInChildren<SpriteRenderer>().color = Color.gray;
    }
}
