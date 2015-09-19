using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using System;
using System.Linq;
public class InputManager : MonoBehaviour{
    private Queue<char> inputBuffer = new Queue<char>();
    private char _inputString;
    public string _newString;
    private bool _canType;
    private bool _canReturn;
    private int _curIndex;
    private int _curChar;
    public List<char> Text = new List<char>();
    List<int> lettersToRemove = new List<int>();
    
    public string NewString {
        get {
            return _newString;
        }
        set {
            _newString = value;
        }
    }
    
    void Update() {
        if (Text.Count - 1 >= 0) {
            _curIndex = Text.Count - 1;
        }
        else {
            _curIndex = 0;
        }
        Debug.Log(_curIndex);
        _inputString = Input.inputString[0];
        //TODO ALL OF THIS NEEDS TO BE OPTIMIZED
        //So many loops and calls and coroutines ugh
        if (Input.inputString == "\b") {
            //NewString = "";
            if (Text.Count > 0) {
                StartCoroutine(DirtyRemove());
              //  StartCoroutine("UpdateString");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return)) {
            //will probably be a coroutine
            ReturnPressEvent();
            StartCoroutine("UpdateString");
        }
        else {
            
            
            StartCoroutine(DirtyInput(_inputString));
            Debug.Log("Input " + _inputString);
            
       }
        



        //}


    }

    IEnumerator DirtyRemove() {
        

        foreach (char letter in Text) {
            if (letter == Text[_curIndex]) {
                lettersToRemove.Add(letter);
                
            }
        }
        
        foreach (int toRemove in lettersToRemove) {
            //removes all of a given letter
            //need to remove the index?
            Text.Remove(Text[toRemove]);
        }
        yield return new WaitForSeconds(0.3F);
        //StartCoroutine("UpdateString");
    }

    IEnumerator DirtyInput(char input) {
        /*if (Text.Count ==) {
            Text.Add(input);
            yield return null;

        }*/
        //else { 
        yield return new WaitForSeconds(0.03F);
        Text.Add(input);
        //}


        //StartCoroutine("UpdateString");
    }

    IEnumerator UpdateString() {
        // while (Text.Count != 0) {
        NewString = "";
        
        for (int i = 0; i < Text.Count; i++) {
            yield return new WaitForFixedUpdate();
            //this routine has to fire after all the other ones go
            NewString += Text[i];
            Debug.Log(NewString);
            //yield return new WaitForEndOfFrame();
            
           // yield return new WaitForSeconds(.02f);
            


        }
        
    }

    IEnumerator ReturnPressEvent() {
        Text.Clear();
        yield return null;
    }
   
}
