using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class NodePropertyView : ViewBase {
    #region Public Variables
    public bool showProperties = false;
    #endregion

    #region Protected Variables
    #endregion

    #region Constructors
    public NodePropertyView() : base("Property View") { }
    #endregion

    #region Main Methods
    public override void UpdateView(Rect editorRect, Rect percentageRect, Event e, NodeGraph curGraph) {
        base.UpdateView(editorRect, percentageRect, e, curGraph);
        //Debug.Log("updating " + viewTitle);
        GUI.Box(viewRect, viewTitle, viewSkin.GetStyle("ViewBG"));
        GUI.color = Color.white;
        GUILayout.BeginArea(viewRect);
        GUILayout.Space(60);
        GUILayout.BeginHorizontal();
        GUILayout.Space(30);

        if (curGraph != null) {
            if (!curGraph.showProperties) {
                //GUI.contentColor = Color.blue;
                EditorGUILayout.LabelField("NONE");
            }
            else {
                curGraph.selectedNode.DrawNodeProperties();
            }
            

            ProcessEvents(e);
        }
        GUILayout.Space(30);
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    public override void ProcessEvents(Event e) {
        base.ProcessEvents(e);
        if (viewRect.Contains(e.mousePosition)) {
            Debug.Log("inside " + viewTitle);
        }

    }
    #endregion

    #region Utility Methods
    #endregion

}
