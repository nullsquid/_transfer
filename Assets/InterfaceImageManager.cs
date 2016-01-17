using UnityEngine;
using System.Collections;

public class InterfaceImageManager : MonoBehaviour {
    Icon chat;
    Icon mail;

    Color imageOn = Color.white;
    Color imageOff = Color.gray;

    void OnEnable() {
        EventManager.StartListening("uiImageInit", UIImagesInit);
    }

    void OnDisable() {
        EventManager.StopListening("uiImageInit", UIImagesInit);
    }

    void UIImagesInit() {
        chat = GetComponentInChildren<ChatIcon>();
        mail = GetComponentInChildren<MailIcon>();
        chat.GetComponent<SpriteRenderer>().color = imageOff;
        mail.GetComponent<SpriteRenderer>().color = imageOff;
    }

    void IncomingChat() {

    }
}
