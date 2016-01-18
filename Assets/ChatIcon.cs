using UnityEngine;
using System.Collections;

public class ChatIcon : Icon {


    float duration = 1;
    public SpriteRenderer chatImage;
    void NewChatMessage() {

    }
    float alpha;
    void Start() {
        alpha = GetComponentInChildren<SpriteRenderer>().material.color.a;
        chatImage = GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(FadeOut());
        StartCoroutine(FadeIn());
        
        
    }


    IEnumerator FadeIn() {
        
        float d = 0.3f / duration;
        while (alpha < 1) {
            alpha += Time.deltaTime * d;
            gameObject.GetComponentInChildren<SpriteRenderer>().material.color = new Color(1, 1, 1, alpha);
            yield return null;
            //yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator FadeOut() {
        
        float d = 0.3f / duration;
        while (alpha >= 1) {
            alpha -= Time.deltaTime * d;
            gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, alpha);

            yield return null;
        }
    }
}
