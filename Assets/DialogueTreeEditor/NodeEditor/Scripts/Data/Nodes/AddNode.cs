using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.Collections;

[Serializable]
public class AddNode : NodeBase {

    #region Variables
    public float nodeSum;
    public NodeInput inputA;
    public NodeInput inputB;
    public NodeOutput output;
    #endregion

    #region Constructor
    public AddNode() {
        output = new NodeOutput();
        inputA = new NodeInput();
        inputB = new NodeInput();
    }
    #endregion

    #region Main Methods
    public override void InitNode() {
        base.InitNode();
        nodeType = NodeType.Add;
        nodeRect = new Rect(10f, 10f, 200f, 65f);

    }

    public override void UpdateNode(Event e, Rect viewRect) {
        base.UpdateNode(e, viewRect);
    }
#if UNITY_EDITOR
    public override void UpdateNodeGUI(Event e, Rect viewRect, GUISkin viewSkin) {
        base.UpdateNodeGUI(e, viewRect, viewSkin);
        //output
        if (GUI.Button(new Rect(nodeRect.x + nodeRect.width, nodeRect.y + (nodeRect.height * 0.5f) - 12f, 24f, 24f), "", viewSkin.GetStyle("nodeOutput"))) {

            if (parentGraph != null) {
                parentGraph.wantsConnection = true;
                parentGraph.connectionNode = this;
            }
        }

        //input A
        if (GUI.Button(new Rect(nodeRect.x - 24f, (nodeRect.y + (nodeRect.height * 0.33f)) - 14f, 24f, 24f), "", viewSkin.GetStyle("nodeInput"))) {
            if(parentGraph != null) {
                inputA.inputNode = parentGraph.connectionNode;
                inputA.isOccupied = inputA.inputNode != null ? true : false;

                parentGraph.wantsConnection = false;
                parentGraph.connectionNode = null;

            }

        }

        //input B
        if (GUI.Button(new Rect(nodeRect.x - 24f, (nodeRect.y + (nodeRect.height * 0.33f) * 2.0f) - 8f, 24f, 24f), "", viewSkin.GetStyle("nodeInput"))) {


            if (parentGraph != null) {
                inputB.inputNode = parentGraph.connectionNode;
                inputB.isOccupied = inputB.inputNode != null ? true : false;

                parentGraph.wantsConnection = false;
                parentGraph.connectionNode = null;

            }
        }

        if(inputA.isOccupied && inputB.isOccupied) {
            FloatNode nodeA = (FloatNode)inputA.inputNode;
            FloatNode nodeB = (FloatNode)inputB.inputNode;
            if(nodeA != null && nodeB != null) {
                nodeSum = nodeA.nodeValue + nodeB.nodeValue;
            }

        }
        else {
            nodeSum = 0.0f;
        }
        //DrawLines
        DrawInputLines();
        
    }
    public override void DrawNodeProperties() {
        base.DrawNodeProperties();

        EditorGUILayout.FloatField("Sum : ", nodeSum);
    }
#endif
    #endregion

    #region Util Methods
    void DrawInputLines() {
        if (inputA.isOccupied && inputA.inputNode != null) {
            DrawLines(inputA, 1f);
        }
        else {
            inputA.isOccupied = false;
        }
        if (inputB.isOccupied && inputB.inputNode != null) {
            DrawLines(inputB, 2f);

        }
        else {
            inputB.isOccupied = false;
        }
    }

    void DrawLines(NodeInput curInput, float inputID) {
        Handles.BeginGUI();
        Handles.color = Color.white;
        Handles.DrawLine(new Vector3(curInput.inputNode.nodeRect.x + curInput.inputNode.nodeRect.width + 24f,
                         curInput.inputNode.nodeRect.y + (curInput.inputNode.nodeRect.height * 0.5f), 0f),
                         new Vector3(nodeRect.x - 24f, (nodeRect.y + (nodeRect.height * 0.33f) * inputID), 0f));

        Handles.EndGUI();
    }
    #endregion
}
