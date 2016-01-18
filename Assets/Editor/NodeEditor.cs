using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
public class NodeCreator : EditorWindow {

    public GameObject nodeObject;
    public string nodePrompt;
    string prompt;
    string[] responses;

    List<List<GameObject>> nodes = new List<List<GameObject>>();

    [MenuItem("CustomTools/NodeEditor")]
    public static void GetWindow() {
        EditorWindow.GetWindow(typeof(NodeCreator));
    }
    void OnGUI() {
        //Fields for chaging variables
        nodeObject = (GameObject)EditorGUI.ObjectField(new Rect(4, 4, position.width - 8, 16), "Node", nodeObject, typeof(GameObject), true);
        nodePrompt = EditorGUI.TextField(new Rect(4, 24, position.width - 8, 16), "Prompt", prompt);
        //Buttons
        if (GUI.Button(new Rect(4, 64, position.width - 8, 24), "Create Nodes")) {

        }

        if (GUI.Button(new Rect(4, 92, position.width - 8, 24), "Clear Nodes")) {

        }
        if (nodes.Count > 0) {
            if (GUI.Button(new Rect(4, 120, position.width - 8, 24), "Set Node Data")) {

            }
        }
    }
    

    void AddNode() {
        Instantiate(nodeObject, Vector3.zero, Quaternion.identity);
    }

    void RmNode() {

    }
}