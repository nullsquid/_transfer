using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class NodeGraph : ScriptableObject {
    #region Public Variables
    public string graphName = "New Graph";
    public List<NodeBase> nodes;
    public NodeBase selectedNode;

    public bool showProperties = false;
    public bool wantsConnection;
    public NodeBase connectionNode;
    #endregion

    #region Main Methods
    void OnEnable() {
        if(nodes == null) {
            nodes = new List<NodeBase>();
        }
    }

    public void InitGraph() {
        if(nodes.Count > 0) {
            for(int i = 0; i < nodes.Count; i++) {
                nodes[i].InitNode();
            }
        }
    }
    public void UpdateGraph() {
        if(nodes.Count > 0) {

        }
    }
    #if UNITY_EDITOR
    public void UpdateGraphGUI(Event e, Rect viewRect, GUISkin viewSkin) {
        if(nodes.Count > 0) {
            ProcessEvents(e, viewRect);
            for(int i = 0; i < nodes.Count; i++) {
                nodes[i].UpdateNodeGUI(e, viewRect, viewSkin);
            }
        }
        if (wantsConnection) {
            if(connectionNode != null) {
                DrawConnectionToMouse(e.mousePosition);
            }
        }

        if(e.type == EventType.Layout) {
            if(selectedNode != null) {
                showProperties = true;
            }
        }
        EditorUtility.SetDirty(this);
    }
    #endif
    #endregion

    #region Util Methods
    void ProcessEvents(Event e, Rect viewRect) {
        if (viewRect.Contains(e.mousePosition)) {
            if(e.button == 0) {
                if(e.type == EventType.MouseDown) {
                    DeselectAllNodes();
                    bool setNode = false;
                    showProperties = false;
                    selectedNode = null;
                    for(int i = 0; i < nodes.Count; i++) {
                        if (nodes[i].nodeRect.Contains(e.mousePosition)) {
                            nodes[i].isSelected = true;
                            selectedNode = nodes[i];
                            setNode = true;
                        }
                        
                    }
                    if (!setNode) {
                        DeselectAllNodes();
                        //wantsConnection = false;
                        //showProperties = false;
                    }
                }
            }
        }
    }

    void DeselectAllNodes() {
        for(int i = 0; i < nodes.Count; i++) {
            nodes[i].isSelected = false;
        }
    }

    void DrawConnectionToMouse(Vector2 mousePosition) {
        Handles.BeginGUI();
        Handles.color = Color.white;
        Handles.DrawLine(new Vector3(connectionNode.nodeRect.x + connectionNode.nodeRect.width + 24f,
                                     connectionNode.nodeRect.y + (connectionNode.nodeRect.height * 0.5f), 0f),
                                     new Vector3(mousePosition.x, mousePosition.y, 0f));

        Handles.EndGUI();
    }
    #endregion

}
