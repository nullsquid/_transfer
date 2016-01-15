using UnityEngine;
using System.Collections;

public class ChatIcon : Icon {


    float duration = 1;
    public Sprite chatImage;
    void NewChatMessage() {

    }
    float alpha;
    void Start() {
        alpha = GetComponent<SpriteRenderer>().material.color.a;
        chatImage = GetComponent<SpriteRenderer>().sprite;
        StartCoroutine(FadeOut());
        StartCoroutine(FadeIn());
        
        
    }


    IEnumerator FadeIn() {
        
        float d = 0.3f / duration;
        while (alpha < 1) {
            alpha += Time.deltaTime * d;
            gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, alpha);
            yield return null;
            //yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator FadeOut() {
        
        float d = 0.3f / duration;
        while (alpha >= 1) {
            alpha -= Time.deltaTime * d;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);

            yield return null;
        }
    }
}
