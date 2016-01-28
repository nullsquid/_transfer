using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ResponseDisplay : MonoBehaviour {
    public GameObject[] responses;
    public ConvTreeSearch treeSearcher;
    public List<string> curResponses;
    public List<int> responseNumbers = new List<int>();
    public ConvNode curNode;
    public int lineLength;
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
                responses[i].GetComponent<TextMesh>().text = i + ". " + curResponses[i];
                /*if(curNode.responses.Count == 0)
                {
                    responses[i].GetComponent<TextMesh>().text = i + ".";
                }*/
            }
            else {
                responses[i].GetComponent<TextMesh>().text = "";
            }

            
        }
    }

    /*string FormatResponse(string inText)
    {
        string formattedText;
        int countToLineBreak;
        for(int i = 0; i < inText.Length; i++)
        {

        }
    }*/

    int NumberResponses() {
        
        for(int i = 0; i < responses.Length; i++) {
            if(responses[i].GetComponent<TextMesh>().text != "") {
                responseNumbers.Add(i);
            }
            
        }
        return 0;

    }

    

}
