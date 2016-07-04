using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.Collections;

[Serializable]
public class FloatNode : NodeBase {
    #region Variables
    public float nodeValue;
    public NodeOutput output;
    #endregion

    #region Constructor
    public FloatNode() {
        output = new NodeOutput();
    }
    #endregion

    #region Main Methods
    public override void InitNode() {
        base.InitNode();
        nodeType = NodeType.Float;
        nodeRect = new Rect(10f, 10f, 150f, 65f);

    }

    public override void UpdateNode(Event e, Rect viewRect) {
        base.UpdateNode(e, viewRect);
    }
    #if UNITY_EDITOR
    public override void UpdateNodeGUI(Event e, Rect viewRect, GUISkin viewSkin) {
        base.UpdateNodeGUI(e, viewRect, viewSkin);
        if(GUI.Button(new Rect(nodeRect.x + nodeRect.width, nodeRect.y +(nodeRect.height * 0.5f) - 12f, 24f, 24f), "", viewSkin.GetStyle("nodeOutput"))) {
            Debug.Log("Clicked output");
            if(parentGraph != null) {
                parentGraph.wantsConnection = true;
                parentGraph.connectionNode = this;
            }
        }
    }
    public override void DrawNodeProperties() {
        base.DrawNodeProperties();

        nodeValue = EditorGUILayout.FloatField("Float Value: ", nodeValue);
    }
#endif
    #endregion

    #region Util Methods
    #endregion

}
