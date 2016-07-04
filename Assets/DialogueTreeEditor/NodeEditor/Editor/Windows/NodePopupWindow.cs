using UnityEngine;
using UnityEditor;
using System.Collections;

public class NodePopupWindow : EditorWindow {
    #region Variables
    static NodePopupWindow curPopup;
    string wantedName = "Enter a name...";
    #endregion

    #region Main Methods
    public static void InitNodePopup() {
        curPopup = (NodePopupWindow)EditorWindow.GetWindow<NodePopupWindow>();
        curPopup.title = "Node Popup";
    }

    void OnGUI() {
        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        GUILayout.Space(20);

        GUILayout.BeginVertical();
        EditorGUILayout.LabelField("Create New Graph", EditorStyles.boldLabel);
        wantedName = EditorGUILayout.TextField("Enter Name", wantedName);
        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        if(GUILayout.Button("Create Graph", GUILayout.Height(40))) {
            if(string.IsNullOrEmpty(wantedName) || wantedName != "Enter a name...") {
                NodeUtils.CreateNewGraph(wantedName);
                curPopup.Close();
            }
            else {
                EditorUtility.DisplayDialog("Node Message: ", "Please enter a valid graph name!", "OK");
            }
        }
        if(GUILayout.Button("Cancel", GUILayout.Height(40))) {
            curPopup.Close();
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();

        GUILayout.Space(20);
        GUILayout.EndHorizontal();
        GUILayout.Space(20);
    }
    #endregion

    #region Util Methods
    #endregion
}
