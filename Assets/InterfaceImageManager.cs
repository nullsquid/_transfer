using UnityEngine;
using System.Collections;

public class InterfaceImageManager : MonoBehaviour {
    Icon chat;
	
    

    void UIImagesInit() {
        chat = GetComponent<ChatIcon>();
    }

    void IncomingChat() {

    }
}
