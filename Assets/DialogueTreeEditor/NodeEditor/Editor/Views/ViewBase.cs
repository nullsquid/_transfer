using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.Collections;

[Serializable]
public class ViewBase {
    #region Public Variables
    public string viewTitle;
    public Rect viewRect;
    #endregion

    #region Protected Variables
    protected GUISkin viewSkin;
    protected NodeGraph curGraph;
    #endregion

    #region Constructors
    public ViewBase (string title) {
        viewTitle = title;
        GetEditorSkin();
    }
    #endregion

    #region Main Methods
    public virtual void UpdateView(Rect editorRect, Rect percentageRect, Event e, NodeGraph curGraph) {
        //Debug.Log("updating Base view class");
        if(viewSkin == null) {
            GetEditorSkin();
            return;
        }
        //set the current view graph
        this.curGraph = curGraph;
        if (curGraph != null) {
            viewTitle = curGraph.graphName;
        }
        else {
            viewTitle = "No Graph";
        }
        //Update view rectangle
        viewRect = new Rect(editorRect.x * percentageRect.x,
                            editorRect.y * percentageRect.y,
                            editorRect.width * percentageRect.width,
                            editorRect.height * percentageRect.height);
        
    }

    public virtual void ProcessEvents(Event e) {

    }
    #endregion

    #region Utility Methods
    protected void GetEditorSkin() {
        viewSkin = (GUISkin)Resources.Load("GUISkins/EditorSkins/NodeEditorSkin");
    }
    #endregion


}
