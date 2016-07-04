using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class NodeWorkView : ViewBase {

    #region Public Variables
    #endregion

    #region Protected Variables
    Vector2 scrollPos;
    Vector2 mousePos;
    int deleteNodeID = 0;
    #endregion

    #region Constructors
    public NodeWorkView() : base("Work View") { }
    #endregion

    #region Main Methods
    public override void UpdateView(Rect editorRect, Rect percentageRect, Event e, NodeGraph curGraph) {
        base.UpdateView(editorRect, percentageRect, e, curGraph);

        //Debug.Log("updating " + viewTitle);
        GUI.Box(viewRect, viewTitle, viewSkin.GetStyle("ViewBG"));

        //Draws grid
        NodeUtils.DrawGrid(viewRect, 50, 0.15f, Color.white);

        GUILayout.BeginArea(viewRect);
        //scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(viewRect.width), GUILayout.Height(viewRect.height));
        //EditorGUILayout.EndScrollView();
        if (curGraph != null) {
            curGraph.UpdateGraphGUI(e, viewRect, viewSkin);
        }
        
        GUILayout.EndArea();

        ProcessEvents(e);
    }

    public override void ProcessEvents(Event e) {
        base.ProcessEvents(e);


        if (e.button == 1) {
            if (e.type == EventType.MouseDown) {
                mousePos = e.mousePosition;
                bool overNode = false;
                deleteNodeID = 0;
                if (curGraph != null) {
                    if (curGraph.nodes.Count > 0) {
                        for (int i = 0; i < curGraph.nodes.Count; i++) {
                            if (curGraph.nodes[i].nodeRect.Contains(mousePos)) {
                                deleteNodeID = i;
                                overNode = true;
                            }
                        }
                    }
                }

                if (!overNode) {
                    ProcessContextMenu(e, 0);
                }
                else {
                    ProcessContextMenu(e, 1);
                }
            }
        }
    }



    #endregion

    #region Util Methods
    void ProcessContextMenu(Event e, int contextID) {
        GenericMenu menu = new GenericMenu();
        if (contextID == 0) {
            menu.AddItem(new GUIContent("Create Graph"), false, ContextCallback, "0");
            menu.AddItem(new GUIContent("Load Graph"), false, ContextCallback, "1");

            if (curGraph != null) {
                menu.AddSeparator("");
                menu.AddItem(new GUIContent("Unload Graph"), false, ContextCallback, "2");

                menu.AddSeparator("");
                menu.AddItem(new GUIContent("Float Node"), false, ContextCallback, "3");
                menu.AddItem(new GUIContent("Add Node"), false, ContextCallback, "4");

            }
        }
        if (contextID == 1) {
            if (curGraph != null) {

                menu.AddItem(new GUIContent("Delete Node"), false, ContextCallback, "5");


            }
        }

        menu.ShowAsContext();
        e.Use();

    }

    void ContextCallback(object obj) {
        switch (obj.ToString()) {
            case "0":
                NodePopupWindow.InitNodePopup();
                break;
            case "1":
                Debug.Log("Loading New Graph");
                NodeUtils.LoadGraph();
                break;
            case "2":
                Debug.Log("Unloading Graph");
                NodeUtils.UnloadGraph();
                break;
            case "3":
                NodeUtils.CreateNode(curGraph, NodeType.Float, mousePos);
                break;
            case "4":
                NodeUtils.CreateNode(curGraph, NodeType.Add, mousePos);
                break;
            case "5":
                NodeUtils.DeleteNode(deleteNodeID, curGraph);
                break;
            default:
                break;
        }
    }
    #endregion

}
