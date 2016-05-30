using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ResponseDisplay : MonoBehaviour {
    public GameObject[] responses;
    public ConvTreeSearch treeSearcher;
    public CharacterManager characterManager;
    public List<string> curResponses;
    public List<int> responseNumbers = new List<int>();
    public ConvNode curNode;
    public int lineLength;
    public int lineBreaks;
    private string nameText;
    private string replacementName;
    private Color32 replacementColor;
    // Use this for initialization
    void OnEnable() {
        EventManager.StartListening("setupResponses", SetUpResponses);
        EventManager.StartListening("setCurResponses", SetCurResponses);
    }
    void OnDisable() {
        EventManager.StopListening("setupResponses", SetUpResponses);
        EventManager.StopListening("setCurResponses", SetCurResponses);
    }
    void SetUpResponses() {
        for(int i = 0; i < responses.Length; i++) {
            responses[i].GetComponent<TextMesh>().color = Color.green;
            responses[i].GetComponent<TextMesh>().text = "";
        }
        

    }
    void SetCurResponses() {
        SetUpResponses();
        curResponses.Clear();
        curNode = treeSearcher.GetComponent<ConvTreeSearch>().curNode;
        for (int j = 0; j < curNode.responses.Count; j++) {
            curResponses.Add(curNode.responses[j]);
        }
        for(int i = 0; i < responses.Length; i++) {
            
            if (i < curNode.responses.Count) {
                responses[i].GetComponent<TextMesh>().text = i + ". " + FormatResponse(curResponses[i]);
          
            }
            else {
                responses[i].GetComponent<TextMesh>().text = "";
            }



        }
    }

    string FormatResponse(string inText)
    {
        lineBreaks = 0;
        string formattedText = "";
        int countToLineBreak = 0;
        for(int i = 0; i < inText.Length; i++)
        {
            if(inText[i] == '%') {
                for (int j = 0; j < characterManager.characters.Count; j++) {
                    if (characterManager.characters[j].ID == inText[i + 1].ToString()) {
                        replacementName = characterManager.characters[j].Name;
                        replacementColor = characterManager.characters[j].Color;
                        Debug.Log(replacementName);
                    }
                }
                nameText = inText[i].ToString() + inText[i + 1].ToString();
                Debug.Log(nameText);
            }
            if(countToLineBreak <= lineLength)
            {
                countToLineBreak += 1;
                formattedText += inText[i];
            }
            else if(countToLineBreak > lineLength)
            {
                if (inText[i] == ' ')
                {
                    formattedText += inText[i];
                    formattedText += "\n";
                    lineBreaks += 1;
                    
                    //curResponses[i].GetComponent<Transform>().position += new Vector3(0, 1.7f, 0);
                    countToLineBreak = 0;
                }
                
                else
                {
                    //countToLinebreak += 1;
                    formattedText += inText[i];
                }
                
            }
            if (formattedText.Contains("%")) {

                return formattedText.Replace(nameText, "<color=#ff0000ff>" + replacementName + "</color>");
            }
        }
        return formattedText;

    }

    int NumberResponses() {
        
        for(int i = 0; i < responses.Length; i++) {
            if(responses[i].GetComponent<TextMesh>().text != "") {
                responseNumbers.Add(i);
            }
            
        }
        return 0;

    }

    

}
