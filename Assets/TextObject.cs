using UnityEngine;
using System.Collections;

public class TextObject : MonoBehaviour {
    private string _text;
    public string Text{

        get {
            return _text;
        }

        set {
            if (_text == null) {
                _text = value;
            }
        }



    }


}
