using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

    public TextObject textPrefab;
    public float charSpace = 2.0f;
    void Write() {
        transform.Translate(new Vector3(charSpace, 0, 0));
    }
    void Backspace() {


    }
}
