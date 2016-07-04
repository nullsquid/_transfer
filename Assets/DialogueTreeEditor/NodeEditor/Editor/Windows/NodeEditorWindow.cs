using UnityEngine;
using UnityEditor;
using System.Collections;

public class NodeEditorWindow : EditorWindow {

    #region Variables
    public static NodeEditorWindow curWindow;

    public NodePropertyView propertyView;
    public NodeWorkView workView;

    public NodeGraph curGraph = null;

    public float viewPercentage = 0.75f;
    #endregion

    #region MainMethods
    public static void InitEditorWindow() {
        curWindow = (NodeEditorWindow)EditorWindow.GetWindow<NodeEditorWindow>();
        curWindow.title = "Node Editor";

        CreateViews();
    }

    void OnEnable() {
        //Debug.Log("enabled window!");
    }

    void OnDestroy() {
        //Debug.Log("Disabled window");
    }

    void Update() {
        //Debug.Log("Updating window");
    }

    void OnGUI() {
        //Checks for null views
        if(propertyView == null || workView == null) {
            CreateViews();
            return;
        }

        //Gets and processes the current event
        Event e = Event.current;
        ProcessEvents(e);

        //Update views
        workView.UpdateView(position, new Rect(0f, 0f, viewPercentage, 1.0f), e, curGraph);
        propertyView.UpdateView(new Rect(position.width, position.y, position.width, position.height),
                                new Rect(viewPercentage, 0f, 1.0f - viewPercentage, 1.0f), e, curGraph);

        Repaint();

    }
    #endregion

    #region Util Methods
    static void CreateViews() {
        if(curWindow != null) {
            curWindow.propertyView = new NodePropertyView();
            curWindow.workView = new NodeWorkView();
        }
        else {
            curWindow = (NodeEditorWindow)EditorWindow.GetWindow<NodeEditorWindow>();
        }
    }

    void ProcessEvents(Event e) {
        if (e.type == EventType.KeyDown && e.keyCode == KeyCode.LeftArrow) {
            viewPercentage -= 0.01f;
        }
        else if (e.type == EventType.KeyDown && e.keyCode == KeyCode.RightArrow) {
            viewPercentage += 0.01f;
        }
    }
    #endregion

}
